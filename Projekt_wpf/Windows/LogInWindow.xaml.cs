using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoList.Core.ViewModels.Windows;

namespace Projekt_wpf.Windows
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
            DataContext = new LogInWindowViewModel();
            ((LogInWindowViewModel)DataContext).LogInCompleted += ShowMassageBoxAfterLogIn;
        }
        private void ShowMassageBoxAfterLogIn(object? sender, bool success)
        {

            LogInWindowViewModel loginviewModel = (LogInWindowViewModel)DataContext;

            if (loginviewModel.IsLogInSuccess)
            {
                this.Close();
                MessageBox.Show("Successfully logged in.");

            }
            else
            {
                MessageBox.Show(loginviewModel.ErrorResponse);
            }
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            TxtBox.Text = passwordTextBox.Password;
            passwordTextBox.Visibility = Visibility.Collapsed;
            TxtBox.Visibility = Visibility.Visible;
        }
        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Password = TxtBox.Text;
            passwordTextBox.Visibility = Visibility.Visible;
            TxtBox.Visibility = Visibility.Collapsed;
        }
    }
}
