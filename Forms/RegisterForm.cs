using System;
using System.Windows.Forms;
using DeliveryAppGrupo0008.Services;

namespace DeliveryAppGrupo0008.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService;

        public RegisterForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error");
                return;
            }

            // Por simplicidad, asignamos RoleID = 3 (Cliente)
            bool result = _authService.Register(nombre, email, password, 3);

            if (result)
            {
                MessageBox.Show("Usuario registrado correctamente.", "Éxito");
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario ya existe.", "Error");
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
