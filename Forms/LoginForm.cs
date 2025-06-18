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

            var usuario = _authService.Login(email, password);

            if (usuario != null)
            {
                // Login correcto
                MessageBox.Show($"¡Bienvenido {usuario.Nombre} ({usuario.Role.RoleName})!", "Éxito");

                // Abre el formulario principal
                this.Hide();
                var mainForm = new Form1(); // Puedes pasar el usuario si necesitas
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas. Intente nuevamente.", "Error de login");
            }
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
