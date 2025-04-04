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
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace ATM_System
{
    /// <summary>
    /// Interaction logic for Balance.xaml
    /// </summary>
    public partial class Balance : Window
    {
        private string cardNumber = CurrentUser.CurrentCardNumber;
        public Balance()
        {
            InitializeComponent();
            DisplayBalance();
        }

        private void DisplayBalance()
        {
            string connectionString = "Server=localhost;Database=atm_system;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Balance FROM Users WHERE CardNumber = @cardNumber;";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cardNumber", cardNumber);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            decimal balance = Convert.ToDecimal(result);
                            BalanceLabel.Content = $"Your Balance: {balance:C}";
                        }
                        else
                        {
                            BalanceLabel.Content = "Account not found.";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Trancation_page transactionPage = new Trancation_page();
            transactionPage.Show();
            this.Close();
        }
    }
}
