namespace DeliveryAppGrupo0008.Forms.usuarios
{
    partial class GestionUsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControlUsuarios;
        private System.Windows.Forms.TabPage tabPageLista;
        private System.Windows.Forms.TabPage tabPageAgregar;

        private System.Windows.Forms.Panel panelUsuarios;
        private System.Windows.Forms.Panel panelFiltro;

        private System.Windows.Forms.DataGridView dgvUsuarios;

        private System.Windows.Forms.ComboBox cmbFiltroRol;
        private System.Windows.Forms.ComboBox cmbRol;

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;

        private System.Windows.Forms.Button btnAgregarUsuario;

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
            tabControlUsuarios = new TabControl();
            tabPageLista = new TabPage();
            panelFiltro = new Panel();
            cmbFiltroRol = new ComboBox();
            panelUsuarios = new Panel();
            dgvUsuarios = new DataGridView();
            tabPageAgregar = new TabPage();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblRole = new Label();
            cmbRol = new ComboBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            btnAgregarUsuario = new Button();
            tabControlUsuarios.SuspendLayout();
            tabPageLista.SuspendLayout();
            panelFiltro.SuspendLayout();
            panelUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tabPageAgregar.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlUsuarios
            // 
            tabControlUsuarios.Controls.Add(tabPageLista);
            tabControlUsuarios.Controls.Add(tabPageAgregar);
            tabControlUsuarios.Dock = DockStyle.Fill;
            tabControlUsuarios.Location = new Point(0, 0);
            tabControlUsuarios.Name = "tabControlUsuarios";
            tabControlUsuarios.SelectedIndex = 0;
            tabControlUsuarios.Size = new Size(800, 450);
            tabControlUsuarios.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(panelUsuarios);
            tabPageLista.Controls.Add(panelFiltro);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(792, 422);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista de Usuarios";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // panelFiltro
            // 
            panelFiltro.Controls.Add(cmbFiltroRol);
            panelFiltro.Dock = DockStyle.Top;
            panelFiltro.Location = new Point(3, 3);
            panelFiltro.Name = "panelFiltro";
            panelFiltro.Padding = new Padding(10);
            panelFiltro.Size = new Size(786, 40);
            panelFiltro.TabIndex = 0;
            // 
            // cmbFiltroRol
            // 
            cmbFiltroRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroRol.Location = new Point(10, 10);
            cmbFiltroRol.Name = "cmbFiltroRol";
            cmbFiltroRol.Size = new Size(200, 23);
            cmbFiltroRol.TabIndex = 0;
            cmbFiltroRol.SelectedIndexChanged += CmbFiltroRol_SelectedIndexChanged;
            // 
            // panelUsuarios
            // 
            panelUsuarios.BorderStyle = BorderStyle.FixedSingle;
            panelUsuarios.Controls.Add(dgvUsuarios);
            panelUsuarios.Dock = DockStyle.Fill;
            panelUsuarios.Location = new Point(3, 3);
            panelUsuarios.Margin = new Padding(20);
            panelUsuarios.Name = "panelUsuarios";
            panelUsuarios.Size = new Size(786, 416);
            panelUsuarios.TabIndex = 1;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(0, 0);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(784, 414);
            dgvUsuarios.TabIndex = 0;
            // 
            // tabPageAgregar
            // 
            tabPageAgregar.Controls.Add(lblNombre);
            tabPageAgregar.Controls.Add(txtNombre);
            tabPageAgregar.Controls.Add(lblEmail);
            tabPageAgregar.Controls.Add(txtEmail);
            tabPageAgregar.Controls.Add(lblPassword);
            tabPageAgregar.Controls.Add(txtPassword);
            tabPageAgregar.Controls.Add(lblConfirmPassword);
            tabPageAgregar.Controls.Add(txtConfirmPassword);
            tabPageAgregar.Controls.Add(lblRole);
            tabPageAgregar.Controls.Add(cmbRol);
            tabPageAgregar.Controls.Add(lblTelefono);
            tabPageAgregar.Controls.Add(txtTelefono);
            tabPageAgregar.Controls.Add(lblDireccion);
            tabPageAgregar.Controls.Add(txtDireccion);
            tabPageAgregar.Controls.Add(btnAgregarUsuario);
            tabPageAgregar.Location = new Point(4, 24);
            tabPageAgregar.Name = "tabPageAgregar";
            tabPageAgregar.Padding = new Padding(10);
            tabPageAgregar.Size = new Size(792, 422);
            tabPageAgregar.TabIndex = 1;
            tabPageAgregar.Text = "Agregar Usuario";
            tabPageAgregar.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(40, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(161, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(40, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(161, 62);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 163);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(161, 145);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 5;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(40, 280);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(125, 15);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirmar contraseña:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(161, 262);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(200, 23);
            txtConfirmPassword.TabIndex = 7;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(40, 125);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(27, 15);
            lblRole.TabIndex = 8;
            lblRole.Text = "Rol:";
            // 
            // cmbRol
            // 
            cmbRol.Location = new Point(161, 107);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(200, 23);
            cmbRol.TabIndex = 9;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(40, 200);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 10;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(161, 182);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 11;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(40, 240);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 12;
            lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(161, 222);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 23);
            txtDireccion.TabIndex = 13;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Location = new Point(98, 310);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(157, 30);
            btnAgregarUsuario.TabIndex = 14;
            btnAgregarUsuario.Text = "Agregar Usuario";
            btnAgregarUsuario.Click += BtnAgregarUsuario_Click;
            // 
            // GestionUsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlUsuarios);
            Name = "GestionUsuariosForm";
            Text = "Gestión de Usuarios";
            Load += GestionUsuariosForm_Load;
            tabControlUsuarios.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            panelFiltro.ResumeLayout(false);
            panelUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tabPageAgregar.ResumeLayout(false);
            tabPageAgregar.PerformLayout();
            ResumeLayout(false);
        }
    }
}
