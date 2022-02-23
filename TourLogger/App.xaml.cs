using System;
using System.IO;
using System.Windows;
using AutoUpdaterDotNET;
using Newtonsoft.Json;
using TourLogger.Models;
using TourLogger.Utils;
using TourLogger.Windows;

namespace TourLogger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DataWriter _dw;
        private PhpHandler _ph;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            if (e.Args[0] == "-fromLauncher")
            {
                _dw = new DataWriter();
                _ph = new PhpHandler();

                var svw = new SessionValidatorWindow();
                var mw = new MainWindow();

                Versioning.SetAppVersion(false);
                SecretGrabber.GrabSecret();

                var updatePath = $"./Update";

                if (!Directory.Exists(updatePath))
                {
                    Directory.CreateDirectory(updatePath);
                }

                if (!File.Exists($"./Userdata/config.dat"))
                {
                    _dw.WriteDefaultConfigFile();
                }

                // Cache Migration
                if (File.Exists($"./Userdata/cache.dat"))
                {
                    File.Copy($"./Userdata/cache.dat", $"./Userdata/tourCache.dat");
                    File.Delete($"./Userdata/cache.dat");
                }

                AutoUpdater.DownloadPath = updatePath;

                #if STABLE
                AutoUpdater.Start("https://enkdev.xyz/cdn/software/tourlogger/update/update.xml");
                #elif EXPERIMENTAL
                AutoUpdater.Start("https://enkdev.xyz/cdn/tourlogger/update/update.experimental.xml");
                #endif


                if (AutoUpdater.Mandatory)
                {
                    AutoUpdater.ShowUpdateForm(new UpdateInfoEventArgs());
                }
                else
                {
                    // Show Session Validator after Updates been checked.
                    svw.ShowDialog();

                    if (!Directory.Exists($"./Userdata/Legacy"))
                    {
                        Directory.CreateDirectory($"./Userdata/Legacy");
                    }

                    if (File.Exists($"./Userdata/Truck/data.json"))
                    {
                        File.Move($"./Userdata/Truck/data.json", $"./Userdata/Legacy/legacyTruckData.dat");
                        Directory.Delete($"./Userdata/Truck/");
                    }

                    if (File.Exists($"./Userdata/Tour/data.json"))
                    {
                        File.Move($"./Userdata/Tour/data.json", $"./Userdata/Legacy/legacyTourData.dat");

                        if (File.Exists($"./Userdata/Tour/tourProgress.json"))
                        {
                            File.Delete($"./Userdata/Tour/tourProgress.json");
                        }

                        Directory.Delete($"./Userdata/Tour/");
                    }

                    if (File.Exists($"./Userdata/truck.dat"))
                    {
                        try
                        {
                            // Read profile
                            var profile =
                                JsonConvert.DeserializeObject<TruckModel>(File.ReadAllText($"./Userdata/truck.dat"));

                            if (profile != null)
                            {
                                _ph.MigrateProfile(profile.Driver, profile.Truck);
                                File.Copy($"./Userdata/truck.dat", $"./Userdata/oldProfile.dat");
                                File.Move($"./Userdata/truck.dat", $"./Userdata/Legacy/truck.dat");
                                mw.Show();
                            }
                        }
                        catch (TourLoggerException tex)
                        {
                            MessageBox.Show("An exception occured!\n" +
                                            $"{tex.Message}", "Error migrating profile.", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                    else if (!File.Exists($"./Userdata/account.dat"))
                    {
                        var naw = new NewAccountWindow();
                        naw.Show();
                    }
                    else
                    {
                        mw.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("TourLogger 7.1.0 requires you to launch the app from the launcher!", "Error launching",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }
        }
    }
}
