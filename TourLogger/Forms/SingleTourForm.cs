using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TourLogger.Forms
{
    public partial class SingleTourForm : Form
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

        public SingleTourForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            UpdateForm();
        }

        public void CarryValuesOverToForm(string[] valueArray)
        {
            _tourId = valueArray[0];
            _tourDriver = valueArray[1];
            _tourTruck = valueArray[2];
            _tFrom = valueArray[3];
            _tTo = valueArray[4];
            _tFreight = valueArray[5];
            _tTourDist = valueArray[6];
            _tDrivenDist =valueArray[7];
            _tJobIncome = valueArray[8];
            _tOdo = valueArray[9];
            _tFuelUsed = valueArray[10];
        }

        private void UpdateForm()
        {
            lblTourId.Text = _tourId;
            lblTDriver.Text = _tourDriver;
            lblTTruck.Text = _tourTruck;
            lblTFrom.Text = _tFrom;
            lblTTo.Text = _tTo;
            lblTFreight.Text = _tFreight;
            lblTTourDist.Text = _tTourDist;
            lblTDrivenDist.Text = _tDrivenDist;
            lblTJobIncome.Text = _tJobIncome;
            lblTOdo.Text = _tOdo;
            lblTFuelUsed.Text = _tFuelUsed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
