using System;
using System.Drawing;
using System.Windows.Forms;
using EnKdev.SessionPass;
using TourLogger.Properties;

namespace TourLogger.Forms
{
    public partial class SessionValidator : Form
    {
        private string _otsvCode;
        private OtsvCode _oc;
        private bool _isSameCode;
        
        public SessionValidator()
        {
            InitializeComponent();
            _otsvCode = "";
            _oc = new OtsvCode();
            _isSameCode = false;
            label3.Text = "";
            label5.Text = "";
            button1.Text = "Waiting for Result...";
            UpdateForm();
        }

        private void GetOtsvCode()
        {
            _otsvCode = _oc.RequestOtsvCode(1); // Request a normal length Session Code
        }

        private void CompareCode()
        {
            _isSameCode = _oc.CompareOtsvCode(_otsvCode, 1); // Compare code
        }

        private void UpdateButtonControls()
        {
            if (_isSameCode)
            {
                button1.Text = "Continue";
                button1.Click += ContinueApplication;
            }
            else
            {
                button1.Text = "Exit Application";
                button1.Click += CloseApplication;
            }
        }

        private void UpdateForm()
        {
            label1.Text = "Fetching Session-Code...";
            GetOtsvCode();
            label3.Text = _otsvCode;
            CompareCode();

            if (_isSameCode)
            {
                label1.Text = "Code is valid!";
                pictureBox1.Image = Resources.valid;
                label5.ForeColor = Color.Green;
                label5.Text = "Code Valid!";
            }
            else
            {
                label1.Text = "Code is invalid!";
                pictureBox1.Image = Resources.invalid;
                label5.ForeColor = Color.Red;
                label5.Text = "Code invalid";
            }

            button1.Enabled = true;
            UpdateButtonControls();
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