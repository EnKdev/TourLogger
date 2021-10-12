using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        private PhpHandler _ph;
        private DataWriter _dw;

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
            Title = $"TourLogger 6.1.0 | {appVer}";

            if (File.Exists($"./Userdata/truck.dat"))
                LoadGeneralDetails();
            else
            {
                lb_Driver.Content = "Driver not found!";
                lb_Truck.Content = "Truck not found!";
            }

            if (File.Exists($"./Userdata/cache.dat"))
                LoadTourData();
            else
                RefreshTourTable();

            if (File.Exists($"./Userdata/progress.dat"))
                ReadProgressingTour();
        }

        private void M_ItemMisc_About_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "TourLogger 6.1.0 [" + Versioning.AppVersion + "]\n" +
                "Developed by EnKdev\n", "About", MessageBoxButton.OK);
        }

        private void Bt_SaveTour_OnClick(object sender, RoutedEventArgs e)
        {
            _ph.SendTourToServer(lb_Driver.Content.ToString(), lb_Truck.Content.ToString(), tb_TFrom.Text,
                tb_TTo.Text, tb_TFreight.Text, Convert.ToInt32(tb_TDistance.Text),
                Convert.ToInt32(tb_TDriven.Text), Convert.ToInt32(tb_TIncome.Text), Convert.ToInt32(tb_TOdo.Text),
                Convert.ToInt32(tb_TFuelUsed.Text));

            if (File.Exists($"./Userdata/progress.dat"))
                File.Delete($"./Userdata/progress.dat");

            MessageBox.Show("Tour saved!", "Success!", MessageBoxButton.OK);

            ClearTextboxes();
            Thread.Sleep(500);
            RefreshTourTable();
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

        private void Bt_RefreshTable_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshTourTable();
        }

        private void Bt_SingleTour_OnClick(object sender, RoutedEventArgs e)
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
                return;

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
                return;

            lb_Driver.Content = truck.Driver;
            lb_Truck.Content = truck.Truck;
        }

        private void LoadTourData()
        {
            var tours = JsonConvert.DeserializeObject<CacheModel>(File.ReadAllText($"./Userdata/cache.dat"));

            if (tours == null)
                return;

            dg_Tours.ItemsSource = tours.CachedTours;
        }

        private void ClearTextboxes()
        {
            tb_TFrom.Text = "-";
            tb_TTo.Text = "-";
            tb_TFreight.Text = "-";
            tb_TDistance.Text = "0";
            tb_TDriven.Text = "0";
            tb_TIncome.Text = "0";
            tb_TOdo.Text = "0";
            tb_TFuelUsed.Text = "0";
        }

        private void RefreshTourTable()
        {
            _ph.FetchDatabaseEntries();

            var tours = JsonConvert.DeserializeObject<CacheModel>(File.ReadAllText($"./Userdata/cache.dat"));

            if (tours == null)
                return;

            dg_Tours.ItemsSource = tours.CachedTours;
        }
    }
}
