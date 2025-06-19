
using DeliveryAppGrupo0008.Services;
using DeliveryAppGrupo0008.Models;

namespace DeliveryAppGrupo0008.Forms.usuarios
{
    public partial class GestionUsuariosForm : Form
    {

        private UserService _userService;

        private List<Usuario> listaUsuarios = new List<Usuario>();

        public GestionUsuariosForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;


        }

        private void GestionUsuariosForm_Load(object sender, EventArgs e)
        {
            CargarUsuariosEnGrid();
            CargarRolesEnComboBox();
        }

        private void CargarUsuariosEnGrid()
        {
            var usuarios = _userService.GetUsuarios();

            dgvUsuarios.DataSource = usuarios.Select(u => new
            {
                u.Nombre,
                u.Email,
                Rol = u.Role.RoleName,           // 👈 aquí usamos el nombre del rol
                FechaRegistro = u.FechaRegistro
            }).ToList();
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = "default123"; // o permitir ingresar uno

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roleId = (int)cmbRol.SelectedValue;

            bool registrado = _userService.RegistrarUsuario(nombre, email, password, roleId);

            if (registrado)
            {
                MessageBox.Show("Usuario registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Text = "";
                txtEmail.Text = "";
                cmbRol.SelectedIndex = 0;
                CargarUsuariosEnGrid();
                tabControlUsuarios.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("El email ya está registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRolesEnComboBox()
        {
            if (cmbRol == null)
            {
                MessageBox.Show("cmbRol es null. Verifica que lo hayas agregado al formulario.");
                return;
            }

            var roles = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(2, "Trabajador"),
                new KeyValuePair<int, string>(3, "Cliente")
            };

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Value";
            cmbRol.ValueMember = "Key";
        }

        private void tabPageAgregar_Click(object sender, EventArgs e)
        {

        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }
    }

}
