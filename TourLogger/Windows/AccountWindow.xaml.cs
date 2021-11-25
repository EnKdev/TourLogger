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
using TourLogger.Models;
using TourLogger.Utils;

namespace TourLogger.Windows
{
    /// <summary>
    /// Interaktionslogik für AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private string _accountString;
        private PhpHandler _ph;
        private readonly AccountModel _account;
        private bool _isPersonalAccount;

        public AccountWindow(AccountModel account)
        {
            InitializeComponent();
            _account = account;
            _ph = new PhpHandler();

            Loaded += OnLoaded;
        }

        public AccountWindow(string accountString)
        {
            InitializeComponent();
            _accountString = accountString;

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_account != null)
            {
                LoadPersonalAccount(_account);
                _isPersonalAccount = true;
            }

            if (_accountString != null)
            {
                LoadForeignAccount(_accountString);
            }
        }

        private void LoadPersonalAccount(AccountModel account)
        {
            lb_AccountName.Content = _account.AccountName;
            lb_Truck.Content = _account.AccountTruck;
            lb_Tours.Content = _account.TotalTours;
            lb_Kilometer.Content = _account.TotalKilometers;
            lb_Income.Content = _account.TotalIncome;
            lb_Refuels.Content = _account.TotalRefuels;
            lb_Liters.Content = _account.TotalLiters;
            lb_Paid.Content = _account.TotalFuelPrice;

            sp_Personal.IsEnabled = true;
        }

        private void LoadForeignAccount(string accountString)
        {
            string[] accountDetails = accountString.Split('|', StringSplitOptions.RemoveEmptyEntries);

            lb_AccountName.Content = accountDetails[1];
            lb_Truck.Content = accountDetails[2];
            lb_Tours.Content = accountDetails[3];
            lb_Kilometer.Content = accountDetails[4];
            lb_Income.Content = accountDetails[5];
            lb_Refuels.Content = accountDetails[6];
            lb_Liters.Content = accountDetails[7];
            lb_Paid.Content = accountDetails[8];

            sp_Personal.IsEnabled = false;
        }

        private void Bt_Update_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isPersonalAccount)
            {
                try
                {
                    _ph.UpdateAccountTruck(_account.AccountName, tb_NewTruck.Text);
                    MessageBox.Show("Truck updated!", "Success!", MessageBoxButton.OK);
                }
                catch (TourLoggerException tex)
                {
                    MessageBox.Show("An exception occured\n" +
                                    $"{tex.Message}", "Error updating truck!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Bt_Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
