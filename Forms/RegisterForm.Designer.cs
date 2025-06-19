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

                // lblNombre
                lblNombre.Text = "Nombre:";
                lblNombre.Location = new Point(30, 20);
                lblNombre.Size = new Size(100, 20);

                // txtNombre
                txtNombre.Location = new Point(150, 20);
                txtNombre.Size = new Size(200, 23);

                // lblEmail
                lblEmail.Text = "Email:";
                lblEmail.Location = new Point(30, 60);
                lblEmail.Size = new Size(100, 20);

                // txtEmail
                txtEmail.Location = new Point(150, 60);
                txtEmail.Size = new Size(200, 23);

                // lblTelefono
                lblTelefono.Text = "Teléfono:";
                lblTelefono.Location = new Point(30, 100);
                lblTelefono.Size = new Size(100, 20);

                // txtTelefono
                txtTelefono.Location = new Point(150, 100);
                txtTelefono.Size = new Size(200, 23);

                // lblDireccion
                lblDireccion.Text = "Dirección:";
                lblDireccion.Location = new Point(30, 140);
                lblDireccion.Size = new Size(100, 20);

                // txtDireccion
                txtDireccion.Location = new Point(150, 140);
                txtDireccion.Size = new Size(200, 23);

                // lblPassword
                lblPassword.Text = "Contraseña:";
                lblPassword.Location = new Point(30, 180);
                lblPassword.Size = new Size(100, 20);

                // txtPassword
                txtPassword.Location = new Point(150, 180);
                txtPassword.Size = new Size(200, 23);
                txtPassword.UseSystemPasswordChar = true;

                // lblConfirmPassword
                lblConfirmPassword.Text = "Confirmar Contraseña:";
                lblConfirmPassword.Location = new Point(30, 220);
                lblConfirmPassword.Size = new Size(130, 20);

                // txtConfirmPassword
                txtConfirmPassword.Location = new Point(170, 220);
                txtConfirmPassword.Size = new Size(180, 23);
                txtConfirmPassword.UseSystemPasswordChar = true;

                // btnRegister
                btnRegister.Text = "Registrar";
                btnRegister.Location = new Point(150, 260);
                btnRegister.Size = new Size(100, 30);
                btnRegister.Click += btnRegister_Click;

                // Form
                ClientSize = new Size(400, 320);
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