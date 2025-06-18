namespace DeliveryAppGrupo0008.Forms
{
    partial class ClienteDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnHacerPedido;
        private System.Windows.Forms.Button btnVerPedidos;
        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblWelcome = new System.Windows.Forms.Label();
            btnHacerPedido = new System.Windows.Forms.Button();
            btnVerPedidos = new System.Windows.Forms.Button();
            btnCerrarSesion = new System.Windows.Forms.Button();

            SuspendLayout();

            // 
            // lblWelcome
            // 
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblWelcome.Location = new System.Drawing.Point(12, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(760, 40);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Bienvenido Cliente";
            lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnHacerPedido
            // 
            btnHacerPedido.Location = new System.Drawing.Point(300, 100);
            btnHacerPedido.Name = "btnHacerPedido";
            btnHacerPedido.Size = new System.Drawing.Size(200, 40);
            btnHacerPedido.TabIndex = 1;
            btnHacerPedido.Text = "Hacer Pedido";
            btnHacerPedido.UseVisualStyleBackColor = true;
            // btnHacerPedido.Click += btnHacerPedido_Click;

            // 
            // btnVerPedidos
            // 
            btnVerPedidos.Location = new System.Drawing.Point(300, 160);
            btnVerPedidos.Name = "btnVerPedidos";
            btnVerPedidos.Size = new System.Drawing.Size(200, 40);
            btnVerPedidos.TabIndex = 2;
            btnVerPedidos.Text = "Ver Mis Pedidos";
            btnVerPedidos.UseVisualStyleBackColor = true;
            // btnVerPedidos.Click += btnVerPedidos_Click;

            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new System.Drawing.Point(300, 220);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new System.Drawing.Size(200, 40);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // 
            // ClienteDashboardForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lblWelcome);
            Controls.Add(btnHacerPedido);
            Controls.Add(btnVerPedidos);
            Controls.Add(btnCerrarSesion);
            Name = "ClienteDashboardForm";
            Text = "Panel Cliente";
            Load += ClienteDashboardForm_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
