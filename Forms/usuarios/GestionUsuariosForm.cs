using DeliveryAppGrupo0008.Services;
using DeliveryAppGrupo0008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            CargarUsuariosEnGrid();
        }

        private void CargarUsuariosEnGrid(int roleId = 0)
        {
            var usuarios = _userService.GetUsuarios();

            if (roleId != 0)
            {
                usuarios = usuarios.Where(u => u.RoleID == roleId).ToList();
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
            }).ToList();
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
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

            bool registrado = _userService.RegistrarUsuario(nombre, email, password, roleId, telefono, direccion);

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
            cmbRol.SelectedIndex = 0;
        }

        private void CargarRolesEnComboBox()
        {
            var roles = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(2, "Cliente"),
                new KeyValuePair<int, string>(3, "Trabajador"),
                new KeyValuePair<int, string>(4, "Proveedor")
            };

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Value";
            cmbRol.ValueMember = "Key";
        }

        private void CargarFiltroRoles()
        {
            var roles = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "Todos"),
                new KeyValuePair<int, string>(3, "Trabajador"),
                new KeyValuePair<int, string>(4, "Proveedor")
            };

            cmbFiltroRol.DataSource = roles;
            cmbFiltroRol.DisplayMember = "Value";
            cmbFiltroRol.ValueMember = "Key";
            cmbFiltroRol.SelectedIndex = 0;
        }

        private void CmbFiltroRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroRol.SelectedValue is int roleId)
            {
                CargarUsuariosEnGrid(roleId);
            }
        }
    }
}
