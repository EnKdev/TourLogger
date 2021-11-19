using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using TourLogger.Models;
using TourLogger.Utils;

namespace TourLogger.Windows
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PhpHandler _ph;
        private readonly DataWriter _dw;

        public MainWindow()
        {
            InitializeComponent();

            _ph = new PhpHandler();
            _dw = new DataWriter();

            Loaded += OnLoaded;
        }

        // ----

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var appVer = Versioning.AppVersion;
            Title = $"TourLogger 7.0.0-beta3 | {appVer}";

            if (File.Exists($"./Userdata/truck.dat"))
            {
                LoadGeneralDetails();
            }
            else
            {
                lb_Driver.Content = "Driver not found!";
                lb_Truck.Content = "Truck not found!";
            }

            if (File.Exists($"./Userdata/tourCache.dat"))
            {
                LoadTourData();
            }
            else
            { 
                RefreshTourTable();
            }

            if (File.Exists($"./Userdata/refuelCache.dat"))
            {
                LoadRefuelData();
            }
            else
            {
                RefreshRefuelTable();
            }

            if (File.Exists($"./Userdata/progress.dat"))
            {
                ReadProgressingTour();
            }
        }

        private void M_ItemMisc_About_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "TourLogger 7.0.0-beta3 [" + Versioning.AppVersion + "]\n" +
                "Developed by EnKdev\n", "About", MessageBoxButton.OK);
        }

        private void Bt_SaveTour_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _ph.SendTourToServer(lb_Driver.Content.ToString(), lb_Truck.Content.ToString(), tb_TFrom.Text,
                    tb_TTo.Text, tb_TFreight.Text, Convert.ToInt32(tb_TDistance.Text),
                    Convert.ToInt32(tb_TDriven.Text), Convert.ToInt32(tb_TIncome.Text), Convert.ToInt32(tb_TOdo.Text),
                    Convert.ToInt32(tb_TFuelUsed.Text));

                if (File.Exists($"./Userdata/progress.dat"))
                {
                    File.Delete($"./Userdata/progress.dat");
                }

                MessageBox.Show("Tour saved!", "Success!", MessageBoxButton.OK);

                ClearTextboxes();
                Thread.Sleep(500);
                RefreshTourTable();
            }
            catch (TourLoggerException tex)
            {
                MessageBox.Show("An exception occured!\n" +
                                $"{tex.ToString()}", "Error saving tour.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Bt_SaveProgress_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // NULL CHECK

                var tDist = 0;
                var jobInc = 0;

                tDist = tb_TDistance.Text == string.Empty ? 0 : int.Parse(tb_TDistance.Text);
                jobInc = tb_TIncome.Text == string.Empty ? 0 : int.Parse(tb_TIncome.Text);

                _dw.WriteProgressingTourData(
                    lb_Driver.Content.ToString(), lb_Truck.Content.ToString(), tb_TFrom.Text,
                    tb_TTo.Text, tb_TFreight.Text, tDist, jobInc);

                MessageBox.Show("Tour progress saved!", "Success!", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unknown error occured while trying to save the tour.\n" +
                    "Please refer to the exception message:\n" +
                    "----------------------\n" +
                    $"{ex.Message}\nat:\n{ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Bt_RefreshTourTable_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshTourTable();
            MessageBox.Show("Tour-Table refreshed!", "Refreshed!", MessageBoxButton.OK);
        }

        private void Bt_ShowSingleTour_OnClick(object sender, RoutedEventArgs e)
        {
            var stw = new SingleTourWindow();
            var tour = _ph.FetchTour(Convert.ToInt32(tb_TourId.Text));
            char[] sep = { '|' };
            tour = tour.Replace(" -> ", "|");
            string[] tString = tour.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            stw.CarryValuesOverToWindow(tString);
            Thread.Sleep(500);
            stw.Show();
        }

        // ----

        private void ReadProgressingTour()
        {
            var json = JsonConvert.DeserializeObject<SingleTourModel>(File.ReadAllText($"./Userdata/progress.dat"));

            if (json == null)
            {
                return;
            }

            tb_TFrom.Text = json.TourFrom;
            tb_TTo.Text = json.TourTo;
            tb_TFreight.Text = json.TourFreight;
            tb_TDistance.Text = json.TourDistance.ToString();
            tb_TDriven.Text = "0";
            tb_TIncome.Text = json.JobIncome.ToString();
            tb_TOdo.Text = "0";
            tb_TFuelUsed.Text = "0";
        }

        private void LoadGeneralDetails()
        {
            var truck = JsonConvert.DeserializeObject<TruckModel>(File.ReadAllText($"./Userdata/truck.dat"));

            if (truck == null)
            {
                return;
            }

            lb_Driver.Content = truck.Driver;
            lb_Truck.Content = truck.Truck;
        }

        private void LoadTourData()
        {
            var tours = JsonConvert.DeserializeObject<CacheTourModel>(File.ReadAllText($"./Userdata/tourCache.dat"));

            if (tours == null)
            {
                return;
            }

            dg_TourData.ItemsSource = tours.CachedTours;
        }

        private void LoadRefuelData()
        {
            var refuels = JsonConvert.DeserializeObject<RefuelCacheModel>(File.ReadAllText($"./Userdata/refuelCache.dat"));

            if (refuels == null)
            {
                return;
            }

            dg_RefuelData.ItemsSource = refuels.CachedRefuels;
        }

        private void ClearTextboxes()
        {
            tb_TFrom.Text = "";
            tb_TTo.Text = "";
            tb_TFreight.Text = "";
            tb_TDistance.Text = "";
            tb_TDriven.Text = "";
            tb_TIncome.Text = "";
            tb_TOdo.Text = "";
            tb_TFuelUsed.Text = "";
        }

        private void RefreshTourTable()
        {
            try
            {
                _ph.FetchTourDatabaseEntries();

                var tours = JsonConvert.DeserializeObject<CacheTourModel>(File.ReadAllText($"./Userdata/tourCache.dat"));

                if (tours == null)
                {
                    return;
                }

                dg_TourData.ItemsSource = tours.CachedTours;
            }
            catch (TourLoggerException tex)
            {
                MessageBox.Show("An exception occured!\n" +
                               $"{tex.ToString()}", "Error refreshing tours.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void RefreshRefuelTable()
        {
            try
            {
                _ph.FetchRefuelDatabaseEntries();

                var refuels =
                    JsonConvert.DeserializeObject<RefuelCacheModel>(File.ReadAllText($"./Userdata/refuelCache.dat"));

                if (refuels == null)
                {
                    return;
                }

                dg_RefuelData.ItemsSource = refuels.CachedRefuels;
            }
            catch (TourLoggerException tex)
            {
                MessageBox.Show("An exception occured!\n" +
                               $"{tex.ToString()}", "Error refreshing refuels.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ----

        private void M_ConfigItem_OnClick(object sender, RoutedEventArgs e)
        {
            var cw = new ConfigWindow();
            cw.Show();
        }

        private void Bt_AddRefuel_OnClick(object sender, RoutedEventArgs e)
        {
            var rw = new RefuelWindow();
            rw.Show();
        }

        // ----

        private void Bt_RefreshRefuelTable_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshRefuelTable();
            MessageBox.Show("Refuel-Table refreshed!", "Refreshed!", MessageBoxButton.OK);
        }

        private void Bt_ShowSingleRefuel_OnClick(object sender, RoutedEventArgs e)
        {
            var srw = new SingleRefuelWindow();
            var tour = _ph.FetchRefuel(Convert.ToInt32(tb_RefuelId.Text));
            char[] sep = { '|' };
            string[] tString = tour.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            srw.CarryValuesOverToWindow(tString);
            Thread.Sleep(500);
            srw.Show();
        }
    }
}
