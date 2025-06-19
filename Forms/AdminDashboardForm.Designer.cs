using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeliveryAppGrupo0008.Forms
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        
        private Panel sidebar;
        private Button btnGestionUsuarios;
        private Button btnGestionProveedores;
        private Button btnGestionProductos;
        private Button btnGestionZonas;
        private Button btnGestionPedidos;

        private Button btnReportes;
        private Button btnCerrarSesion;
        private ImageList iconList;


        private void ConfigurarBoton(Button btn, string texto, string iconKey)
        {
            btn.BackColor = Color.FromArgb(45, 45, 45);
            btn.Dock = DockStyle.Top;
            btn.Margin = new Padding(0,15, 0, 15);
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10F);

            btn.ForeColor = Color.White;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.ImageKey = iconKey;
            btn.ImageList = iconList;
            btn.Text = $"   {texto}";
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.UseVisualStyleBackColor = false;
        }


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
            components = new System.ComponentModel.Container();
            panelMain = new Panel();
            sidebar = new Panel();
            iconList = new ImageList(components);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // Botones
            btnGestionUsuarios = new Button();
            btnGestionProveedores = new Button();
            btnGestionProductos = new Button();
            btnGestionZonas = new Button();
            btnGestionPedidos = new Button();
            btnReportes = new Button();
            btnCerrarSesion = new Button();



            sidebar.SuspendLayout();
            SuspendLayout();

            // lblWelcome
            panelMain.Location = new Point(200, 20);
            panelMain.Size = new Size(600, 400);
            panelMain.BorderStyle = BorderStyle.FixedSingle;  // Opcional: para que se note el área
            panelMain.BackColor = Color.WhiteSmoke;
            panelMain.Name = "panelMain";
            Controls.Add(panelMain);

            // sidebar
            sidebar.AutoScroll = true;
            sidebar.BackColor = Color.FromArgb(30, 30, 30);
            sidebar.Controls.Add(btnGestionUsuarios);
            sidebar.Controls.Add(btnGestionProveedores);
            sidebar.Controls.Add(btnGestionProductos);
            sidebar.Controls.Add(btnGestionZonas);
            sidebar.Controls.Add(btnGestionPedidos);
            sidebar.Controls.Add(btnReportes);
            sidebar.Controls.Add(btnCerrarSesion);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(200, 450);
            sidebar.TabIndex = 0;

            // btnCerrarSesion
            btnCerrarSesion.BackColor = Color.FromArgb(192, 57, 43);
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.ImageKey = "logout";
            btnCerrarSesion.ImageList = iconList;
            btnCerrarSesion.Location = new Point(0, 400);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(200, 50);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "   Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // AdminDashboardForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(sidebar);
            Controls.Add(lblWelcome);
            Name = "AdminDashboardForm";
            Text = "Panel de Administrador";
            Load += AdminDashboardForm_Load;
            sidebar.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
    }
}