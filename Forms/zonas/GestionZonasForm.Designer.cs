namespace DeliveryAppGrupo0008.Forms.zonas
{
    partial class GestionZonasForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControlZonas;
        private TabPage tabPageLista;
        private TabPage tabPageAgregar;
        private DataGridView dgvZonas;

        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblPrecioDelivery;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtPrecioDelivery;
        private Button btnAgregarZona;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControlZonas = new TabControl();
            tabPageLista = new TabPage();
            tabPageAgregar = new TabPage();
            dgvZonas = new DataGridView();

            lblNombre = new Label();
            lblDescripcion = new Label();
            lblPrecioDelivery = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecioDelivery = new TextBox();
            btnAgregarZona = new Button();

            // 
            // tabControlZonas
            // 
            tabControlZonas.Controls.Add(tabPageLista);
            tabControlZonas.Controls.Add(tabPageAgregar);
            tabControlZonas.Dock = DockStyle.Fill;
            tabControlZonas.Location = new Point(0, 0);
            tabControlZonas.Name = "tabControlZonas";
            tabControlZonas.SelectedIndex = 0;
            tabControlZonas.Size = new Size(800, 450);

            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(dgvZonas);
            tabPageLista.Text = "Lista de Zonas";
            tabPageLista.UseVisualStyleBackColor = true;

            // 
            // dgvZonas
            // 
            dgvZonas.Dock = DockStyle.Fill;
            dgvZonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvZonas.ReadOnly = true;
            dgvZonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 
            // tabPageAgregar
            // 
            tabPageAgregar.Controls.Add(lblNombre);
            tabPageAgregar.Controls.Add(txtNombre);
            tabPageAgregar.Controls.Add(lblDescripcion);
            tabPageAgregar.Controls.Add(txtDescripcion);
            tabPageAgregar.Controls.Add(lblPrecioDelivery);
            tabPageAgregar.Controls.Add(txtPrecioDelivery);
            tabPageAgregar.Controls.Add(btnAgregarZona);
            tabPageAgregar.Text = "Agregar Zona";
            tabPageAgregar.UseVisualStyleBackColor = true;

            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(30, 30);
            txtNombre.Location = new Point(160, 30);
            txtNombre.Size = new Size(200, 23);

            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new Point(30, 70);
            txtDescripcion.Location = new Point(160, 70);
            txtDescripcion.Size = new Size(200, 23);

            lblPrecioDelivery.Text = "Precio Delivery:";
            lblPrecioDelivery.Location = new Point(30, 110);
            txtPrecioDelivery.Location = new Point(160, 110);
            txtPrecioDelivery.Size = new Size(200, 23);

            btnAgregarZona.Text = "Agregar Zona";
            btnAgregarZona.Location = new Point(160, 150);
            btnAgregarZona.Size = new Size(160, 30);

            // 
            // GestionZonasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlZonas);
            Name = "GestionZonasForm";
            Text = "Gestión de Zonas";
            Load += GestionZonasForm_Load;
        }
    }
}