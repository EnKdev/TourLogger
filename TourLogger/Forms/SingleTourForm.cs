using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace TourLogger.Forms
{
	public class SingleTourForm : Form
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

		private IContainer components = null;

		private Button button1;

		private Label label1;

		private Label label11;

		private Label label13;

		private Label label15;

		private Label label17;

		private Label label19;

		private Label label2;

		private Label label3;

		private Label label6;

		private Label label7;

		private Label label9;

		private Label lblTDrivenDist;

		private Label lblTDriver;

		private Label lblTFreight;

		private Label lblTFrom;

		private Label lblTFuelUsed;

		private Label lblTJobIncome;

		private Label lblTOdo;

		private Label lblTourId;

		private Label lblTTo;

		private Label lblTTourDist;

		private Label lblTTruck;

		public SingleTourForm()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		public void CarryValuesOverToForm(string[] valueArray)
		{
			this._tourId = valueArray[0];
			this._tourDriver = valueArray[1];
			this._tourTruck = valueArray[2];
			this._tFrom = valueArray[3];
			this._tTo = valueArray[4];
			this._tFreight = valueArray[5];
			this._tTourDist = valueArray[6];
			this._tDrivenDist = valueArray[7];
			this._tJobIncome = valueArray[8];
			this._tOdo = valueArray[9];
			this._tFuelUsed = valueArray[10];
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(SingleTourForm));
			this.button1 = new Button();
			this.label1 = new Label();
			this.lblTourId = new Label();
			this.label3 = new Label();
			this.lblTDriver = new Label();
			this.label7 = new Label();
			this.lblTFrom = new Label();
			this.label6 = new Label();
			this.lblTTo = new Label();
			this.label9 = new Label();
			this.lblTFreight = new Label();
			this.label11 = new Label();
			this.lblTTourDist = new Label();
			this.label13 = new Label();
			this.lblTDrivenDist = new Label();
			this.label15 = new Label();
			this.lblTJobIncome = new Label();
			this.label17 = new Label();
			this.lblTOdo = new Label();
			this.label19 = new Label();
			this.lblTFuelUsed = new Label();
			this.label2 = new Label();
			this.lblTTruck = new Label();
			base.SuspendLayout();
			this.button1.Location = new Point(12, 392);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(78, 37);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Showing Info for Tour:";
			this.lblTourId.AutoSize = true;
			this.lblTourId.Location = new Point(184, 9);
			this.lblTourId.Name = "lblTourId";
			this.lblTourId.Size = new System.Drawing.Size(68, 19);
			this.lblTourId.TabIndex = 2;
			this.lblTourId.Text = "{TourID}";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Driver:";
			this.lblTDriver.AutoSize = true;
			this.lblTDriver.Location = new Point(146, 69);
			this.lblTDriver.Name = "lblTDriver";
			this.lblTDriver.Size = new System.Drawing.Size(75, 19);
			this.lblTDriver.TabIndex = 4;
			this.lblTDriver.Text = "{TDriver}";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(12, 125);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 19);
			this.label7.TabIndex = 7;
			this.label7.Text = "From:";
			this.lblTFrom.AutoSize = true;
			this.lblTFrom.Location = new Point(146, 125);
			this.lblTFrom.Name = "lblTFrom";
			this.lblTFrom.Size = new System.Drawing.Size(68, 19);
			this.lblTFrom.TabIndex = 8;
			this.lblTFrom.Text = "{TFrom}";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(12, 155);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 19);
			this.label6.TabIndex = 9;
			this.label6.Text = "To:";
			this.lblTTo.AutoSize = true;
			this.lblTTo.Location = new Point(146, 155);
			this.lblTTo.Name = "lblTTo";
			this.lblTTo.Size = new System.Drawing.Size(46, 19);
			this.lblTTo.TabIndex = 10;
			this.lblTTo.Text = "{TTo}";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(12, 187);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 19);
			this.label9.TabIndex = 11;
			this.label9.Text = "Freight:";
			this.lblTFreight.AutoSize = true;
			this.lblTFreight.Location = new Point(146, 187);
			this.lblTFreight.Name = "lblTFreight";
			this.lblTFreight.Size = new System.Drawing.Size(81, 19);
			this.lblTFreight.TabIndex = 12;
			this.lblTFreight.Text = "{TFreight}";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(12, 217);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(115, 19);
			this.label11.TabIndex = 13;
			this.label11.Text = "Tour-Distance:";
			this.lblTTourDist.AutoSize = true;
			this.lblTTourDist.Location = new Point(146, 217);
			this.lblTTourDist.Name = "lblTTourDist";
			this.lblTTourDist.Size = new System.Drawing.Size(90, 19);
			this.lblTTourDist.TabIndex = 14;
			this.lblTTourDist.Text = "{TTourDist}";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(12, 248);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(128, 19);
			this.label13.TabIndex = 15;
			this.label13.Text = "Driven Distance:";
			this.lblTDrivenDist.AutoSize = true;
			this.lblTDrivenDist.Location = new Point(146, 248);
			this.lblTDrivenDist.Name = "lblTDrivenDist";
			this.lblTDrivenDist.Size = new System.Drawing.Size(105, 19);
			this.lblTDrivenDist.TabIndex = 16;
			this.lblTDrivenDist.Text = "{TDrivenDist}";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(12, 278);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 19);
			this.label15.TabIndex = 17;
			this.label15.Text = "Job Income:";
			this.lblTJobIncome.AutoSize = true;
			this.lblTJobIncome.Location = new Point(146, 278);
			this.lblTJobIncome.Name = "lblTJobIncome";
			this.lblTJobIncome.Size = new System.Drawing.Size(108, 19);
			this.lblTJobIncome.TabIndex = 18;
			this.lblTJobIncome.Text = "{TJobIncome}";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(12, 309);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(44, 19);
			this.label17.TabIndex = 19;
			this.label17.Text = "ODO:";
			this.lblTOdo.AutoSize = true;
			this.lblTOdo.Location = new Point(146, 309);
			this.lblTOdo.Name = "lblTOdo";
			this.lblTOdo.Size = new System.Drawing.Size(57, 19);
			this.lblTOdo.TabIndex = 20;
			this.lblTOdo.Text = "{TOdo}";
			this.label19.AutoSize = true;
			this.label19.Location = new Point(12, 339);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(85, 19);
			this.label19.TabIndex = 21;
			this.label19.Text = "Fuel Used:";
			this.lblTFuelUsed.AutoSize = true;
			this.lblTFuelUsed.Location = new Point(146, 339);
			this.lblTFuelUsed.Name = "lblTFuelUsed";
			this.lblTFuelUsed.Size = new System.Drawing.Size(97, 19);
			this.lblTFuelUsed.TabIndex = 22;
			this.lblTFuelUsed.Text = "{TFuelUsed}";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 19);
			this.label2.TabIndex = 23;
			this.label2.Text = "Truck:";
			this.lblTTruck.AutoSize = true;
			this.lblTTruck.Location = new Point(146, 97);
			this.lblTTruck.Name = "lblTTruck";
			this.lblTTruck.Size = new System.Drawing.Size(69, 19);
			this.lblTTruck.TabIndex = 24;
			this.lblTTruck.Text = "{TTruck}";
			base.AutoScaleDimensions = new SizeF(9f, 19f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(426, 461);
			base.Controls.Add(this.lblTTruck);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lblTFuelUsed);
			base.Controls.Add(this.label19);
			base.Controls.Add(this.lblTOdo);
			base.Controls.Add(this.label17);
			base.Controls.Add(this.lblTJobIncome);
			base.Controls.Add(this.label15);
			base.Controls.Add(this.lblTDrivenDist);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.lblTTourDist);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.lblTFreight);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.lblTTo);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.lblTFrom);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.lblTDriver);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblTourId);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Bahnschrift", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "SingleTourForm";
			this.Text = "TourLogger - Single Tour";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		protected override void OnShown(EventArgs e)
		{
			this.UpdateForm();
		}

		private void UpdateForm()
		{
			this.lblTourId.Text = this._tourId;
			this.lblTDriver.Text = this._tourDriver;
			this.lblTTruck.Text = this._tourTruck;
			this.lblTFrom.Text = this._tFrom;
			this.lblTTo.Text = this._tTo;
			this.lblTFreight.Text = this._tFreight;
			this.lblTTourDist.Text = this._tTourDist;
			this.lblTDrivenDist.Text = this._tDrivenDist;
			this.lblTJobIncome.Text = this._tJobIncome;
			this.lblTOdo.Text = this._tOdo;
			this.lblTFuelUsed.Text = this._tFuelUsed;
		}
	}
}