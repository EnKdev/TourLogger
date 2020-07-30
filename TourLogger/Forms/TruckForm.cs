using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TourLogger.Properties;
using TourLogger.Utils;

namespace TourLogger.Forms
{
    public partial class TruckForm : Form
    {
        private string _truck;
        private string _truckDriver;
        private MainForm _mf;
        private DataWriter _dw;

        public TruckForm()
        {
            InitializeComponent();
            _truckDriver = "";
            _truck = "";
            _mf = new MainForm();
            _dw = new DataWriter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            if (textBox1.Text != null)
            {
                switch (textBox1.Text)
                {
                    case "DAF XF 105":
                    case "XF 105":
                        _truck = "DAF XF 105";
                        pictureBox1.Image = Resources.XF105;
                        break;
                    case "DAF XF Euro 6":
                    case "XF Euro 6":
                        _truck = "DAF XF Euro 6";
                        pictureBox1.Image = Resources.XFEuro6;
                        break;
                    case "Iveco Stralis":
                    case "Stralis":
                        _truck = "Iveco Stralis";
                        pictureBox1.Image = Resources.Stralis;
                        break;
                    case "Iveco Stralis Hi-Way":
                    case "Stralis Hi-Way":
                        _truck = "Iveco Stralis Hi-Way";
                        pictureBox1.Image = Resources.StralisHiWay;
                        break;

                    case "MAN TGX":
                    case "TGX":
                        _truck = "MAN TGX";
                        pictureBox1.Image = Resources.TGX;
                        break;
                    case "MAN TGX Euro 6":
                    case "TGX Euro 6":
                        _truck = "MAN TGX Euro 6";
                        pictureBox1.Image = Resources.TGXEuro6;
                        break;

                    case "Mercedes-Benz Actros":
                    case "Actros":
                    case "MP3":
                        _truck = "Mercedes-Benz Actros";
                        pictureBox1.Image = Resources.Actros;
                        break;
                    case "Mercedes-Benz New Actros":
                    case "New Actros":
                    case "MP4":
                        _truck = "Mercedes-Benz New Actros";
                        pictureBox1.Image = Resources.NewActros;
                        break;

                    case "Renault Magnum":
                    case "Magnum":
                        _truck = "Renault Magnum";
                        pictureBox1.Image = Resources.Magnum;
                        break;
                    case "Renault Premium":
                    case "Premium":
                        _truck = "Renault Premium";
                        pictureBox1.Image = Resources.Premium;
                        break;
                    case "Renault T":
                    case "T":
                        _truck = "Renault T";
                        pictureBox1.Image = Resources.T;
                        break;

                    case "Scania R":
                    case "R":
                        _truck = "Scania R";
                        pictureBox1.Image = Resources.R;
                        break;
                    case "Scania R 2009":
                    case "R 2009":
                        _truck = "Scania R (2009)";
                        pictureBox1.Image = Resources.R2009;
                        break;
                    case "Scania S":
                    case "S":
                        _truck = "Scania S";
                        pictureBox1.Image = Resources.S;
                        break;
                    case "Scania Streamline":
                    case "Streamline":
                        _truck = "Scania Streamline";
                        pictureBox1.Image = Resources.Streamline;
                        break;

                    case "Volvo FH 2009":
                    case "FH 2009":
                        _truck = "Volvo FH16 (2009)";
                        pictureBox1.Image = Resources.FH162009;
                        break;
                    case "Volvo FH 2012":
                    case "FH 2012":
                        _truck = "Volvo FH16 (2012)";
                        pictureBox1.Image = Resources.FH162012;
                        break;

                    default:
                        _truck = textBox1.Text;
                        pictureBox1.Image = Resources.Custom;
                        break;
                }
            }

            _truckDriver = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _dw.WriteTruckData(_truck, _truckDriver);
            _mf.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://enkdev.xyz/docs/tourlogger/TruckHelp.html");
        }
    }
}
