using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Media;
using AutoUpdaterDotNET;
using Process = System.Diagnostics.Process;

namespace TourLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Disabled by default until experimental channel has been checked.
            bt_Unstable.IsEnabled = false;

            CheckExperimentalStatus();
            CheckLauncher();
        }

        private void Bt_Stable_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var programPath = $"./stable/TourLogger.exe";
                var proc = new Process();

                proc.StartInfo.FileName = programPath;
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(programPath);
                proc.StartInfo.Arguments = "-fromLauncher";
                proc.Start();

                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred");
            }
        }

        private void Bt_Unstable_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                var programPath = $"./beta/TourLogger.exe";
                var proc = new Process();

                proc.StartInfo.FileName = programPath;
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(programPath);
                proc.StartInfo.Arguments = "-fromLauncher";
                proc.Start();

                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred");
            }
        }

        private void Bt_Quit_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void CheckExperimentalStatus()
        {
            using var wc = new WebClient();
            var experimentalOpen = wc.DownloadString("https://enkdev.xyz/cdn/php/tourlogger/experimentalChannel.php");
            wc.Dispose();

            if (experimentalOpen == "true")
            {
                lb_expStatus.Content = "Available";
                lb_expStatus.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                bt_Unstable.IsEnabled = true;
            }
            else
            {
                lb_expStatus.Content = "Unavailable";
                lb_expStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                bt_Unstable.IsEnabled = false;
            }
        }

        private void CheckLauncher()
        {
            AutoUpdater.Start("https://enkdev.xyz/cdn/software/tourlauncher/update.xml");
        }
    }
}
