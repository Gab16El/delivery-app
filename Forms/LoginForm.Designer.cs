namespace DeliveryAppGrupo0008.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(_authService);
            registerForm.ShowDialog();
        }


        #region
        private Button btnRegister;

        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblEmail = new Label();
            lblPassword = new Label();
            lblTitle = new Label();
            panelLogin = new Panel();
            btnRegister = new Button();

            panelLogin.SuspendLayout();
            SuspendLayout();

            // txtEmail
            txtEmail.Location = new Point(30, 70);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(290, 23);
            txtEmail.TabIndex = 2;

            // txtPassword
            txtPassword.Location = new Point(30, 130);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(290, 23);
            txtPassword.TabIndex = 4;

            // btnLogin
            btnLogin.Location = new Point(75, 180);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 35);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;

            // lblEmail
            lblEmail.Location = new Point(30, 50);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(290, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Correo Electrónico:";

            // lblPassword
            lblPassword.Location = new Point(30, 110);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(290, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña:";

            // lblTitle
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inicio de Sesión";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // btnRegister
            btnRegister.Location = new Point(75, 230); // posición más abajo para que no se encime con btnLogin
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(200, 35);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Crear Cuenta";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;

            // panelLogin
            panelLogin.BackColor = Color.White;
            panelLogin.BorderStyle = BorderStyle.FixedSingle;
            panelLogin.Controls.Add(lblTitle);
            panelLogin.Controls.Add(lblEmail);
            panelLogin.Controls.Add(txtEmail);
            panelLogin.Controls.Add(lblPassword);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(btnRegister);
            panelLogin.Location = new Point(100, 50);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(350, 300); // aumenté la altura para que quepa btnRegister
            panelLogin.TabIndex = 0;

            // LoginForm
            BackColor = Color.DimGray;
            ClientSize = new Size(550, 400);
            Controls.Add(panelLogin);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DeliveryApp";
            Load += LoginForm_Load;

            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
