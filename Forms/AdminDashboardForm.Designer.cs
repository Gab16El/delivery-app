namespace DeliveryAppGrupo0008.Forms
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblWelcome = new System.Windows.Forms.Label();
            btnGestionUsuarios = new System.Windows.Forms.Button();
            btnReportes = new System.Windows.Forms.Button();
            btnCerrarSesion = new System.Windows.Forms.Button();

            SuspendLayout();

            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcome.Location = new Point(12, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(760, 40);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Bienvenido Administrador";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Location = new Point(300, 100);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(200, 40);
            btnGestionUsuarios.TabIndex = 1;
            btnGestionUsuarios.Text = "Gestión de Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            // btnGestionUsuarios.Click += btnGestionUsuarios_Click;

            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(300, 160);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(200, 40);
            btnReportes.TabIndex = 2;
            btnReportes.Text = "Ver Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            // btnReportes.Click += btnReportes_Click;

            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(300, 220);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(200, 40);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWelcome);
            Controls.Add(btnGestionUsuarios);
            Controls.Add(btnReportes);
            Controls.Add(btnCerrarSesion);
            Name = "AdminDashboardForm";
            Text = "Panel de Administrador";
            Load += AdminDashboardForm_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
