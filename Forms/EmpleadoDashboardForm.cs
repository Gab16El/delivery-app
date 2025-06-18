using DeliveryAppGrupo0008.Models;

namespace DeliveryAppGrupo0008.Forms
{
    public partial class EmpleadoDashboardForm : Form
    {
        private Usuario _usuario;

        public EmpleadoDashboardForm(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
            Text = "Panel de Trabajadores";
        
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmpleadoDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Bienvenido Trabajador";
        }

    }
}
