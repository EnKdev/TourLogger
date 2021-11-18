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
            _ph.SendRefuelToServer(_refuelDriver, tb_RCountry.Text, double.Parse(tb_RPrice.Text),
                int.Parse(tb_ROdo.Text), int.Parse(tb_RAmount.Text), int.Parse(tb_RPriceTotal.Text));

            MessageBox.Show("Refuel saved! Refresh the refuel table in the main window!", "Success!", MessageBoxButton.OK);
            Thread.Sleep(500);
            Close();
        }
    }
}
