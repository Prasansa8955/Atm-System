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
    /// Interaction logic for Trancation_page.xaml
    /// </summary>
    public partial class Trancation_page : Window
    {
        public Trancation_page()
        {
            InitializeComponent();
        }

        private void MoneyDeposit_Click(object sender, RoutedEventArgs e)
        {
            Deposit deposit = new Deposit();
            deposit.Show();
            this.Close();
        }
        private void MoneyWithdraw_Click(object sender, RoutedEventArgs e) {
            Withdraw withdraw = new Withdraw();
            withdraw.Show();
            this.Close();
        }

        private void Change_PinButton_Click(object sender, RoutedEventArgs e)
        {
            Change_Pin change_Pin = new Change_Pin();
            change_Pin.Show();
            this.Close();
        }

        private void BalanceButton_Click(object sender, RoutedEventArgs e)
        {
            Balance balance = new Balance();
            balance.Show();
            this.Close();
        }

        private void flashcard(object sender, RoutedEventArgs e)
        {
            Flash_Card flash_Card = new Flash_Card();
            flash_Card.Show();
            this.Close();
        }
    }
}
