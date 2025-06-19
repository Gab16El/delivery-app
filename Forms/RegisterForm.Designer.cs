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
            txtNombre = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            lblNombre = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(0, 0);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(0, 0);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 2;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(0, 0);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(100, 23);
            txtConfirmPassword.TabIndex = 3;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(0, 0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 4;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(0, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(0, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 7;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Location = new Point(0, 0);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(100, 23);
            lblConfirmPassword.TabIndex = 8;
            // 
            // RegisterForm
            // 
            ClientSize = new Size(400, 230);
            Controls.Add(txtNombre);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnRegister);
            Controls.Add(lblNombre);
            Controls.Add(lblEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblConfirmPassword);
            Name = "RegisterForm";
            Text = "Registro de Usuario";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }

}