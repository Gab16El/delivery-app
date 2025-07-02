
using DeliveryAppGrupo0008.Services;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Diagnostics;
using System.IO;

namespace DeliveryAppGrupo0008.Forms.reportes
{
    public partial class GestionReportesForm : Form
    {
        private readonly ReporteService _reporteService;
        private string rutaPdfGenerado = null;

        // Datos para el PDF, guardamos para usar en el botón de generar PDF
        private decimal totalVentasGuardado;
        private List<(string Producto, int Cantidad)> productosPdfGuardado;
        private string mejorClienteGuardado;
        private decimal totalGastadoClienteGuardado;

        public GestionReportesForm(ReporteService reporteService)
        {
            InitializeComponent();
            _reporteService = reporteService;
        }

        private void GestionReportesForm_Load(object sender, EventArgs e)
        {
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cmbTipoReporte.SelectedItem.ToString();
                DateTime hoy = DateTime.Today;
                DateTime desde, hasta = hoy.AddDays(1).AddTicks(-1);

                switch (tipo)
                {
                    case "Diario":
                        desde = hoy;
                        break;
                    case "Semanal":
                        desde = hoy.AddDays(-7);
                        break;
                    case "Mensual":
                        desde = hoy.AddMonths(-1);
                        break;
                    default:
                        desde = hoy;
                        break;
                }

                int? proveedorId = Program.UsuarioLogueado.RoleID == 4 ? Program.UsuarioLogueado.UsuarioID : null;

                decimal totalVentas = _reporteService.ObtenerVentasTotales(desde, hasta, proveedorId);
                var topProductosRaw = _reporteService.ObtenerTopProductos(desde, hasta, proveedorId);
                var mejorClienteObj = _reporteService.ObtenerMejorCliente(desde, hasta, proveedorId);

                lblResumen.Text = $"Total Vendido: S/. {totalVentas:F2}\n" +
                                  $"Mejor Cliente: {mejorClienteObj?.Cliente ?? "N/A"} (S/. {mejorClienteObj?.TotalGastado:F2})";

                var topProductos = topProductosRaw.Select(p => new
                {
                    Producto = p.Producto,
                    CantidadVendida = p.Cantidad
                }).ToList();

                dgvReporte.DataSource = topProductos;

                // Guardamos los datos para PDF para usar luego en el botón
                totalVentasGuardado = totalVentas;
                productosPdfGuardado = topProductos.Select(p => (p.Producto, p.CantidadVendida)).ToList();
                mejorClienteGuardado = mejorClienteObj?.Cliente ?? "N/A";
                totalGastadoClienteGuardado = mejorClienteObj?.TotalGastado ?? 0;

                // Mostrar botón para generar PDF
                btnGenerarPdf.Visible = true;
                btnGenerarExcel.Visible = true;
                rutaPdfGenerado = null; // resetear ruta de PDF

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string carpetaDestino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombreArchivo = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                GenerarExcel(rutaCompleta, totalVentasGuardado, productosPdfGuardado, mejorClienteGuardado, totalGastadoClienteGuardado);

                MessageBox.Show($"Excel generado correctamente en:\n{rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo { FileName = rutaCompleta, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el Excel:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cmbTipoReporte.SelectedItem?.ToString() ?? "Diario";
                DateTime hoy = DateTime.Today;
                DateTime desde = tipo switch
                {
                    "Semanal" => hoy.AddDays(-7),
                    "Mensual" => hoy.AddMonths(-1),
                    _ => hoy
                };
                DateTime hasta = hoy.AddDays(1).AddTicks(-1);

                int? proveedorId = Program.UsuarioLogueado.RoleID == 4 ? Program.UsuarioLogueado.UsuarioID : null;

                // Obtener los datos aquí directamente
                decimal totalVentas = _reporteService.ObtenerVentasTotales(desde, hasta, proveedorId);
                var topProductosRaw = _reporteService.ObtenerTopProductos(desde, hasta, proveedorId);
                var mejorClienteObj = _reporteService.ObtenerMejorCliente(desde, hasta, proveedorId);

                if (topProductosRaw == null || !topProductosRaw.Any())
                {
                    MessageBox.Show("No hay productos vendidos en este periodo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var productos = topProductosRaw.Select(p => (p.Producto, p.Cantidad)).ToList();
                string mejorCliente = mejorClienteObj?.Cliente ?? "N/A";
                decimal totalGastado = mejorClienteObj?.TotalGastado ?? 0;

                string carpetaDestino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombreArchivo = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                if (File.Exists(rutaCompleta))
                {
                    File.Delete(rutaCompleta);
                }

                GenerarPdf(rutaCompleta, totalVentas, productos, mejorCliente, totalGastado);

                MessageBox.Show($"PDF generado correctamente en:\n{rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo { FileName = rutaCompleta, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerarPdf(string rutaArchivo, decimal totalVentas, IEnumerable<(string Producto, int Cantidad)> topProductos, string mejorCliente, decimal totalGastadoCliente)
        {
            PdfWriter writer = null;
            PdfDocument pdf = null;
            Document doc = null;

            try
            {
                writer = new PdfWriter(rutaArchivo);
                pdf = new PdfDocument(writer);
                doc = new Document(pdf);

                var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                doc.Add(new Paragraph("Reporte de Ventas")
                    .SetFont(fontBold)
                    .SetFontSize(18)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20));

                doc.Add(new Paragraph($"Total Vendido: S/. {totalVentas:F2}")
                    .SetFont(font)
                    .SetFontSize(12)
                    .SetMarginBottom(5));

                doc.Add(new Paragraph($"Mejor Cliente: {mejorCliente} (S/. {totalGastadoCliente:F2})")
                    .SetFont(font)
                    .SetFontSize(12)
                    .SetMarginBottom(15));

                doc.Add(new Paragraph("Productos más vendidos:")
                    .SetFont(fontBold)
                    .SetFontSize(14)
                    .SetMarginBottom(10));

                var table = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 })).UseAllAvailableWidth();

                table.AddHeaderCell(new Cell().Add(new Paragraph("Producto").SetFont(fontBold)));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Cantidad Vendida").SetFont(fontBold)));

                foreach (var item in topProductos)
                {
                    if (string.IsNullOrWhiteSpace(item.Producto))
                        continue;

                    table.AddCell(new Cell().Add(new Paragraph(item.Producto).SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph(item.Cantidad.ToString()).SetFont(font)));
                }

                doc.Add(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                doc?.Close();
                pdf?.Close();
                writer?.Close();
            }
        }

        private void GenerarExcel(string rutaArchivo, decimal totalVentas, IEnumerable<(string Producto, int Cantidad)> topProductos, string mejorCliente, decimal totalGastadoCliente)
        {
            try
            {
                using var workbook = new ClosedXML.Excel.XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Reporte Ventas");

                int row = 1;

                worksheet.Cell(row++, 1).Value = "Reporte de Ventas";
                worksheet.Range("A1:B1").Merge().Style.Font.SetBold().Font.FontSize = 16;
                worksheet.Cell(row++, 1).Value = $"Total Vendido:";
                worksheet.Cell(row - 1, 2).Value = totalVentas;

                worksheet.Cell(row++, 1).Value = "Mejor Cliente:";
                worksheet.Cell(row - 1, 2).Value = mejorCliente;

                worksheet.Cell(row++, 1).Value = "Total Gastado por Cliente:";
                worksheet.Cell(row - 1, 2).Value = totalGastadoCliente;

                row++; // línea en blanco

                worksheet.Cell(row, 1).Value = "Producto";
                worksheet.Cell(row, 2).Value = "Cantidad Vendida";
                worksheet.Range(row, 1, row, 2).Style.Font.SetBold();
                row++;

                foreach (var item in topProductos)
                {
                    worksheet.Cell(row, 1).Value = item.Producto;
                    worksheet.Cell(row, 2).Value = item.Cantidad;
                    row++;
                }

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el Excel:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}