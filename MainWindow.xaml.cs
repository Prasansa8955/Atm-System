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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_System
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
        private void  Card_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Card selected!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            Window window = new Login();
            window.Show();
            this.Close();
        }
        private void Cardless_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cardless Feature coming Soon!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }
    }
}
