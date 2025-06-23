using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;
using Microsoft.EntityFrameworkCore.Internal;

namespace DeliveryAppGrupo0008.Forms
{
    public partial class AdminDashboardForm : Form
    {
        private Usuario _usuario;
        private Panel panelMain;
        private Label lblWelcome;

        private DeliveryContext _context;
        private UserService _userService;
        private ProductService _productService;

        public AdminDashboardForm(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            Text = "Panel de Administrador";

            _context = Program.DbContext;
            _userService = new UserService(_context);
            _productService = new ProductService(_context);

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            ConfigurarBotones();
            MostrarBienvenida();
            btnGestionUsuarios.Click += BtnGestionUsuarios_Click;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void BtnGestionUsuarios_Click(object sender, EventArgs e)
        {
            var gestionUsuariosForm = new DeliveryAppGrupo0008.Forms.usuarios.GestionUsuariosForm(_userService);
            CargarModuloEnPanel(gestionUsuariosForm);
        }


        private void ConfigurarBotones()
        {
            ConfigurarBoton(btnGestionUsuarios, "Usuarios", "usuarios");
            ConfigurarBoton(btnGestionProductos, "Productos", "productos");
            ConfigurarBoton(btnGestionZonas, "Zonas/Rutas", "zonas");
            ConfigurarBoton(btnGestionPedidos, "Pedidos", "pedidos");
            ConfigurarBoton(btnReportes, "Reportes", "reportes");

            btnGestionUsuarios.Click += (s, e) =>
            {
                var gestionUsuariosForm = new DeliveryAppGrupo0008.Forms.usuarios.GestionUsuariosForm(_userService);
                CargarModuloEnPanel(gestionUsuariosForm);
            };

            btnGestionProductos.Click += (s, e) =>
            {
                var gestioProductosForm = new DeliveryAppGrupo0008.Forms.productos.GestionProductosForm(_productService, _userService);
                CargarModuloEnPanel(gestioProductosForm);
            };
        }

        private void CargarModuloEnPanel(Form modulo)
        {
            // Limpia controles previos
            panelMain.Controls.Clear();

            // Configura el formulario para mostrarse como control dentro del panel
            modulo.TopLevel = false;
            modulo.FormBorderStyle = FormBorderStyle.None;
            modulo.Dock = DockStyle.Fill;

            panelMain.Controls.Add(modulo);
            modulo.Show();
        }


        private void MostrarBienvenida()
        {
            panelMain.Controls.Clear();

            lblWelcome = new Label();
            lblWelcome.Text = "Bienvenido Administrador";
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Dock = DockStyle.Fill;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;

            panelMain.Controls.Add(lblWelcome);

        }
    }
}
