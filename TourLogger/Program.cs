﻿using System;
using System.IO;
using System.Windows.Forms;
using TourLogger.Forms;

namespace TourLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SessionValidator());

            if (!Directory.Exists($"./Userdata/Legacy"))
                Directory.CreateDirectory($"./Userdata/Legacy");

            if (File.Exists($"./Userdata/Truck/data.json"))
            {
                File.Move($"./Userdata/Truck/data.json", $"./Userdata/Legacy/legacyTruckData.dat");
                Directory.Delete($"./Userdata/Truck/");
            }

            if (File.Exists($"./Userdata/Tour/data.json"))
            {
                File.Move($"./Userdata/Tour/data.json", $"./Userdata/Legacy/legacyTourData.dat");

                if (File.Exists($"./Userdata/Tour/tourProgress.json"))
                    File.Delete($"./Userdata/Tour/tourProgress.json");

                Directory.Delete($"./Userdata/Tour/");
            }

            if (!File.Exists($"./Userdata/truck.dat"))
            {
                MessageBox.Show("It seems that you have no profile yet.\nBefore using TourLogger, please create your profile file over at:\n https://enkdev.xyz/cdn/php/tourlogger/profile/gen.html, and once you downloaded the profile, save it in the Userdata folder of the app", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}