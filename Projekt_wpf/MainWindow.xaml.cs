using Projekt_wpf.Windows;
using System.Windows;

namespace Projekt_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenWindowButton_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow myWindow = new LogInWindow(); // Tworzenie instancji nowego okna
            myWindow.Show(); // Otwarcie okna
        }        
        
      
    }   
}
