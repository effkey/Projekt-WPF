using Projekt_wpf.Pages;
using Projekt_wpf.Windows;
using System.Text.Json;
using System;
using System.Windows;
using System.IO;
using ToDoList.Core.ViewModels.Windows;
using ToDoList.Core;

namespace Projekt_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkTaskPage workTaskPage = new WorkTaskPage();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LogInWindowViewModel();
            ChangePage();
        }

        public void ChangePage()
        {
            LogInWindowViewModel signinviewModel = (LogInWindowViewModel)DataContext;
            signinviewModel.ReadLogInSession();
            if (signinviewModel.IsLogInSuccess)
            {
                this.Content = workTaskPage;
            }
        } 
    }   
}
