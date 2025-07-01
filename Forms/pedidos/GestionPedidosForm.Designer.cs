namespace DeliveryAppGrupo0008.Forms.pedidos
{
    partial class GestionPedidosForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControlPedidos;
        private TabPage tabPageLista;
        private TabPage tabPageRegistro;
        private DataGridView dgvPedidos;
        private ComboBox cmbProductos;
        private ComboBox cmbZonas;
        private Label lblProducto;
        private Label lblReferencia;
        private TextBox txtReferencia;
        private Label lblZona;
        private Label lblPrecioProducto;
        private Label lblPrecioZona;
        private Label lblTotal;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregarPedido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControlPedidos = new TabControl();
            tabPageLista = new TabPage();
            dgvPedidos = new DataGridView();
            tabPageRegistro = new TabPage();
            cmbProductos = new ComboBox();
            cmbZonas = new ComboBox();
            nudCantidad = new NumericUpDown();
            lblProducto = new Label();
            lblZona = new Label();
            lblReferencia = new Label();
            lblCantidad = new Label();
            lblPrecioProducto = new Label();
            lblPrecioZona = new Label();
            lblTotal = new Label();
            btnAgregarPedido = new Button();
            txtReferencia = new TextBox();
            tabControlPedidos.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            tabPageRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // tabControlPedidos
            // 
            tabControlPedidos.Controls.Add(tabPageLista);
            tabControlPedidos.Controls.Add(tabPageRegistro);
            tabControlPedidos.Dock = DockStyle.Fill;
            tabControlPedidos.Location = new Point(0, 0);
            tabControlPedidos.Name = "tabControlPedidos";
            tabControlPedidos.SelectedIndex = 0;
            tabControlPedidos.Size = new Size(680, 471);
            tabControlPedidos.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(dgvPedidos);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(276, 233);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista de Pedidos";
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Dock = DockStyle.Fill;
            dgvPedidos.Location = new Point(0, 0);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Size = new Size(276, 233);
            dgvPedidos.TabIndex = 0;
            // 
            // tabPageRegistro
            // 
            tabPageRegistro.Controls.Add(cmbProductos);
            tabPageRegistro.Controls.Add(cmbZonas);
            tabPageRegistro.Controls.Add(nudCantidad);
            tabPageRegistro.Controls.Add(lblProducto);
            tabPageRegistro.Controls.Add(lblZona);
            tabPageRegistro.Controls.Add(lblReferencia);
            tabPageRegistro.Controls.Add(lblCantidad);
            tabPageRegistro.Controls.Add(lblPrecioProducto);
            tabPageRegistro.Controls.Add(lblPrecioZona);
            tabPageRegistro.Controls.Add(lblTotal);
            tabPageRegistro.Controls.Add(btnAgregarPedido);
            tabPageRegistro.Controls.Add(txtReferencia);
            tabPageRegistro.Location = new Point(4, 24);
            tabPageRegistro.Name = "tabPageRegistro";
            tabPageRegistro.Size = new Size(672, 443);
            tabPageRegistro.TabIndex = 1;
            tabPageRegistro.Text = "Registrar Pedido";
            // 
            // cmbProductos
            // 
            cmbProductos.Location = new Point(190, 22);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(200, 23);
            cmbProductos.TabIndex = 0;
            // 
            // cmbZonas
            // 
            cmbZonas.Location = new Point(190, 62);
            cmbZonas.Name = "cmbZonas";
            cmbZonas.Size = new Size(200, 23);
            cmbZonas.TabIndex = 1;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(190, 157);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(60, 23);
            nudCantidad.TabIndex = 2;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(30, 30);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 3;
            lblProducto.Text = "Producto:";
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(30, 70);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(37, 15);
            lblZona.TabIndex = 4;
            lblZona.Text = "Zona:";
            // 
            // lblReferencia
            // 
            lblReferencia.AutoSize = true;
            lblReferencia.Location = new Point(30, 115);
            lblReferencia.Name = "lblReferencia";
            lblReferencia.Size = new Size(134, 15);
            lblReferencia.TabIndex = 5;
            lblReferencia.Text = "Dirección de Referencia:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(30, 165);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 6;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblPrecioProducto
            // 
            lblPrecioProducto.AutoSize = true;
            lblPrecioProducto.Location = new Point(28, 201);
            lblPrecioProducto.Name = "lblPrecioProducto";
            lblPrecioProducto.Size = new Size(136, 15);
            lblPrecioProducto.TabIndex = 7;
            lblPrecioProducto.Text = "Precio Producto: S/. 0.00";
            // 
            // lblPrecioZona
            // 
            lblPrecioZona.AutoSize = true;
            lblPrecioZona.Location = new Point(30, 236);
            lblPrecioZona.Name = "lblPrecioZona";
            lblPrecioZona.Size = new Size(129, 15);
            lblPrecioZona.TabIndex = 8;
            lblPrecioZona.Text = "Precio Delivery: S/. 0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(30, 280);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 15);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total: S/. 0.00";
            // 
            // btnAgregarPedido
            // 
            btnAgregarPedido.Location = new Point(151, 323);
            btnAgregarPedido.Name = "btnAgregarPedido";
            btnAgregarPedido.Size = new Size(200, 30);
            btnAgregarPedido.TabIndex = 10;
            btnAgregarPedido.Text = "Registrar Pedido";
            // 
            // txtReferencia
            // 
            txtReferencia.Location = new Point(190, 107);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.Size = new Size(300, 23);
            txtReferencia.TabIndex = 11;
            // 
            // GestionPedidosForm
            // 
            ClientSize = new Size(680, 471);
            Controls.Add(tabControlPedidos);
            Name = "GestionPedidosForm";
            Text = "Gestión de Pedidos";
            Load += GestionPedidosForm_Load;
            tabControlPedidos.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            tabPageRegistro.ResumeLayout(false);
            tabPageRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
        }
    }
}
