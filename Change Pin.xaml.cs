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

namespace ATM_System
{
    /// <summary>
    /// Interaction logic for Change_Pin.xaml
    /// </summary>
    public partial class Change_Pin : Window
    {
        public Change_Pin()
        {
            InitializeComponent();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            string newPin = pinchange.Password;
            string confirmPin = pincomfirm.Password;

            if (string.IsNullOrWhiteSpace(newPin) || string.IsNullOrWhiteSpace(confirmPin))
            {
                MessageBox.Show("Please enter both PIN fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (newPin == confirmPin)
            {
                MessageBox.Show("PIN successfully changed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("PINs do not match. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Going back to the previous screen.", "Back", MessageBoxButton.OK, MessageBoxImage.Information);
            // You can add navigation logic here if needed
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

    

