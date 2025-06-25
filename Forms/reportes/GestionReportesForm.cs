using DeliveryAppGrupo0008.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DeliveryAppGrupo0008.Forms.reportes
{
    public partial class GestionReportesForm : Form
    {
        private readonly ReporteService _reporteService;

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
            var topProductos = _reporteService.ObtenerTopProductos(desde, hasta, proveedorId);
            var mejorCliente = _reporteService.ObtenerMejorCliente(desde, hasta, proveedorId);

            lblResumen.Text = $"Total Vendido: ${totalVentas:F2}\n" +
                              $"Mejor Cliente: {mejorCliente?.Cliente ?? "N/A"} (${mejorCliente?.TotalGastado:F2})";

            dgvReporte.DataSource = topProductos.Select(p => new
            {
                Producto = p.Producto,
                CantidadVendida = p.Cantidad
            }).ToList();
        }
    }
}
