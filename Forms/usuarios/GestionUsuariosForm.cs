using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;

namespace DeliveryAppGrupo0008.Forms.usuarios
{
    public partial class GestionUsuariosForm : Form
    {
        private UserService _userService;

        public GestionUsuariosForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void GestionUsuariosForm_Load(object sender, EventArgs e)
        {
            CargarRolesEnComboBox();
            CargarFiltroRoles();
            ConfigurarSegunRol();
            CargarUsuariosEnGrid();
        }

        private void ConfigurarSegunRol()
        {
            var rolId = Program.UsuarioLogueado.RoleID;

            if (rolId == 1) // Administrador
            {
                // Puede ver todos los usuarios y agregar cualquier rol
                cmbFiltroRol.Enabled = true;
                cmbRol.Enabled = true;
                // Mostrar filtro todos los roles
                CargarFiltroRolesCompleto();
            }
            else if (rolId == 4) // Proveedor
            {
                // Solo puede ver y agregar trabajadores (RoleID=2) que pertenezcan a él
                cmbFiltroRol.Enabled = false; // No puede filtrar otros roles
                cmbRol.Enabled = true;
                cmbRol.DataSource = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(2, "Trabajador")
                };
                cmbRol.DisplayMember = "Value";
                cmbRol.ValueMember = "Key";
            }
            else
            {
                // Otros roles pueden tener restricciones similares aquí
                cmbFiltroRol.Enabled = false;
                cmbRol.Enabled = false;
            }
        }

        private void CargarRolesEnComboBox()
        {
            var roles = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(3, "Cliente"),
                new KeyValuePair<int, string>(4, "Proveedor")
            };

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Value";
            cmbRol.ValueMember = "Key";
        }

        private void CargarFiltroRoles()
        {
            // Filtro inicial para administrador
            var roles = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "Todos"),
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(2, "Trabajador"),
                new KeyValuePair<int, string>(3, "Cliente"),
                new KeyValuePair<int, string>(4, "Proveedor")
            };

            cmbFiltroRol.DataSource = roles;
            cmbFiltroRol.DisplayMember = "Value";
            cmbFiltroRol.ValueMember = "Key";
            cmbFiltroRol.SelectedIndex = 0;
        }

        private void CargarFiltroRolesCompleto()
        {
            var roles = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "Todos"),
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(2, "Trabajador"),
                new KeyValuePair<int, string>(3, "Cliente"),
                new KeyValuePair<int, string>(4, "Proveedor")
            };

            cmbFiltroRol.DataSource = roles;
            cmbFiltroRol.DisplayMember = "Value";
            cmbFiltroRol.ValueMember = "Key";
            cmbFiltroRol.SelectedIndex = 0;
        }

        private void CargarUsuariosEnGrid(int roleId = 0)
        {
            int usuarioRolId = Program.UsuarioLogueado.RoleID;

            if (usuarioRolId == 4)
            {
                // Proveedor solo ve sus trabajadores
                dgvUsuarios.DataSource = _userService.GetTrabajadoresDeProveedor(Program.UsuarioLogueado.UsuarioID)
                    .Select(u => new
                    {
                        u.UsuarioID,
                        u.Nombre,
                        u.Email,
                        Rol = u.Role.RoleName,
                        FechaRegistro = u.FechaRegistro.ToString("dd/MM/yyyy"),
                        u.Telefono,
                        u.Direccion
                    }).ToList();
            }
            else
            {
                List<Usuario> usuarios;

                if (roleId == 0)
                {
                    // Todos los usuarios sin filtro
                    usuarios = _userService.GetUsuarios();
                }
                else
                {
                    // Solo usuarios con RoleID == roleId
                    usuarios = _userService.GetUsuarios()
                        .Where(u => u.RoleID == roleId)
                        .ToList();
                }

                dgvUsuarios.DataSource = usuarios.Select(u => new
                {
                    u.UsuarioID,
                    u.Nombre,
                    u.Email,
                    Rol = u.Role.RoleName,
                    FechaRegistro = u.FechaRegistro.ToString("dd/MM/yyyy"),
                    u.Telefono,
                    u.Direccion,
                    Proveedor = u.ProveedorID.HasValue ? _userService.GetUsuarios().FirstOrDefault(p => p.UsuarioID == u.ProveedorID.Value)?.Nombre : ""
                }).ToList();
            }
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || cmbRol.SelectedItem == null
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)
                || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roleId = (int)cmbRol.SelectedValue;

            bool registrado = false;

            if (Program.UsuarioLogueado.RoleID == 4)
            {
                // Solo puede agregar trabajadores para sí mismo
                if (roleId != 2)
                {
                    MessageBox.Show("Los proveedores solo pueden agregar trabajadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                registrado = _userService.RegistrarTrabajador(nombre, email, password, telefono, direccion, Program.UsuarioLogueado.UsuarioID);
            }
            else if (Program.UsuarioLogueado.RoleID == 1) // Admin
            {
                // Puede agregar cualquier usuario
                registrado = _userService.RegistrarUsuario(nombre, email, password, roleId, telefono, direccion);
            }
            else
            {
                MessageBox.Show("No tienes permisos para agregar usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (registrado)
            {
                MessageBox.Show("Usuario registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCamposAgregar();
                CargarUsuariosEnGrid();
                tabControlUsuarios.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("El email ya está registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposAgregar()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();

            if (Program.UsuarioLogueado.RoleID == 4)
            {
                // Si es proveedor, solo hay un rol posible, poner seleccionado ese rol
                cmbRol.SelectedValue = 3; // Trabajador
            }
            else
            {
                cmbRol.SelectedIndex = 0;
            }
        }

        private void CmbFiltroRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroRol.SelectedValue is int roleId)
            {
                CargarUsuariosEnGrid(roleId);
            }
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}