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
    /// Interaktionslogik für SingleTourWindow.xaml
    /// </summary>
    public partial class SingleTourWindow : Window
    {
        private string _tourId;
        private string _tourDriver;
        private string _tourTruck;
        private string _tFrom;
        private string _tTo;
        private string _tFreight;
        private string _tTourDist;
        private string _tDrivenDist;
        private string _tJobIncome;
        private string _tOdo;
        private string _tFuelUsed;

        public SingleTourWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        public void CarryValuesOverToWindow(string[] valueArray)
        {
            _tourId = valueArray[0];
            _tourDriver = valueArray[1];
            _tourTruck = valueArray[2];
            _tFrom = valueArray[3];
            _tTo = valueArray[4];
            _tFreight = valueArray[5];
            _tTourDist = valueArray[6];
            _tDrivenDist = valueArray[7];
            _tJobIncome = valueArray[8];
            _tOdo = valueArray[9];
            _tFuelUsed = valueArray[10];
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateWindow()
        {
            lb_TourId.Content = _tourId;
            lb_Driver.Content = _tourDriver;
            lb_Truck.Content = _tourTruck;
            lb_From.Content = _tFrom;
            lb_To.Content = _tTo;
            lb_Freight.Content = _tFreight;
            lb_TourDist.Content = _tTourDist;
            lb_Driven.Content = _tDrivenDist;
            lb_JobIncome.Content = _tJobIncome;
            lb_Odo.Content = _tOdo;
            lb_Fuel.Content = _tFuelUsed;
        }
    }
}
