using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;
using System.Drawing;

namespace DeliveryAppGrupo0008.Forms.pedidos
{
    public partial class GestionPedidosForm : Form
    {
        private readonly PedidoService _pedidoService;
        private readonly ProductService _productoService;
        private readonly ZoneService _zonaService;

        public GestionPedidosForm(PedidoService pedidoService, ProductService productoService, ZoneService zonaService)
        {
            InitializeComponent();
            _pedidoService = pedidoService;
            _productoService = productoService;
            _zonaService = zonaService;

            cmbProductos.SelectedIndexChanged += (s, e) => CalcularTotal();
            cmbZonas.SelectedIndexChanged += (s, e) => CalcularTotal();
            nudCantidad.ValueChanged += (s, e) => CalcularTotal();
            btnAgregarPedido.Click += BtnAgregarPedido_Click;
            dgvPedidos.CellContentClick += DgvPedidos_CellContentClick;
        }

        private void GestionPedidosForm_Load(object sender, System.EventArgs e)
        {
            CargarCombos();
            CargarPedidosEnGrid();
            btnAgregarPedido.Enabled = Program.UsuarioLogueado?.RoleID == 3; // Solo clientes pueden registrar pedidos
        }

        private void CargarCombos()
        {
            cmbProductos.DataSource = _productoService.GetProductos();
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "ProductoID";

            cmbZonas.DataSource = _zonaService.GetZonas();
            cmbZonas.DisplayMember = "Nombre";
            cmbZonas.ValueMember = "ZonaID";
        }

