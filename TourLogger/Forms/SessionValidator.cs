using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EnKdev.SessionPass;
using TourLogger.Properties;

namespace TourLogger.Forms
{
	public class SessionValidator : Form
	{
		private string _otsvCode;

		private OtsvCode _oc;

		private bool _isSameCode;

		private IContainer components = null;

		private Button button1;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private PictureBox pictureBox1;

		public SessionValidator()
		{
			this.InitializeComponent();
			this._otsvCode = "";
			this._oc = new OtsvCode();
			this._isSameCode = false;
			this.label3.Text = "";
			this.label5.Text = "";
			this.button1.Text = "Waiting for Result...";
			this.UpdateForm();
		}

		private void CloseApplication(object sender, EventArgs e)
		{
			Environment.Exit(-1);
		}

		private void CompareCode()
		{
			this._isSameCode = this._oc.CompareOtsvCode(this._otsvCode, 1);
		}

		private void ContinueApplication(object sender, EventArgs e)
		{
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void GetOtsvCode()
		{
			this._otsvCode = this._oc.RequestOtsvCode(1);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(SessionValidator));
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.button1 = new Button();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label1.Location = new Point(67, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fetching Session-Code...";
			this.pictureBox1.Image = Resources.load;
			this.pictureBox1.Location = new Point(13, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 50);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.label2.Location = new Point(9, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Session-Code:";
			this.label3.Location = new Point(130, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(234, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "{SessionCode}";
			this.label4.Location = new Point(9, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Valid:";
			this.label5.Location = new Point(130, 119);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(129, 23);
			this.label5.TabIndex = 5;
			this.label5.Text = "{Validation}";
			this.button1.Enabled = false;
			this.button1.Location = new Point(424, 119);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(243, 27);
			this.button1.TabIndex = 6;
			this.button1.Text = "Continue";
			this.button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(9f, 19f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(679, 158);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Bahnschrift", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "SessionValidator";
			this.Text = "Session Validator";
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		private void UpdateButtonControls()
		{
			if (!this._isSameCode)
			{
				this.button1.Text = "Exit Application";
				this.button1.Click += new EventHandler(this.CloseApplication);
			}
			else
			{
				this.button1.Text = "Continue";
				this.button1.Click += new EventHandler(this.ContinueApplication);
			}
		}

		private void UpdateForm()
		{
			this.label1.Text = "Fetching Session-Code...";
			this.GetOtsvCode();
			this.label3.Text = this._otsvCode;
			this.CompareCode();
			if (!this._isSameCode)
			{
				this.label1.Text = "Code is invalid!";
				this.pictureBox1.Image = Resources.invalid;
				this.label5.ForeColor = Color.Red;
				this.label5.Text = "Code invalid";
			}
			else
			{
				this.label1.Text = "Code is valid!";
				this.pictureBox1.Image = Resources.valid;
				this.label5.ForeColor = Color.Green;
				this.label5.Text = "Code Valid!";
			}
			this.button1.Enabled = true;
			this.UpdateButtonControls();
		}
	}
}