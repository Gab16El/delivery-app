namespace DeliveryAppGrupo0008.Forms.productos
{
    partial class GestionProductosForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControlProductos;
        private TabPage tabPageLista;
        private TabPage tabPageAgregar;
        private DataGridView dgvProductos;

        private Label lblNombre;
        private Label lblProveedor;
        private ComboBox cmbProveedores;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Button btnAgregarProducto;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControlProductos = new TabControl();
            tabPageLista = new TabPage();
            dgvProductos = new DataGridView();
            tabPageAgregar = new TabPage();

            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            btnAgregarProducto = new Button();
            lblProveedor = new Label();
            cmbProveedores = new ComboBox();

            // 
            // tabControlProductos
            // 
            tabControlProductos.Controls.Add(tabPageLista);
            tabControlProductos.Controls.Add(tabPageAgregar);
            tabControlProductos.Dock = DockStyle.Fill;
            tabControlProductos.Location = new Point(0, 0);
            tabControlProductos.Name = "tabControlProductos";
            tabControlProductos.SelectedIndex = 0;
            tabControlProductos.Size = new Size(800, 450);
            tabControlProductos.TabIndex = 0;

            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(dgvProductos);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(792, 422);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista de Productos";
            tabPageLista.UseVisualStyleBackColor = true;

            // 
            // dgvProductos
            // 
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(3, 3);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(786, 416);
            dgvProductos.TabIndex = 0;
            dgvProductos.ScrollBars = ScrollBars.Both;

            // 
            // tabPageAgregar
            // 
            tabPageAgregar.Controls.Add(lblNombre);
            tabPageAgregar.Controls.Add(txtNombre);
            tabPageAgregar.Controls.Add(lblProveedor);
            tabPageAgregar.Controls.Add(cmbProveedores);
            tabPageAgregar.Controls.Add(lblDescripcion);
            tabPageAgregar.Controls.Add(txtDescripcion);
            tabPageAgregar.Controls.Add(lblPrecio);
            tabPageAgregar.Controls.Add(txtPrecio);
            tabPageAgregar.Controls.Add(btnAgregarProducto);
            tabPageAgregar.Location = new Point(4, 24);
            tabPageAgregar.Name = "tabPageAgregar";
            tabPageAgregar.Padding = new Padding(10);
            tabPageAgregar.Size = new Size(792, 422);
            tabPageAgregar.TabIndex = 1;
            tabPageAgregar.Text = "Agregar Producto";
            tabPageAgregar.UseVisualStyleBackColor = true;

            // 
            // Labels y TextBoxes ubicacion
            // 
            int leftLabel = 30, leftInput = 160, top = 30, step = 40;

            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(leftLabel, top);
            txtNombre.Location = new Point(leftInput, top);
            txtNombre.Size = new Size(200, 23);

            top += step;

            lblProveedor.Text = "Proveedor:";
            lblProveedor.Location = new Point(leftLabel, top);
            cmbProveedores.Location = new Point(leftInput, top);
            cmbProveedores.Size = new Size(200, 23);
            cmbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;

            top += step;

            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new Point(leftLabel, top);
            txtDescripcion.Location = new Point(leftInput, top);
            txtDescripcion.Size = new Size(200, 23);

            top += step;

            lblPrecio.Text = "Precio:";
            lblPrecio.Location = new Point(leftLabel, top);
            txtPrecio.Location = new Point(leftInput, top);
            txtPrecio.Size = new Size(200, 23);

            top += step;

            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.Location = new Point(leftInput, top + 10);
            btnAgregarProducto.Size = new Size(160, 30);

            // 
            // GestionProductosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlProductos);
            Name = "GestionProductosForm";
            Text = "Gestión de Productos";
            Load += GestionProductosForm_Load;

            tabControlProductos.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tabPageAgregar.ResumeLayout(false);
            tabPageAgregar.PerformLayout();
            ResumeLayout(false);
        }
    }
}
