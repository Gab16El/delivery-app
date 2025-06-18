namespace DeliveryAppGrupo0008
{


    partial class Form1
    {
        private DataGridView dgvClientes;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientes(); // o cualquier lógica que desees al cargar el formulario
        }

        private void InitializeComponent()
        {
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.Location = new Point(0, 0);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.Size = new Size(800, 450);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // Form1
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(dgvClientes);
            Name = "Form1";
            Text = "Listado de Clientes";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }
    }
}
