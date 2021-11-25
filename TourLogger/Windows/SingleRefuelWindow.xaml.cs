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

namespace TourLogger.Windows
{
    /// <summary>
    /// Interaktionslogik für SingleRefuelWindow.xaml
    /// </summary>
    public partial class SingleRefuelWindow : Window
    {
        private string _refuelId;
        private string _refuelDriver;
        private string _refuelCountry;
        private string _refuelLiterPrice;
        private string _refuelOdo;
        private string _refuelAmount;
        private string _refuelTotalPrice;

        public SingleRefuelWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        public void CarryValuesOverToWindow(string[] valueArray)
        {
            _refuelId = valueArray[0];
            _refuelDriver = valueArray[1];
            _refuelCountry = valueArray[2];
            _refuelLiterPrice = valueArray[3];
            _refuelOdo = valueArray[4];
            _refuelAmount = valueArray[5];
            _refuelTotalPrice = valueArray[6];
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }

        private void Bt_Ok_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateWindow()
        {
            lb_RefuelId.Content = _refuelId;
            lb_Driver.Content = _refuelDriver;
            lb_Country.Content = _refuelCountry;
            lb_LiterPrice.Content = _refuelLiterPrice;
            lb_Odo.Content = _refuelOdo;
            lb_LiterAmount.Content = _refuelAmount;
            lb_TotalPrice.Content = _refuelTotalPrice;
        }
    }
}
