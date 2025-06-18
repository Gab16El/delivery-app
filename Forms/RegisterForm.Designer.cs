namespace DeliveryAppGrupo0008.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombre;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Label lblNombre;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblConfirmPassword;

        private void InitializeComponent()
        {
            txtNombre = new TextBox { Location = new System.Drawing.Point(150, 20), Width = 200 };
            txtEmail = new TextBox { Location = new System.Drawing.Point(150, 60), Width = 200 };
            txtPassword = new TextBox { Location = new System.Drawing.Point(150, 100), Width = 200, PasswordChar = '*' };
            txtConfirmPassword = new TextBox { Location = new System.Drawing.Point(150, 140), Width = 200, PasswordChar = '*' };
            btnRegister = new Button { Location = new System.Drawing.Point(150, 180), Width = 200, Text = "Registrar" };
            btnRegister.Click += btnRegister_Click;

            lblNombre = new Label { Location = new System.Drawing.Point(50, 20), Text = "Nombre:", AutoSize = true };
            lblEmail = new Label { Location = new System.Drawing.Point(50, 60), Text = "Correo Electrónico:", AutoSize = true };
            lblPassword = new Label { Location = new System.Drawing.Point(50, 100), Text = "Contraseña:", AutoSize = true };
            lblConfirmPassword = new Label { Location = new System.Drawing.Point(50, 140), Text = "Confirmar Contraseña:", AutoSize = true };

            this.Controls.Add(txtNombre);
            this.Controls.Add(txtEmail);
            this.Controls.Add(txtPassword);
            this.Controls.Add(txtConfirmPassword);
            this.Controls.Add(btnRegister);
            this.Controls.Add(lblNombre);
            this.Controls.Add(lblEmail);
            this.Controls.Add(lblPassword);
            this.Controls.Add(lblConfirmPassword);

            this.Text = "Registro de Usuario";
            this.ClientSize = new System.Drawing.Size(400, 230);
        }
    }

}