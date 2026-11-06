namespace Lab2
{
    public class LoginForm : BaseForm
    {
        private TextBox txtUsername, txtPassword;

        public LoginForm()
        {
            Text = "Login";
            ClientSize = new Size(340, 240);

            var lblTitle = new Label
            {
                Text = "Login",
                Left = 0,
                Top = 15,
                Width = 340,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold)
            };

            var lblUser = new Label { Text = "Username:", Left = 20, Top = 75, AutoSize = true };
            txtUsername = MakeTextBox(120, 72, 190);
            var lblPass = new Label { Text = "Password:", Left = 20, Top = 120, AutoSize = true };
            txtPassword = MakeTextBox(120, 117, 190);
            txtPassword.UseSystemPasswordChar = true;

            var btnLogin = MakeButton("Login", 120, 170, 100, 38);
            btnLogin.Click += BtnLogin_Click;

            Controls.AddRange(new Control[] { lblTitle, lblUser, txtUsername, lblPass, txtPassword, btnLogin });
            AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username and Password cannot be empty.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Nav.Go(this, new ChooseForm());
        }
    }
}