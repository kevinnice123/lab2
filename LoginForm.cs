namespace Lab2
{
    public class LoginForm : BaseForm
    {
        private TextBox txtUsername, txtPassword;

        public LoginForm()
        {
            Text = "Login";
            ClientSize = new Size(340, 200);

            var lblUser = new Label { Text = "Username:", Left = 20, Top = 25, AutoSize = true };
            txtUsername = new TextBox { Left = 120, Top = 22, Width = 190 };
            var lblPass = new Label { Text = "Password:", Left = 20, Top = 70, AutoSize = true };
            txtPassword = new TextBox { Left = 120, Top = 67, Width = 190, UseSystemPasswordChar = true };
            var btnLogin = new Button { Text = "Login", Left = 120, Top = 120, Width = 100, Height = 35 };
            btnLogin.Click += BtnLogin_Click;

            Controls.AddRange(new Control[] { lblUser, txtUsername, lblPass, txtPassword, btnLogin });
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