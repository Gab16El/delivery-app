namespace DeliveryAppGrupo0008.Forms.usuarios
{
    partial class GestionUsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.ComboBox cmbFiltroRol;

        private System.Windows.Forms.TabControl tabControlUsuarios;
        private System.Windows.Forms.TabPage tabPageLista;
        private System.Windows.Forms.TabPage tabPageAgregar;

        private System.Windows.Forms.DataGridView dgvUsuarios;

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
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.cmbFiltroRol = new System.Windows.Forms.ComboBox();

            this.tabControlUsuarios = new System.Windows.Forms.TabControl();
            this.tabPageLista = new System.Windows.Forms.TabPage();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tabPageAgregar = new System.Windows.Forms.TabPage();

            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();

            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();

            this.lblRole = new System.Windows.Forms.Label();

            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();

            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();

            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();

            this.btnAgregarUsuario = new System.Windows.Forms.Button();

            this.tabControlUsuarios.SuspendLayout();
            this.tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabPageAgregar.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlUsuarios
            // 
            this.tabControlUsuarios.Controls.Add(this.tabPageLista);
            this.tabControlUsuarios.Controls.Add(this.tabPageAgregar);
            this.tabControlUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tabControlUsuarios.Name = "tabControlUsuarios";
            this.tabControlUsuarios.SelectedIndex = 0;
            this.tabControlUsuarios.Size = new System.Drawing.Size(800, 450);
            this.tabControlUsuarios.TabIndex = 0;

            // 
            // tabPageLista
            // 
            this.tabPageLista.Controls.Add(this.cmbFiltroRol);
            this.tabPageLista.Controls.Add(this.dgvUsuarios);
            this.tabPageLista.Location = new System.Drawing.Point(4, 24);
            this.tabPageLista.Name = "tabPageLista";
            this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLista.Size = new System.Drawing.Size(792, 422);
            this.tabPageLista.TabIndex = 0;
            this.tabPageLista.Text = "Lista de Usuarios";
            this.tabPageLista.UseVisualStyleBackColor = true;

            // 
            // cmbFiltroRol
            // 
            this.cmbFiltroRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroRol.Location = new System.Drawing.Point(10, 10);
            this.cmbFiltroRol.Name = "cmbFiltroRol";
            this.cmbFiltroRol.Size = new System.Drawing.Size(200, 23);
            this.cmbFiltroRol.TabIndex = 1;
            this.cmbFiltroRol.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroRol_SelectedIndexChanged);

            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.Location = new System.Drawing.Point(10, 40);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(770, 370);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // tabPageAgregar
            // 
            this.tabPageAgregar.Controls.Add(this.lblNombre);
            this.tabPageAgregar.Controls.Add(this.txtNombre);
            this.tabPageAgregar.Controls.Add(this.lblEmail);
            this.tabPageAgregar.Controls.Add(this.txtEmail);
            this.tabPageAgregar.Controls.Add(this.lblPassword);
            this.tabPageAgregar.Controls.Add(this.txtPassword);
            this.tabPageAgregar.Controls.Add(this.lblRole);
            this.tabPageAgregar.Controls.Add(this.cmbRol);
            this.tabPageAgregar.Controls.Add(this.lblTelefono);
            this.tabPageAgregar.Controls.Add(this.txtTelefono);
            this.tabPageAgregar.Controls.Add(this.lblDireccion);
            this.tabPageAgregar.Controls.Add(this.txtDireccion);
            this.tabPageAgregar.Controls.Add(this.lblConfirmPassword);
            this.tabPageAgregar.Controls.Add(this.txtConfirmPassword);
            this.tabPageAgregar.Controls.Add(this.btnAgregarUsuario);
            this.tabPageAgregar.Location = new System.Drawing.Point(4, 24);
            this.tabPageAgregar.Name = "tabPageAgregar";
            this.tabPageAgregar.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageAgregar.Size = new System.Drawing.Size(792, 422);
            this.tabPageAgregar.TabIndex = 1;
            this.tabPageAgregar.Text = "Agregar Usuario";
            this.tabPageAgregar.UseVisualStyleBackColor = true;

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(161, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 23);
            this.txtNombre.TabIndex = 1;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(161, 62);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 3;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 153);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 15);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña:";

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(161, 145);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 5;

            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(30, 115);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(27, 15);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "Rol:";

            // 
            // cmbRol
            // 
            this.cmbRol.Location = new System.Drawing.Point(161, 107);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(200, 23);
            this.cmbRol.TabIndex = 7;

            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(30, 190);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(60, 15);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(161, 182);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 23);
            this.txtTelefono.TabIndex = 9;

            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(30, 230);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(60, 15);
            this.lblDireccion.TabIndex = 10;
            this.lblDireccion.Text = "Dirección:";

            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(161, 222);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 23);
            this.txtDireccion.TabIndex = 11;

            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(30, 270);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(125, 15);
            this.lblConfirmPassword.TabIndex = 12;
            this.lblConfirmPassword.Text = "Confirmar contraseña:";

            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(161, 262);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 23);
            this.txtConfirmPassword.TabIndex = 13;

            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(98, 310);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(157, 30);
            this.btnAgregarUsuario.TabIndex = 14;
            this.btnAgregarUsuario.Text = "Agregar Usuario";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.BtnAgregarUsuario_Click);

            // 
            // GestionUsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlUsuarios);
            this.Name = "GestionUsuariosForm";
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.GestionUsuariosForm_Load);

            this.tabControlUsuarios.ResumeLayout(false);
            this.tabPageLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabPageAgregar.ResumeLayout(false);
            this.tabPageAgregar.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}