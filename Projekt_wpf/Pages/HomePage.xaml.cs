using Projekt_wpf.Windows;
using System.Windows;
using System.Windows.Controls;


namespace Projekt_wpf.Windows
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void SignIn_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SignInWindow window = new SignInWindow();
            window.ShowDialog();
        }

        private void LogIn_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LogInWindow window = new LogInWindow();
            window.ShowDialog();
        }
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ResetPasswordWindow window = new ResetPasswordWindow();
            window.ShowDialog();
        }
    }
}
