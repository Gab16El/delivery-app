using System;
using System.Windows.Forms;
using DeliveryAppGrupo0008.Services;
using DeliveryAppGrupo0008.Models;

namespace DeliveryAppGrupo0008.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public LoginForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            var user = _authService.Login(email, password);

            if (user == null)
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
                return;
            }

            Program.UsuarioLogueado = user;
            // Redireccionar según el rol
            Form dashboardForm;

            if (_authService.IsAdmin(user))
            {
                dashboardForm = new AdminDashboardForm(user); // pasar usuario si querés
            }
            else if (_authService.IsEmpleado(user))
            {
                dashboardForm = new EmpleadoDashboardForm(user);
            }
            else if (_authService.IsCliente(user))
            {
                dashboardForm = new ClienteDashboardForm(user);
            }
            else if (_authService.isProveedor(user)) 
            {
                dashboardForm = new ProveedorDashboardForm(user);
            }
            else
            {
                MessageBox.Show("Rol desconocido.");
                return;
            }

            this.Hide();
            dashboardForm.FormClosed += (s, args) => this.Close();
            dashboardForm.Show();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
