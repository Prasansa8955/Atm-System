﻿using System;
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
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : Window
    {
        private string cardNumber = CurrentUser.CurrentCardNumber;
        public Withdraw()
        {
            InitializeComponent();
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount) && amount > 0)
            {
                if (WithdrawCash(amount))
                {
                    MessageBox.Show("Withdrawal successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Trancation_page transactionPage = new Trancation_page();
                    transactionPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Insufficient balance or error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool WithdrawCash(decimal amount)
        {
            string connectionString = "Server=localhost;Database=atm_system;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET Balance = Balance - @amount WHERE CardNumber = @cardNumber AND Balance >= @amount;";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@cardNumber", cardNumber);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
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
