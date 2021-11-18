using System.IO;
using System.Net;
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
        
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _dw = new DataWriter();
            
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

            var config = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText($"./Userdata/config.dat"));

            if (config != null)
            {
                var useExperimental = config.UsingExperimental.HasValue && config.UsingExperimental.Value;

                if (useExperimental)
                {
                    using var wc = new WebClient();
                    var experimentalAvailable = wc.DownloadString("https://enkdev.xyz/cdn/php/tourlogger/experimentalChannel.php");
                    wc.Dispose();

                    if (experimentalAvailable == "true")
                    {
                        AutoUpdater.Start("https://enkdev.xyz/cdn/software/tourlogger/update/update.experimental.xml");
                    }
                    else
                    {
                        AutoUpdater.Start("https://enkdev.xyz/cdn/software/tourlogger/update/update.xml");
                    }
                }
                else
                {
                    AutoUpdater.Start("https://enkdev.xyz/cdn/software/tourlogger/update/update.xml");
                }
            }

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

                if (!File.Exists($"./Userdata/truck.dat"))
                {
                    MessageBox.Show("It seems that you have no profile yet.\n" +
                                    "Before using TourLogger, please create your profile over at:\n" +
                                    "https://enkdev.xyz/cdn/php/tourlogger/profile/gen.html.\n" +
                                    "Once you downloaded your profile, save it in the Userdata folder of the app",
                        "Error", MessageBoxButton.OK);
                }
                else
                {
                    mw.Show();
                }
            }
        }
    }
}
