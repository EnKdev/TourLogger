using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using TourLogger.Models;
using TourLogger.Utils;

namespace TourLogger.Forms
{
    public partial class MainForm : Form
    {
        private PhpIntegration _pi;
        private DataWriter _dw;

        public MainForm()
        {
            InitializeComponent();
            _pi = new PhpIntegration();
            _dw = new DataWriter();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists($"./Userdata/truck.dat"))
                LoadGeneralDetails();
            else
            {
                lDriver.Text = "Driver not found!";
                lTruck.Text = "Truck not found!";
            }

            if (File.Exists($"./Userdata/cache.dat"))
                LoadTourData();
            
            if (File.Exists($"./Userdata/progress.dat"))
                ReadProgressingTour();
        }


        private void ReadProgressingTour()
        {
            SingleTourModel json = JsonConvert.DeserializeObject<SingleTourModel>(File.ReadAllText("./Userdata/progress.dat"));
            tBoxFrom.Text = json.TourFrom;
            tBoxTo.Text = json.TourTo;
            tBoxFreight.Text = json.TourFreight;
            tBoxTourDistance.Text = json.TourDistance.ToString();
            tBoxDrivenDistance.Text = "0";
            tBoxJobIncome.Text = json.JobIncome.ToString();
            tBoxOdo.Text = "0";
            tBoxFuel.Text = "0";
        }

        private void LoadGeneralDetails()
        {
            TruckModel truck = JsonConvert.DeserializeObject<TruckModel>(File.ReadAllText("./Userdata/truck.dat"));
            lDriver.Text = truck.Driver;
            lTruck.Text = truck.Truck;
        }

        private void LoadTourData()
        {
            CacheModel tours = JsonConvert.DeserializeObject<CacheModel>(File.ReadAllText("./Userdata/cache.dat"));

            for (int i = 0; i < tours.CachedTours.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Insert(i,
                    new object[]
                    {
                        tours.CachedTours[i].Id, tours.CachedTours[i].Driver, tours.CachedTours[i].From, tours.CachedTours[i].To,
                        tours.CachedTours[i].Freight, tours.CachedTours[i].Distance, tours.CachedTours[i].Driven,
                        tours.CachedTours[i].Income, tours.CachedTours[i].Total, tours.CachedTours[i].Fuel
                    });
            }
        }

        private void bSaveTour_Click(object sender, EventArgs e) // Save Tour
        {
            _pi.SendTourToServer(
                lDriver.Text, tBoxFrom.Text, tBoxTo.Text, tBoxFreight.Text,
                Convert.ToInt32(tBoxTourDistance.Text), Convert.ToInt32(tBoxDrivenDistance.Text),
                Convert.ToInt32(tBoxJobIncome.Text), Convert.ToInt32(tBoxOdo.Text),
                Convert.ToInt32(tBoxFuel.Text));

            if (File.Exists($"./Userdata/progress.dat"))
                File.Delete($"./Userdata/progress.dat");

            MessageBox.Show("Tour saved!", "Success!", MessageBoxButtons.OK);

            ClearTextboxes();
        }

        private void button1_Click(object sender, EventArgs e) // Refresh Tours
        {
            _pi.FetchDatabaseEntries(); // Refresh Cache Data
            CacheModel tours = JsonConvert.DeserializeObject<CacheModel>(File.ReadAllText("./Userdata/cache.dat")); // Read refreshed cache data

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            Thread.Sleep(1000);

            for (int i = 0; i < tours.CachedTours.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Insert(i,
                    new object[]
                    {
                        tours.CachedTours[i].Id, tours.CachedTours[i].Driver, tours.CachedTours[i].From, tours.CachedTours[i].To,
                        tours.CachedTours[i].Freight, tours.CachedTours[i].Distance, tours.CachedTours[i].Driven,
                        tours.CachedTours[i].Income, tours.CachedTours[i].Total, tours.CachedTours[i].Fuel
                    }
                );
            }
        }

        private void button2_Click(object sender, EventArgs e) // Show Single Tour
        {
            SingleTourForm stf = new SingleTourForm();
            string tour = _pi.FetchTour(Convert.ToInt32(tBoxTourId.Text));
            char[] sep = {'|'};
            tour = tour.Replace(" -> ", "|");
            string[] tString = tour.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            stf.CarryValuesOverToForm(tString);
            Thread.Sleep(500);
            stf.Show();

        }

        private void bSaveProgress_Click(object sender, EventArgs e) // Save Tour Progress
        {
            _dw.WriteProgressingTourData(lDriver.Text, tBoxFrom.Text, tBoxTo.Text, tBoxFreight.Text,
                Convert.ToInt32(tBoxTourDistance.Text), Convert.ToInt32(tBoxJobIncome.Text));

            MessageBox.Show("Tour progress saved!", "Success", MessageBoxButtons.OK);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "TourLogger V" + Versioning.AppVersion + "\n" +
                "Developed by EnKdev\n" +
                "EnKVer (Full): " + Versioning.FullVersionString + "\n" +
                "EnKVer (Abbr): " + Versioning.AbbrVersionString, "About", MessageBoxButtons.OK);
        }

        private void ClearTextboxes()
        {
            foreach (TextBox tb in Controls.OfType<TextBox>())
                tb.Text = "";
        }
    }
}
