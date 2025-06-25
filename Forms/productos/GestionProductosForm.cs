using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;

namespace DeliveryAppGrupo0008.Forms.productos
{
    public partial class GestionProductosForm : Form
    {
        private ProductService _productService;
        private UserService _userService;

        public GestionProductosForm(ProductService productService, UserService userService)
        {
            InitializeComponent();
            _productService = productService;
            _userService = userService;

            btnAgregarProducto.Click += BtnAgregarProducto_Click;
        }

        private void GestionProductosForm_Load(object sender, EventArgs e)
        {
            ConfigurarSegunRol();
            CargarProductosEnGrid();
            CargarProveedoresEnCombo();
        }

        private void ConfigurarSegunRol()
        {
            int rolId = Program.UsuarioLogueado.RoleID;

            if (rolId == 1) // Admin
            {
                cmbProveedores.Enabled = true; // Puede elegir cualquier proveedor al agregar producto
            }
            else if (rolId == 4) // Proveedor
            {
                cmbProveedores.Enabled = false; // Solo puede usar su propio proveedor
            }
            else
            {
                // Otros roles no pueden gestionar productos
                cmbProveedores.Enabled = false;
                btnAgregarProducto.Enabled = false;
                dgvProductos.Enabled = false;
                MessageBox.Show("No tienes permisos para gestionar productos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarProveedoresEnCombo()
        {
            var rolId = Program.UsuarioLogueado.RoleID;

            if (rolId == 1) // Admin: carga todos los proveedores
            {
                var proveedores = _userService.GetProveedores();
                cmbProveedores.DataSource = proveedores;
                cmbProveedores.DisplayMember = "Nombre";
                cmbProveedores.ValueMember = "UsuarioID";
            }
            else if (rolId == 4) // Proveedor: solo su propio proveedor
            {
                var proveedor = _userService.GetProveedores()
                    .FirstOrDefault(p => p.UsuarioID == Program.UsuarioLogueado.UsuarioID);

                cmbProveedores.DataSource = new List<Usuario> { proveedor };
                cmbProveedores.DisplayMember = "Nombre";
                cmbProveedores.ValueMember = "UsuarioID";
                cmbProveedores.SelectedValue = proveedor.UsuarioID;
            }
        }

        private void CargarProductosEnGrid()
        {
            var rolId = Program.UsuarioLogueado.RoleID;

            List<dynamic> productos;

            if (rolId == 1) // Admin: ve todos los productos con proveedor
            {
                productos = _productService.GetProductosConProveedor()
                    .Select(p => new
                    {
                        p.ProductoID,
                        p.Nombre,
                        p.Descripcion,
                        p.Precio,
                        p.ProveedorID,
                        NombreProveedor = p.Proveedor?.Nombre ?? ""
                    }).ToList<dynamic>();
            }
            else if (rolId == 4) // Proveedor: solo sus productos
            {
                int proveedorId = Program.UsuarioLogueado.UsuarioID;
                productos = _productService.GetProductosConProveedor()
                    .Where(p => p.ProveedorID == proveedorId)
                    .Select(p => new
                    {
                        p.ProductoID,
                        p.Nombre,
                        p.Descripcion,
                        p.Precio,
                        p.ProveedorID,
                        NombreProveedor = p.Proveedor?.Nombre ?? ""
                    }).ToList<dynamic>();
            }
            else
            {
                productos = new List<dynamic>();
            }

            dgvProductos.DataSource = productos;

            dgvProductos.Columns["ProductoID"].HeaderText = "ID Producto";
            dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
            dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvProductos.Columns["Precio"].HeaderText = "Precio";
            dgvProductos.Columns["ProveedorID"].HeaderText = "ID Proveedor";
            dgvProductos.Columns["NombreProveedor"].HeaderText = "Proveedor";
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            bool precioValido = decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio);
            int proveedorId = (int)cmbProveedores.SelectedValue;

            if (string.IsNullOrEmpty(nombre) || !precioValido)
            {
                MessageBox.Show("Complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rolId = Program.UsuarioLogueado.RoleID;

            // Validar permisos
            if (rolId == 4 && proveedorId != Program.UsuarioLogueado.UsuarioID)
            {
                MessageBox.Show("No puedes agregar productos para otro proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool agregado = _productService.RegistrarProducto(proveedorId, nombre, descripcion, precio);

            if (agregado)
            {
                MessageBox.Show("Producto agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                CargarProductosEnGrid();
                tabControlProductos.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("Error al agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
