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
        private Label lblZona;
        private Label lblPrecioProducto;
        private Label lblPrecioZona;
        private Label lblTotal;
        private Button btnAgregarPedido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlPedidos = new TabControl();
            this.tabPageLista = new TabPage();
            this.dgvPedidos = new DataGridView();
            this.tabPageRegistro = new TabPage();
            this.cmbProductos = new ComboBox();
            this.cmbZonas = new ComboBox();
            this.lblProducto = new Label();
            this.lblZona = new Label();
            this.lblPrecioProducto = new Label();
            this.lblPrecioZona = new Label();
            this.lblTotal = new Label();
            this.btnAgregarPedido = new Button();

            this.tabControlPedidos.SuspendLayout();
            this.tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.tabPageRegistro.SuspendLayout();
            this.SuspendLayout();

            // tabControlPedidos
            this.tabControlPedidos.Controls.Add(this.tabPageLista);
            this.tabControlPedidos.Controls.Add(this.tabPageRegistro);
            this.tabControlPedidos.Dock = DockStyle.Fill;
            this.tabControlPedidos.Size = new System.Drawing.Size(800, 450);
            this.tabControlPedidos.SelectedIndex = 0;

            // tabPageLista
            this.tabPageLista.Controls.Add(this.dgvPedidos);
            this.tabPageLista.Text = "Lista de Pedidos";
            this.dgvPedidos.Dock = DockStyle.Fill;

            // tabPageRegistro
            this.nudCantidad = new NumericUpDown();

            // Configurar posición y tamaño (ajusta según prefieras)
            this.nudCantidad.Location = new System.Drawing.Point(150, 100);
            this.nudCantidad.Size = new System.Drawing.Size(60, 23);
            this.nudCantidad.Minimum = 1;
            this.nudCantidad.Maximum = 100;
            this.nudCantidad.Value = 1;

            // Agregar al tabPageRegistro
            this.tabPageRegistro.Controls.Add(this.nudCantidad);


            this.tabPageRegistro.Controls.Add(this.cmbProductos);
            this.tabPageRegistro.Controls.Add(this.cmbZonas);
            this.tabPageRegistro.Controls.Add(this.lblProducto);
            this.tabPageRegistro.Controls.Add(this.lblZona);
            this.tabPageRegistro.Controls.Add(this.lblPrecioProducto);
            this.tabPageRegistro.Controls.Add(this.lblPrecioZona);
            this.tabPageRegistro.Controls.Add(this.lblTotal);
            this.tabPageRegistro.Controls.Add(this.btnAgregarPedido);
            this.tabPageRegistro.Text = "Registrar Pedido";

            // Labels
            this.lblProducto.Text = "Producto:";
            this.lblProducto.Location = new System.Drawing.Point(30, 30);

            this.lblZona.Text = "Zona:";
            this.lblZona.Location = new System.Drawing.Point(30, 70);

            this.lblPrecioProducto.Text = "Precio Producto: $0.00";
            this.lblPrecioProducto.Location = new System.Drawing.Point(30, 110);

            this.lblPrecioZona.Text = "Precio Delivery: $0.00";
            this.lblPrecioZona.Location = new System.Drawing.Point(30, 140);

            this.lblTotal.Text = "Total: $0.00";
            this.lblTotal.Location = new System.Drawing.Point(30, 180);

            // ComboBoxes
            this.cmbProductos.Location = new System.Drawing.Point(150, 27);
            this.cmbProductos.Size = new System.Drawing.Size(200, 23);

            this.cmbZonas.Location = new System.Drawing.Point(150, 67);
            this.cmbZonas.Size = new System.Drawing.Size(200, 23);

            // Button
            this.btnAgregarPedido.Text = "Registrar Pedido";
            this.btnAgregarPedido.Location = new System.Drawing.Point(150, 220);
            this.btnAgregarPedido.Size = new System.Drawing.Size(200, 30);

            // Final
            this.Controls.Add(this.tabControlPedidos);
            this.Name = "GestionPedidosForm";
            this.Text = "Gestión de Pedidos";
            this.Load += new EventHandler(this.GestionPedidosForm_Load);

            this.tabControlPedidos.ResumeLayout(false);
            this.tabPageLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.tabPageRegistro.ResumeLayout(false);
            this.tabPageRegistro.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
