using System;
using System.Collections.Generic;
using System.IO;
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
        private string _refuelIdName;

        public RefuelWindow()
        {
            InitializeComponent();

            var truckInfo = JsonConvert.DeserializeObject<TruckModel>(File.ReadAllText($"./Userdata/truck.dat"));

            if (truckInfo != null)
            {
                _refuelIdName = truckInfo.Driver;
            }
        }

        private void Bt_Save_OnClick(object sender, RoutedEventArgs e)
        {
            // Do things.
        }
    }
}
