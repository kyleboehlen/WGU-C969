namespace WGUD969.Forms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            lblWelcome = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            cmbLanguage = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(39, 82);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "username";
            txtUsername.Size = new Size(201, 23);
            txtUsername.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(39, 64);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(60, 15);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome!";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(39, 111);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "password";
            txtPassword.Size = new Size(201, 23);
            txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(165, 140);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Items.AddRange(new object[] { "English", "Français" });
            cmbLanguage.Location = new Point(39, 219);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(201, 23);
            cmbLanguage.TabIndex = 4;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 201);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 5;
            label1.Text = "Language";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 259);
            Controls.Add(label1);
            Controls.Add(cmbLanguage);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblWelcome);
            Controls.Add(txtUsername);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private Label lblWelcome;
        private TextBox txtPassword;
        private Button btnLogin;
        private ComboBox cmbLanguage;
        private Label label1;
    }
}