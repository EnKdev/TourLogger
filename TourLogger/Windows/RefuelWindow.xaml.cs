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
        private string _refuelDriver;
        private readonly PhpHandler _ph;

        private MainWindow _mw;

        public RefuelWindow()
        {
            InitializeComponent();

            _ph = new PhpHandler();

            var truckInfo = JsonConvert.DeserializeObject<TruckModel>(File.ReadAllText($"./Userdata/truck.dat"));

            if (truckInfo != null)
            {
                _refuelDriver = truckInfo.Driver;
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

                _ph.SendRefuelToServer(_refuelDriver, tb_RCountry.Text, double.Parse(literPrice),
                    int.Parse(tb_ROdo.Text), int.Parse(tb_RAmount.Text), int.Parse(tb_RPriceTotal.Text));

                MessageBox.Show("Refuel saved! Refresh the refuel table in the main window!", "Success!",
                    MessageBoxButton.OK);
                Thread.Sleep(500);
                Close();
            }
            catch (TourLoggerException tex)
            {
                MessageBox.Show("An exception occured!\n" +
                                $"{tex.Message}", "Error saving refuel.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
