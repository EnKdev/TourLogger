using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;

using Newtonsoft.Json;
using TourLogger.Models;
using TourLogger.Utils;

namespace TourLogger.Windows
{
    /// <summary>
    /// Interaktionslogik für RefuelWindow.xaml
    /// </summary>
    public partial class RefuelWindow : Window
    {
        private readonly PhpHandler _ph;
        private AccountModel _am;

        private MainWindow _mw;

        public RefuelWindow(AccountModel account)
        {
            InitializeComponent();

            _ph = new PhpHandler();

            if (account != null)
            {
                _am = account;
            }
        }

        private void Bt_Save_OnClick(object sender, RoutedEventArgs e)
        {
            var literPrice = tb_RPrice.Text;

            if (literPrice.Contains('.'))
            {
                // Floating point conversion, using dots for commas breaks things in the backend with the database.
                // It'll be stored with a point thanks to an internal database conversion anyways.
                literPrice = literPrice.Replace('.', ',');
            }

            try
            {

                _ph.SendRefuelToServer(_am.AccountName, tb_RCountry.Text, double.Parse(literPrice),
                    int.Parse(tb_ROdo.Text), int.Parse(tb_RAmount.Text), int.Parse(tb_RPriceTotal.Text));

                MessageBox.Show("Refuel saved! Refresh the refuel table in the main window!", "Success!",
                    MessageBoxButton.OK);
                Thread.Sleep(500);
                _ph.UpdateAccountRefuels(_am.AccountName);
                Thread.Sleep(250);
                ReloadAccount(_am.AccountName);
                Close();
            }
            catch (TourLoggerException tex)
            {
                MessageBox.Show("An exception occured!\n" +
                                $"{tex.Message}", "Error saving refuel.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ----

        private void ReloadAccount(string accountName)
        {
            try
            {
                var account = _ph.GetAccount(accountName);

                if (account != null)
                {
                    string[] accountDetails = account.Split('|', StringSplitOptions.RemoveEmptyEntries);

                    var am = new AccountModel
                    {
                        AccountId = int.Parse(accountDetails[0]),
                        AccountName = accountDetails[1],
                        AccountTruck = accountDetails[2],
                        TotalTours = accountDetails[3],
                        TotalKilometers = accountDetails[4],
                        TotalIncome = accountDetails[5],
                        TotalRefuels = accountDetails[6],
                        TotalLiters = accountDetails[7],
                        TotalFuelPrice = accountDetails[8]
                    };

                    _am = am;

                    var accountJson = JsonConvert.SerializeObject(am, Formatting.Indented);
                    using var file = File.CreateText($"./Userdata/account.dat");
                    file.Write(accountJson);
                    file.Dispose();
                }
            }
            catch (TourLoggerException tex)
            {
                MessageBox.Show("An exception occured!\n" +
                                $"{tex.Message}", "Error reloading account.", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
