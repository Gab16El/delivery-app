namespace DeliveryAppGrupo0008.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombre;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Label lblTelefono;
        private Label lblDireccion;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Label lblNombre;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblConfirmPassword;

        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            lblNombre = new Label();
            lblEmail = new Label();
            lblTelefono = new Label();
            lblDireccion = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(215, 20);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(215, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(215, 100);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(215, 140);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 23);
            txtDireccion.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(215, 177);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(215, 226);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(200, 23);
            txtConfirmPassword.TabIndex = 11;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(129, 261);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(182, 45);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Registrarse";
            btnRegister.Click += btnRegister_Click;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(30, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombres:";
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(30, 60);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(30, 100);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(100, 20);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblDireccion
            // 
            lblDireccion.Location = new Point(30, 140);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(100, 20);
            lblDireccion.TabIndex = 6;
            lblDireccion.Text = "Dirección:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(30, 180);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 20);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Contraseña:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Location = new Point(30, 229);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 20);
            lblConfirmPassword.TabIndex = 10;
            lblConfirmPassword.Text = "Confirmar Contraseña:";
            // 
            // RegisterForm
            // 
            ClientSize = new Size(516, 427);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnRegister);
            Name = "RegisterForm";
            Text = "Registro de Usuario";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }

    }