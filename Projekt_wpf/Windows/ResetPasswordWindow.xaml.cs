using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoList.Core;
using ToDoList.Core.ViewModels.Windows;

namespace Projekt_wpf.Windows
{
    /// <summary>
    /// Interaction logic for ResetPasswordWindow.xaml
    /// </summary>
    public partial class ResetPasswordWindow : Window
    {
        public ResetPasswordWindow()
        { 
            InitializeComponent();
            DataContext = new ResetPasswordWindowViewModel();
            ((ResetPasswordWindowViewModel)DataContext).ResetInCompleted += ShowMassageBoxAfterReset;
        }

        private void ShowMassageBoxAfterReset(object? sender, bool success)
        {

            ResetPasswordWindowViewModel resetviewModel = (ResetPasswordWindowViewModel)DataContext;

            if (resetviewModel.IsResetSuccess)
            {
                this.Close();
                MessageBox.Show(resetviewModel.Message);
                LogInWindow window = new LogInWindow();
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show(resetviewModel.Message);
            }
        }
    }
}
