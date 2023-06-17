using System.Windows;
using ToDoList.Core;

namespace Projekt_wpf.Windows
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
            DataContext = new SignInWindowViewModel();
            ((SignInWindowViewModel)DataContext).SignInCompleted += ShowMassageBoxAfterSignIn;
        }
        private void ShowMassageBoxAfterSignIn(object? sender, bool success)
        {

            SignInWindowViewModel signinviewModel = (SignInWindowViewModel)DataContext;

            if (signinviewModel.IsSignInSuccess)
            {
                this.Close();
                MessageBox.Show(signinviewModel.Response);
            }
            else
            {
                MessageBox.Show(signinviewModel.Response);
            }
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            TxtBox.Text = passwordTextBox.Password;
            TxtBox1.Text = passwordTextBox1.Password;
            passwordTextBox.Visibility = Visibility.Collapsed;
            passwordTextBox1.Visibility = Visibility.Collapsed;
            TxtBox.Visibility = Visibility.Visible;
            TxtBox1.Visibility = Visibility.Visible;
        }
        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Password = TxtBox.Text;
            passwordTextBox1.Password = TxtBox1.Text;
            passwordTextBox.Visibility = Visibility.Visible;
            passwordTextBox1.Visibility = Visibility.Visible;
            TxtBox.Visibility = Visibility.Collapsed;
            TxtBox1.Visibility = Visibility.Collapsed;
        }
    }
}
