using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using EnKdev.SessionPass;

namespace TourLogger.Windows
{
    /// <summary>
    /// Interaktionslogik für SessionValidatorWindow.xaml
    /// </summary>
    public partial class SessionValidatorWindow : Window
    {
        private string _otsvCode;
        private readonly OtsvCode _oc;
        private bool _isSameCode;

        public SessionValidatorWindow()
        {
            InitializeComponent();
            _otsvCode = "";
            _oc = new OtsvCode();
            _isSameCode = false;
            lb_Status.Content = "";
            lb_SessionCode.Content = "";
            bt_Continue.Content = "Waiting for Result...";
            UpdateWindow();
        }

        private void GetOtsvCode()
        {
            _otsvCode = _oc.RequestOtsvCode(1); // Request a normal length session code
        }

        private void CompareCode()
        {
            _isSameCode = _oc.CompareOtsvCode(_otsvCode, 1); // code code
        }

        private void UpdateButton()
        {
            if (_isSameCode)
            {
                bt_Continue.Content = "Continue";
                bt_Continue.Click += ContinueApplication;
            }
            else
            {
                bt_Continue.Content = "Exit application";
                bt_Continue.Click += CloseApplication;
            }
        }

        private void UpdateWindow()
        {
            lb_Status.Content = "Fetching Session-Code...";
            GetOtsvCode();
            lb_Code.Content = _otsvCode;
            CompareCode();

            if (_isSameCode)
            {
                lb_Status.Content = "Code is valid!";
                img_LoadStatus.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/valid.png"));
                lb_ValidCode.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                lb_ValidCode.Content = "Code valid!";
            }
            else
            {
                lb_Status.Content = "Code is invalid!";
                img_LoadStatus.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/invalid.png"));
                lb_ValidCode.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                lb_ValidCode.Content = "Code invalid!";
            }

            bt_Continue.IsEnabled = true;
            UpdateButton();
        }

        private void ContinueApplication(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseApplication(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
