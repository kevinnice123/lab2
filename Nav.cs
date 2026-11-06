namespace Lab2
{
    public static class Nav
    {
        public static bool Switching = false;

        // Open the next form, then close the current one
        public static void Go(Form from, Form to)
        {
            Switching = true;
            to.Show();
            from.Close();
            Switching = false;
        }
    }

    // Shared colors for every screen
    public static class Theme
    {
        public static readonly Color Background = Color.FromArgb(40, 40, 40);    // dark gray
        public static readonly Color Text = Color.White;
        public static readonly Color Button = Color.FromArgb(90, 90, 90);    // medium gray
        public static readonly Color DarkButton = Color.Black;
        public static readonly Color Input = Color.FromArgb(235, 235, 235); // light gray boxes
    }

    // Every form inherits from this one. Clicking X exits the app,
    // but moving with the buttons does not.
    public class BaseForm : Form
    {
        public BaseForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 10F);
            BackColor = Theme.Background;
            ForeColor = Theme.Text;
        }

        // Creates a button in the theme colors
        protected Button MakeButton(string text, int left, int top, int width, int height, bool dark = false)
        {
            var btn = new Button
            {
                Text = text,
                Left = left,
                Top = top,
                Width = width,
                Height = height,
                BackColor = dark ? Theme.DarkButton : Theme.Button,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderColor = Color.Gray;
            return btn;
        }

        // Creates a text box in the theme colors
        protected TextBox MakeTextBox(int left, int top, int width)
        {
            return new TextBox
            {
                Left = left,
                Top = top,
                Width = width,
                BackColor = Theme.Input,
                ForeColor = Color.Black
            };
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!Nav.Switching) Application.Exit();
        }
    }
}