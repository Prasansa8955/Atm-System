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

namespace ATM_System
{
    /// <summary>
    /// Interaction logic for NewSignin.xaml
    /// </summary>
    public partial class NewSignin : Window
    {
        public NewSignin()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string cardNumber = CardNumberTextBox.Text;
            string pin = PinPasswordBox.Password;
            string fullName = FullNameTextBox.Text;

            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(pin) || string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (RegisterUser(cardNumber, pin, fullName))
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool RegisterUser(string cardNumber, string pin, string fullName)
        {
            string connectionString = "Server=localhost;Database=atm_system;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Users (CardNumber, PIN, FullName) VALUES (@cardNumber, SHA2(@pin, 256), @fullName);";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cardNumber", cardNumber);
                        cmd.Parameters.AddWithValue("@pin", pin);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
