using DeliveryAppGrupo0008.Models;

namespace DeliveryAppGrupo0008.Forms
{
    public partial class AdminDashboardForm : Form
    {
        private Usuario _usuario;

        public AdminDashboardForm(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            Text = "Panel de Administrador";

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Bienvenido Administrador";
        }
    }
}
