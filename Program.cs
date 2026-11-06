namespace Lab2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            new LoginForm().Show();
            Application.Run(new ApplicationContext());
        }
    }
}