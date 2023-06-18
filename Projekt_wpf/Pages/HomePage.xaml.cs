using Projekt_wpf.Pages;
using Projekt_wpf.Windows;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Core.ViewModels.Windows;

namespace Projekt_wpf.Windows
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        WorkTaskPage workTaskPage = new WorkTaskPage();
        public HomePage()
        {
            InitializeComponent();
            DataContext = new LogInWindowViewModel();
        }

        private void SignIn_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SignInWindow window = new SignInWindow();
            window.ShowDialog();
        }

        private void LogIn_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LogInWindowViewModel loginviewModel = (LogInWindowViewModel)DataContext;    
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
