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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

        }

        private void SignUp_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Sign Up feature not implemented yet.");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string cardNumber = CardNumberTextBox.Text;
            string pin = PinPasswordBox.Password;

            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Please enter both card number and PIN.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (AuthenticateUser(cardNumber, pin))
            {
                CurrentUser.CurrentCardNumber = cardNumber;
                CurrentUser.CurrentUserId = Convert.ToString(GetUserId(cardNumber, pin));
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                Trancation_page transactionPage = new Trancation_page();
                transactionPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid card number or PIN.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool AuthenticateUser(string cardNumber, string pin)
        {
            string connectionString = "Server=localhost;Database=atm_system;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE CardNumber = @cardNumber AND PIN = SHA2(@pin, 256);";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cardNumber", cardNumber);
                        cmd.Parameters.AddWithValue("@pin", pin);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }

        private int? GetUserId(string cardNumber, string pin)
        {
            string connectionString = "Server=localhost;Database=atm_system;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UserID FROM Users WHERE CardNumber = @cardNumber AND PIN = @pin;";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cardNumber", cardNumber);
                        cmd.Parameters.AddWithValue("@pin", pin);
                        object result = cmd.ExecuteScalar();

                        // If a result is returned, it's the UserID
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return null;  // No matching user found
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }



        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            NewSignin newSignin = new NewSignin();
            newSignin.Show();
            this.Close();
        }

        /*private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string accounNumbr = AccountNumberBox.Text;
            string pin = PinBox.Password;

            if (accounNumbr == "12345" && pin == "6789")
            {
                MessageBox.Show("Login Successful!");
                Trancation_page trancation_Page = new Trancation_page();
                trancation_Page.Show();
                this.Close();



            }
            else
            {
                MessageBox.Show("Incorrect Account Number or PIN");

            }
        }*/
    }
}
