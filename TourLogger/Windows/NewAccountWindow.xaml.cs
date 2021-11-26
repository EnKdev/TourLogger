using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TourLogger.Utils;

namespace TourLogger.Windows
{
    /// <summary>
    /// Interaktionslogik für NewAccountWindow.xaml
    /// </summary>
    public partial class NewAccountWindow : Window
    {
        private readonly PhpHandler _ph;

        public NewAccountWindow()
        {
            InitializeComponent();
            _ph = new PhpHandler();
        }

        private void Bt_Submit_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                InternalBuffer.NewAccountName = tb_Name.Text;
                _ph.CreateAccount(tb_Name.Text, tb_Truck.Text);
                var mw = new MainWindow();
                mw.Show();
                Close();
            }
            catch (TourLoggerException tex)
            {
                MessageBox.Show("An exception occured!\n" +
                                $"{tex.Message}", "Error creating new account.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
