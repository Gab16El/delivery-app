namespace DeliveryAppGrupo0008.Forms.reportes
{
    partial class GestionReportesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblResumen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();

            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Items.AddRange(new object[] {
            "Diario",
            "Semanal",
            "Mensual"});
            this.cmbTipoReporte.Location = new System.Drawing.Point(30, 20);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(150, 24);

            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(200, 20);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(120, 24);
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(30, 60);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Size = new System.Drawing.Size(600, 250);

            // 
            // lblResumen
            // 
            this.lblResumen.Location = new System.Drawing.Point(30, 330);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(600, 60);
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblResumen.Text = "";

            // 
            // GestionReportesForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.cmbTipoReporte);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblResumen);
            this.Name = "GestionReportesForm";
            this.Text = "Gestión de Reportes";
            this.Load += new System.EventHandler(this.GestionReportesForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