        private void CargarPedidosEnGrid()
        {
            int rolId = Program.UsuarioLogueado.RoleID;
            int usuarioId = Program.UsuarioLogueado.UsuarioID;

            List<Pedido> pedidos;

            if (rolId == 4) // Proveedor
                pedidos = _pedidoService.GetPedidos(usuarioId);
            else if (rolId == 3) // Cliente
                pedidos = _pedidoService.GetPedidosPorCliente(usuarioId);
            else if (rolId == 2) // Empleado / Delivery
                pedidos = _pedidoService.GetPedidosPorDelivery(usuarioId);
            else // Admin u otros roles
                pedidos = _pedidoService.GetPedidos();

            var pedidosVista = pedidos.Select(p => new
            {
                p.PedidoID,
                Cliente = p.Cliente?.Nombre,
                Productos = string.Join(", ", p.Detalles.Select(d => d.Producto?.Nombre)),
                Proveedores = string.Join(", ", p.Detalles.Select(d => d.Producto?.Proveedor?.Nombre).Distinct()),
                Zona = p.Zona?.Nombre,
                EstadoID = p.EstadoID,
                Estado = p.Estado?.Estado,
                p.FechaPedido,
                FechaEntrega = p.FechaEntrega?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Pendiente",
                Total = p.Total.ToString("C"),
                DeliveryNombre = p.Delivery?.Nombre ?? "No asignado"
            }).ToList();

            dgvPedidos.DataSource = null;
            dgvPedidos.Columns.Clear();
            dgvPedidos.DataSource = pedidosVista;

            // Ocultar columnas técnicas
            dgvPedidos.Columns["PedidoID"].Visible = false;
            dgvPedidos.Columns["EstadoID"].Visible = false;

            // Agregar botones según rol
            if (rolId == 1 || rolId == 4) // Admin: botón para asignar delivery
            {
                var btnAsignar = new DataGridViewButtonColumn
                {
                    Name = "AsignarDelivery",
                    HeaderText = "Acción",
                    Text = "Asignar Delivery",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgvPedidos.Columns.Add(btnAsignar);

                foreach (DataGridViewRow row in dgvPedidos.Rows)
                {
                    int estadoId = Convert.ToInt32(row.Cells["EstadoID"].Value);
                    row.Cells["AsignarDelivery"].ReadOnly = estadoId != 1;
                    row.Cells["AsignarDelivery"].Style.ForeColor = estadoId == 1 ? Color.Black : Color.Gray;
                }
            }
            else if (rolId == 2) // Delivery / Empleado: botones aceptar y cancelar pedido
            {
                var btnAceptar = new DataGridViewButtonColumn
                {
                    Name = "AceptarPedido",
                    HeaderText = "Entregar Delivery",
                    Text = "Entregar Delivery",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgvPedidos.Columns.Add(btnAceptar);

                var btnCancelar = new DataGridViewButtonColumn
                {
                    Name = "CancelarPedido",
                    HeaderText = "Cancelar",
                    Text = "Cancelar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgvPedidos.Columns.Add(btnCancelar);

                foreach (DataGridViewRow row in dgvPedidos.Rows)
                {
                    int estadoId = Convert.ToInt32(row.Cells["EstadoID"].Value);

                    // Solo habilitar Aceptar si estado es aceptado (2)
                    row.Cells["AceptarPedido"].ReadOnly = estadoId != 2;
                    row.Cells["AceptarPedido"].Style.ForeColor = estadoId == 2 ? Color.Black : Color.Gray;

                    // Solo habilitar Cancelar si estado es aceptado (2) o pendiente (1)
                    bool canCancel = estadoId == 1 || estadoId == 2; // <-- Aquí la restricción para no permitir cancelar entregados
                    row.Cells["CancelarPedido"].ReadOnly = !canCancel;
                    row.Cells["CancelarPedido"].Style.ForeColor = canCancel ? Color.Black : Color.Gray;
                }
            }
            else if (rolId == 3) // Cliente: mostrar columna DeliveryNombre
            {
                if (dgvPedidos.Columns.Contains("DeliveryNombre"))
                {
                    dgvPedidos.Columns["DeliveryNombre"].HeaderText = "Delivery Asignado";
                    dgvPedidos.Columns["DeliveryNombre"].DisplayIndex = 6;
                }
            }

            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPedidos.ScrollBars = ScrollBars.Both;
        }

        private void DgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rolId = Program.UsuarioLogueado.RoleID;
            if (e.RowIndex < 0) return;

            if (rolId == 1 || rolId == 4) // Admin o Proveedor
            {
                var columnName = dgvPedidos.Columns[e.ColumnIndex].Name;

                if (columnName == "AsignarDelivery")
                {
                    int pedidoId = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["PedidoID"].Value);
                    AsignarDelivery(pedidoId);
                }
            }

            if (rolId == 2) // Delivery - aceptar o cancelar
            {
                var columnName = dgvPedidos.Columns[e.ColumnIndex].Name;
                int pedidoId = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["PedidoID"].Value);
                int estadoId = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["EstadoID"].Value);

                if (columnName == "AceptarPedido" && estadoId == 2) // Sólo aceptar si está en proceso (asignado)
                {
                    bool exito = _pedidoService.CambiarEstadoPedido(pedidoId, 3, DateTime.Now); // 3 = entregado + fecha y hora actual
                    if (exito)
                    {
                        MessageBox.Show("Pedido entregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPedidosEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al entregar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (columnName == "CancelarPedido" && (estadoId == 1 || estadoId == 2)) // <-- Quité estadoId == 3 para impedir cancelar entregados
                {
                    bool exito = _pedidoService.CambiarEstadoPedido(pedidoId, 4); // 4 = cancelado
                    if (exito)
                    {
                        MessageBox.Show("Pedido cancelado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPedidosEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al cancelar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AsignarDelivery(int pedidoId)
        {
            // 👇 ESTA ES LA PARTE QUE VOS TENÉS QUE AGREGAR
            int rolId = Program.UsuarioLogueado.RoleID;
            int usuarioId = Program.UsuarioLogueado.UsuarioID;

            List<Usuario> deliveries;
            if (rolId == 4) // Proveedor
                deliveries = _pedidoService.GetDeliverysParaProveedor(usuarioId);
            else
                deliveries = _pedidoService.GetUsuariosPorRole(2);

            if (deliveries == null || deliveries.Count == 0)
            {
                MessageBox.Show("No hay deliverys disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (Form seleccionForm = new Form())
            {
                seleccionForm.Text = "Asignar Delivery";
                seleccionForm.Size = new Size(300, 150);
                seleccionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                seleccionForm.StartPosition = FormStartPosition.CenterParent;
                seleccionForm.MinimizeBox = false;
                seleccionForm.MaximizeBox = false;

                ComboBox cmbDeliveries = new ComboBox() { Left = 20, Top = 20, Width = 240 };
                cmbDeliveries.DataSource = deliveries;
                cmbDeliveries.DisplayMember = "Nombre";
                cmbDeliveries.ValueMember = "UsuarioID";

                Button btnAceptar = new Button() { Text = "Asignar", Left = 60, Width = 80, Top = 60, DialogResult = DialogResult.OK };
                Button btnCancelar = new Button() { Text = "Cancelar", Left = 150, Width = 80, Top = 60, DialogResult = DialogResult.Cancel };

                seleccionForm.Controls.Add(cmbDeliveries);
                seleccionForm.Controls.Add(btnAceptar);
                seleccionForm.Controls.Add(btnCancelar);

                seleccionForm.AcceptButton = btnAceptar;
                seleccionForm.CancelButton = btnCancelar;

                if (seleccionForm.ShowDialog() == DialogResult.OK)
                {
                    int deliveryId = (int)cmbDeliveries.SelectedValue;
                    bool resultado = _pedidoService.AsignarDeliveryYPasarEstado(pedidoId, deliveryId);
                    if (resultado)
                    {
                        MessageBox.Show("Delivery asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPedidosEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al asignar el delivery.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void CalcularTotal()
        {
            if (cmbProductos.SelectedItem is Producto producto && cmbZonas.SelectedItem is Zona zona)
            {
                int cantidad = (int)nudCantidad.Value;
                lblPrecioProducto.Text = $"Precio Producto: S/. {producto.Precio:F2}";
                lblPrecioZona.Text = $"Precio Delivery: S/. {zona.PrecioDelivery:F2}";

                decimal total = (producto.Precio * cantidad) + zona.PrecioDelivery;
                lblTotal.Text = $"Total: S/.{total:F2}";
            }
        }

        private void BtnAgregarPedido_Click(object sender, System.EventArgs e)
        {
            if (cmbProductos.SelectedItem is not Producto producto || cmbZonas.SelectedItem is not Zona zona)
            {
                MessageBox.Show("Seleccione un producto y una zona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            int clienteId = Program.UsuarioLogueado.UsuarioID;

            var exito = _pedidoService.RegistrarPedido(clienteId, producto.ProductoID, zona.ZonaID, cantidad);

            if (exito)
            {
                MessageBox.Show("Pedido registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPedidosEnGrid();
                tabControlPedidos.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("Error al registrar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}