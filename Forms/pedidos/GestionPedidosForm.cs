using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;

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

            // Enlazar eventos
            cmbProductos.SelectedIndexChanged += (s, e) => CalcularTotal();
            cmbZonas.SelectedIndexChanged += (s, e) => CalcularTotal();
            nudCantidad.ValueChanged += (s, e) => CalcularTotal();
            btnAgregarPedido.Click += BtnAgregarPedido_Click;
        }

        private void GestionPedidosForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarPedidosEnGrid();
            btnAgregarPedido.Enabled = Program.UsuarioLogueado?.RoleID == 3;
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
            var pedidos = _pedidoService.GetPedidos()
                .Select(p => new
                {
                    p.PedidoID,
                    Cliente = p.Cliente?.Nombre,
                    Productos = string.Join(", ", p.Detalles.Select(d => d.Producto?.Nombre)),
                    Proveedores = string.Join(", ", p.Detalles.Select(d => d.Producto?.Proveedor?.Nombre).Distinct()),
                    Zona = p.Zona?.Nombre,
                    Estado = p.Estado?.Estado,
                    p.FechaPedido,
                    FechaEntrega = p.FechaEntrega?.ToString("dd/MM/yyyy") ?? "Pendiente",
                    Total = p.Total.ToString("C")
                }).ToList();

            dgvPedidos.DataSource = pedidos;
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

        private void BtnAgregarPedido_Click(object sender, EventArgs e)
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
