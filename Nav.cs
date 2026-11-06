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
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!Nav.Switching) Application.Exit();
        }
    }
}