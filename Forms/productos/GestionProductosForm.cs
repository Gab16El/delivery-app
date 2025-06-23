using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeliveryAppGrupo0008.Forms.productos
{
    public partial class GestionProductosForm : Form
    {
        private ProductService _productService;
        private UserService _userService;

        private List<Producto> listaProductos = new();

        public GestionProductosForm(ProductService productService, UserService userService)
        {
            InitializeComponent();
            _productService = productService;
            _userService = userService;
        }

        private void GestionProductosForm_Load(object sender, EventArgs e)
        {
            CargarProductosEnGrid();
            CargarProveedoresEnCombo();
        }

        private void CargarProductosEnGrid()
        {
            var productos = _productService.GetProductosConProveedor()
                .Select(p => new
                {
                    p.ProductoID,
                    p.Nombre,
                    p.Descripcion,
                    p.Precio,
                    p.ProveedorID,
                    NombreProveedor = p.Proveedor?.Nombre ?? ""
                })
                .ToList();

            dgvProductos.DataSource = productos;

            dgvProductos.Columns["ProductoID"].HeaderText = "ID Producto";
            dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
            dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvProductos.Columns["Precio"].HeaderText = "Precio";
            dgvProductos.Columns["ProveedorID"].HeaderText = "ID Proveedor";
            dgvProductos.Columns["NombreProveedor"].HeaderText = "Proveedor";
        }

        private void CargarProveedoresEnCombo()
        {
            var proveedores = _userService.GetProveedores();
            cmbProveedores.DataSource = proveedores;
            cmbProveedores.DisplayMember = "Nombre";
            cmbProveedores.ValueMember = "UsuarioID";
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

            var agregado = _productService.RegistrarProducto(proveedorId, nombre, descripcion, precio);

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
