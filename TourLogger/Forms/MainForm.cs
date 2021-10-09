using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using TourLogger.Models;
using TourLogger.Utils;

namespace TourLogger.Forms
{
	public class MainForm : Form
	{
		private PhpIntegration _pi;

		private DataWriter _dw;

		private IContainer components = null;

		private ToolStripMenuItem aboutToolStripMenuItem;

		private Button bSaveProgress;

		private Button bSaveTour;

		private Button button1;

		private Button button2;

		private DataGridView dataGridView1;

		private Label label1;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label lblTourId;

		private Label lDriver;

		private Label lTruck;

		private MenuStrip menuStrip1;

		private TextBox tBoxDrivenDistance;

		private TextBox tBoxFreight;

		private TextBox tBoxFrom;

		private TextBox tBoxFuel;

		private TextBox tBoxJobIncome;

		private TextBox tBoxOdo;

		private TextBox tBoxTo;

		private TextBox tBoxTourDistance;

		private TextBox tBoxTourId;

		private RichTextBox rtbStatus;

		private DataGridViewTextBoxColumn TourID;

		private DataGridViewTextBoxColumn Driver;

		private DataGridViewTextBoxColumn TruckUsed;

		private DataGridViewTextBoxColumn From;

		private DataGridViewTextBoxColumn To;

		private DataGridViewTextBoxColumn Freight;

		private DataGridViewTextBoxColumn TourDistance;

		private DataGridViewTextBoxColumn DistanceDriven;

		private DataGridViewTextBoxColumn JobIncome;

		private DataGridViewTextBoxColumn ODO;

		private DataGridViewTextBoxColumn FuelUsed;

		public MainForm()
		{
			this.InitializeComponent();
			this._pi = new PhpIntegration();
			this._dw = new DataWriter();
			this.CheckVersions();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(string.Concat(new string[] { "TourLogger V", Versioning.AppVersion, "\nDeveloped by EnKdev\nEnKVer (Full): ", Versioning.FullVersionString, "\nEnKVer (Abbr): ", Versioning.AbbrVersionString }), "About", MessageBoxButtons.OK);
		}

		private void bSaveProgress_Click(object sender, EventArgs e)
		{
			int tDist;
			int jobInc;
			try
			{
				tDist = (this.tBoxTourDistance.Text != string.Empty ? int.Parse(this.tBoxTourDistance.Text) : 0);
				jobInc = (this.tBoxJobIncome.Text != string.Empty ? int.Parse(this.tBoxJobIncome.Text) : 0);
				this._dw.WriteProgressingTourData(this.lDriver.Text, this.lTruck.Text, this.tBoxFrom.Text, this.tBoxTo.Text, this.tBoxFreight.Text, tDist, jobInc);
				MessageBox.Show("Tour progress saved!", "Success", MessageBoxButtons.OK);
			}
			catch (Exception exception)
			{
				Exception ex = exception;
				MessageBox.Show(string.Concat("An unknown error occured while trying saving the tour.\nPlease refer to the exception message:\n-------------------\n", ex.Message, "\nat:\n", ex.StackTrace), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void bSaveTour_Click(object sender, EventArgs e)
		{
			this._pi.SendTourToServer(this.lDriver.Text, this.lTruck.Text, this.tBoxFrom.Text, this.tBoxTo.Text, this.tBoxFreight.Text, Convert.ToInt32(this.tBoxTourDistance.Text), Convert.ToInt32(this.tBoxDrivenDistance.Text), Convert.ToInt32(this.tBoxJobIncome.Text), Convert.ToInt32(this.tBoxOdo.Text), Convert.ToInt32(this.tBoxFuel.Text));
			if (File.Exists("./Userdata/progress.dat"))
			{
				File.Delete("./Userdata/progress.dat");
			}
			MessageBox.Show("Tour saved!", "Success!", MessageBoxButtons.OK);
			this.ClearTextboxes();
			Thread.Sleep(500);
			this.RefreshTourTable();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.RefreshTourTable();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SingleTourForm stf = new SingleTourForm();
			string tour = this._pi.FetchTour(Convert.ToInt32(this.tBoxTourId.Text));
			char[] sep = new char[] { '|' };
			tour = tour.Replace(" -> ", "|");
			stf.CarryValuesOverToForm(tour.Split(sep, StringSplitOptions.RemoveEmptyEntries));
			Thread.Sleep(500);
			stf.Show();
		}

		private void CheckVersions()
		{
			bool[] validVersions = this._pi.CheckVersions();
			for (int i = 0; i < (int)validVersions.Length; i++)
			{
				if (!validVersions[i])
				{
					switch (i)
					{
						case 0:
						{
							this.rtbStatus.AppendText("App is outdated!\n");
							break;
						}
						case 1:
						{
							this.rtbStatus.AppendText("FileFormat is outdated!\n");
							break;
						}
						case 2:
						{
							this.rtbStatus.AppendText("DbVersion is outdated!\n");
							break;
						}
						case 3:
						{
							this.rtbStatus.AppendText("Secret is outdated!\n");
							break;
						}
					}
				}
				else
				{
					switch (i)
					{
						case 0:
						{
							this.rtbStatus.AppendText("AppVersion is OK!\n");
							break;
						}
						case 1:
						{
							this.rtbStatus.AppendText("FileFormat is OK!\n");
							break;
						}
						case 2:
						{
							this.rtbStatus.AppendText("DbVersion is OK!\n");
							break;
						}
						case 3:
						{
							this.rtbStatus.AppendText("Secret is OK!\n");
							break;
						}
					}
				}
			}
		}

		private void ClearTextboxes()
		{
			foreach (TextBox tb in base.Controls.OfType<TextBox>())
			{
				tb.Text = "";
			}
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
			this.label1 = new Label();
			this.lDriver = new Label();
			this.label3 = new Label();
			this.tBoxFrom = new TextBox();
			this.label4 = new Label();
			this.tBoxTo = new TextBox();
			this.tBoxFreight = new TextBox();
			this.label5 = new Label();
			this.label6 = new Label();
			this.tBoxTourDistance = new TextBox();
			this.label7 = new Label();
			this.tBoxDrivenDistance = new TextBox();
			this.label2 = new Label();
			this.tBoxJobIncome = new TextBox();
			this.label8 = new Label();
			this.label9 = new Label();
			this.tBoxOdo = new TextBox();
			this.label10 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.label13 = new Label();
			this.tBoxFuel = new TextBox();
			this.label14 = new Label();
			this.label15 = new Label();
			this.lTruck = new Label();
			this.bSaveTour = new Button();
			this.bSaveProgress = new Button();
			this.dataGridView1 = new DataGridView();
			this.button2 = new Button();
			this.button1 = new Button();
			this.tBoxTourId = new TextBox();
			this.lblTourId = new Label();
			this.menuStrip1 = new MenuStrip();
			this.aboutToolStripMenuItem = new ToolStripMenuItem();
			this.rtbStatus = new RichTextBox();
			this.TourID = new DataGridViewTextBoxColumn();
			this.Driver = new DataGridViewTextBoxColumn();
			this.TruckUsed = new DataGridViewTextBoxColumn();
			this.From = new DataGridViewTextBoxColumn();
			this.To = new DataGridViewTextBoxColumn();
			this.Freight = new DataGridViewTextBoxColumn();
			this.TourDistance = new DataGridViewTextBoxColumn();
			this.DistanceDriven = new DataGridViewTextBoxColumn();
			this.JobIncome = new DataGridViewTextBoxColumn();
			this.ODO = new DataGridViewTextBoxColumn();
			this.FuelUsed = new DataGridViewTextBoxColumn();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.menuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Driver:";
			this.lDriver.AutoSize = true;
			this.lDriver.Location = new Point(151, 34);
			this.lDriver.Name = "lDriver";
			this.lDriver.Size = new System.Drawing.Size(75, 19);
			this.lDriver.TabIndex = 1;
			this.lDriver.Text = "{TDriver}";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "From:";
			this.tBoxFrom.Location = new Point(155, 88);
			this.tBoxFrom.Name = "tBoxFrom";
			this.tBoxFrom.Size = new System.Drawing.Size(161, 27);
			this.tBoxFrom.TabIndex = 3;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(12, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "To:";
			this.tBoxTo.Location = new Point(155, 120);
			this.tBoxTo.Name = "tBoxTo";
			this.tBoxTo.Size = new System.Drawing.Size(161, 27);
			this.tBoxTo.TabIndex = 5;
			this.tBoxFreight.Location = new Point(155, 153);
			this.tBoxFreight.Name = "tBoxFreight";
			this.tBoxFreight.Size = new System.Drawing.Size(161, 27);
			this.tBoxFreight.TabIndex = 6;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(12, 156);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 19);
			this.label5.TabIndex = 7;
			this.label5.Text = "Freight:";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(12, 189);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(115, 19);
			this.label6.TabIndex = 8;
			this.label6.Text = "Tour-Distance:";
			this.tBoxTourDistance.Location = new Point(155, 186);
			this.tBoxTourDistance.Name = "tBoxTourDistance";
			this.tBoxTourDistance.Size = new System.Drawing.Size(161, 27);
			this.tBoxTourDistance.TabIndex = 9;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(12, 222);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 19);
			this.label7.TabIndex = 10;
			this.label7.Text = "Driven Distance:";
			this.tBoxDrivenDistance.Location = new Point(155, 219);
			this.tBoxDrivenDistance.Name = "tBoxDrivenDistance";
			this.tBoxDrivenDistance.Size = new System.Drawing.Size(161, 27);
			this.tBoxDrivenDistance.TabIndex = 11;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 255);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 19);
			this.label2.TabIndex = 12;
			this.label2.Text = "Job Income:";
			this.tBoxJobIncome.Location = new Point(155, 252);
			this.tBoxJobIncome.Name = "tBoxJobIncome";
			this.tBoxJobIncome.Size = new System.Drawing.Size(161, 27);
			this.tBoxJobIncome.TabIndex = 13;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(322, 255);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 19);
			this.label8.TabIndex = 14;
			this.label8.Text = "€/$";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(12, 288);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 19);
			this.label9.TabIndex = 15;
			this.label9.Text = "ODO:";
			this.tBoxOdo.Location = new Point(155, 285);
			this.tBoxOdo.Name = "tBoxOdo";
			this.tBoxOdo.Size = new System.Drawing.Size(161, 27);
			this.tBoxOdo.TabIndex = 16;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(322, 222);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(31, 19);
			this.label10.TabIndex = 17;
			this.label10.Text = "km";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(322, 189);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(31, 19);
			this.label11.TabIndex = 18;
			this.label11.Text = "km";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(322, 288);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(31, 19);
			this.label12.TabIndex = 19;
			this.label12.Text = "km";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(12, 321);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(85, 19);
			this.label13.TabIndex = 20;
			this.label13.Text = "Fuel Used:";
			this.tBoxFuel.Location = new Point(155, 318);
			this.tBoxFuel.Name = "tBoxFuel";
			this.tBoxFuel.Size = new System.Drawing.Size(161, 27);
			this.tBoxFuel.TabIndex = 21;
			this.label14.AutoSize = true;
			this.label14.Location = new Point(322, 321);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(14, 19);
			this.label14.TabIndex = 22;
			this.label14.Text = "l";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(12, 62);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(52, 19);
			this.label15.TabIndex = 23;
			this.label15.Text = "Truck:";
			this.lTruck.AutoSize = true;
			this.lTruck.Location = new Point(151, 62);
			this.lTruck.Name = "lTruck";
			this.lTruck.Size = new System.Drawing.Size(69, 19);
			this.lTruck.TabIndex = 24;
			this.lTruck.Text = "{TTruck}";
			this.bSaveTour.Location = new Point(16, 354);
			this.bSaveTour.Name = "bSaveTour";
			this.bSaveTour.Size = new System.Drawing.Size(162, 36);
			this.bSaveTour.TabIndex = 25;
			this.bSaveTour.Text = "Save Tour";
			this.bSaveTour.UseVisualStyleBackColor = true;
			this.bSaveTour.Click += new EventHandler(this.bSaveTour_Click);
			this.bSaveProgress.Location = new Point(184, 354);
			this.bSaveProgress.Name = "bSaveProgress";
			this.bSaveProgress.Size = new System.Drawing.Size(169, 36);
			this.bSaveProgress.TabIndex = 26;
			this.bSaveProgress.Text = "Save Progress";
			this.bSaveProgress.UseVisualStyleBackColor = true;
			this.bSaveProgress.Click += new EventHandler(this.bSaveProgress_Click);
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.TourID, this.Driver, this.TruckUsed, this.From, this.To, this.Freight, this.TourDistance, this.DistanceDriven, this.JobIncome, this.ODO, this.FuelUsed });
			this.dataGridView1.Location = new Point(375, 34);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(1234, 556);
			this.dataGridView1.TabIndex = 28;
			this.button2.Location = new Point(16, 438);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(162, 36);
			this.button2.TabIndex = 29;
			this.button2.Text = "Show Single Tour";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.button1.Location = new Point(103, 396);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(161, 36);
			this.button1.TabIndex = 27;
			this.button1.Text = "Refresh Table";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.tBoxTourId.Location = new Point(253, 444);
			this.tBoxTourId.Name = "tBoxTourId";
			this.tBoxTourId.Size = new System.Drawing.Size(80, 27);
			this.tBoxTourId.TabIndex = 30;
			this.lblTourId.AutoSize = true;
			this.lblTourId.Location = new Point(184, 447);
			this.lblTourId.Name = "lblTourId";
			this.lblTourId.Size = new System.Drawing.Size(63, 19);
			this.lblTourId.TabIndex = 31;
			this.lblTourId.Text = "Tour-ID";
			this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.aboutToolStripMenuItem });
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1623, 24);
			this.menuStrip1.TabIndex = 32;
			this.menuStrip1.Text = "menuStrip1";
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
			this.rtbStatus.Location = new Point(13, 481);
			this.rtbStatus.Name = "rtbStatus";
			this.rtbStatus.Size = new System.Drawing.Size(344, 109);
			this.rtbStatus.TabIndex = 33;
			this.rtbStatus.Text = "";
			this.TourID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.TourID.HeaderText = "Tour-ID";
			this.TourID.Name = "TourID";
			this.TourID.ReadOnly = true;
			this.TourID.Width = 88;
			this.Driver.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.Driver.HeaderText = "Driver";
			this.Driver.Name = "Driver";
			this.Driver.ReadOnly = true;
			this.Driver.Width = 80;
			this.TruckUsed.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.TruckUsed.HeaderText = "Truck Used";
			this.TruckUsed.Name = "TruckUsed";
			this.TruckUsed.ReadOnly = true;
			this.TruckUsed.Width = 113;
			this.From.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.From.HeaderText = "From";
			this.From.Name = "From";
			this.From.ReadOnly = true;
			this.From.Width = 73;
			this.To.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.To.HeaderText = "To";
			this.To.Name = "To";
			this.To.Width = 50;
			this.Freight.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.Freight.HeaderText = "Freight";
			this.Freight.Name = "Freight";
			this.Freight.ReadOnly = true;
			this.Freight.Width = 86;
			this.TourDistance.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.TourDistance.HeaderText = "Tour Distance";
			this.TourDistance.Name = "TourDistance";
			this.TourDistance.ReadOnly = true;
			this.TourDistance.Width = 133;
			this.DistanceDriven.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.DistanceDriven.HeaderText = "Distance Driven";
			this.DistanceDriven.Name = "DistanceDriven";
			this.DistanceDriven.ReadOnly = true;
			this.DistanceDriven.Width = 136;
			this.JobIncome.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.JobIncome.HeaderText = "Job Income";
			this.JobIncome.Name = "JobIncome";
			this.JobIncome.ReadOnly = true;
			this.JobIncome.Width = 107;
			this.ODO.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.ODO.HeaderText = "ODO";
			this.ODO.Name = "ODO";
			this.ODO.ReadOnly = true;
			this.ODO.Width = 65;
			this.FuelUsed.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.FuelUsed.HeaderText = "Fuel Used";
			this.FuelUsed.Name = "FuelUsed";
			this.FuelUsed.ReadOnly = true;
			this.FuelUsed.Width = 97;
			base.AutoScaleDimensions = new SizeF(9f, 19f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1623, 602);
			base.Controls.Add(this.rtbStatus);
			base.Controls.Add(this.lblTourId);
			base.Controls.Add(this.tBoxTourId);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.dataGridView1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.bSaveProgress);
			base.Controls.Add(this.bSaveTour);
			base.Controls.Add(this.lTruck);
			base.Controls.Add(this.label15);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.tBoxFuel);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.tBoxOdo);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.tBoxJobIncome);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tBoxDrivenDistance);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.tBoxTourDistance);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.tBoxFreight);
			base.Controls.Add(this.tBoxTo);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.tBoxFrom);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lDriver);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Bahnschrift", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip1;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "MainForm";
			this.Text = "TourLogger";
			base.Load += new EventHandler(this.MainForm_Load);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void LoadGeneralDetails()
		{
			TruckModel truck = JsonConvert.DeserializeObject<TruckModel>(File.ReadAllText("./Userdata/truck.dat"));
			this.lDriver.Text = truck.Driver;
			this.lTruck.Text = truck.Truck;
		}

		private void LoadTourData()
		{
			CacheModel tours = JsonConvert.DeserializeObject<CacheModel>(File.ReadAllText("./Userdata/cache.dat"));
			for (int i = 0; i < (int)tours.CachedTours.Length; i++)
			{
				this.dataGridView1.Rows.Add();
				this.dataGridView1.Rows.Insert(i, new object[] { tours.CachedTours[i].Id, tours.CachedTours[i].Driver, tours.CachedTours[i].Truck, tours.CachedTours[i].From, tours.CachedTours[i].To, tours.CachedTours[i].Freight, tours.CachedTours[i].Distance, tours.CachedTours[i].Driven, tours.CachedTours[i].Income, tours.CachedTours[i].Total, tours.CachedTours[i].Fuel });
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (!File.Exists("./Userdata/truck.dat"))
			{
				this.lDriver.Text = "Driver not found!";
				this.lTruck.Text = "Truck not found!";
			}
			else
			{
				this.LoadGeneralDetails();
			}
			if (!File.Exists("./Userdata/cache.dat"))
			{
				this.RefreshTourTable();
			}
			else
			{
				this.LoadTourData();
			}
			if (File.Exists("./Userdata/progress.dat"))
			{
				this.ReadProgressingTour();
			}
		}

		private void ReadProgressingTour()
		{
			SingleTourModel json = JsonConvert.DeserializeObject<SingleTourModel>(File.ReadAllText("./Userdata/progress.dat"));
			this.tBoxFrom.Text = json.TourFrom;
			this.tBoxTo.Text = json.TourTo;
			this.tBoxFreight.Text = json.TourFreight;
			this.tBoxTourDistance.Text = json.TourDistance.ToString();
			this.tBoxDrivenDistance.Text = "0";
			this.tBoxJobIncome.Text = json.JobIncome.ToString();
			this.tBoxOdo.Text = "0";
			this.tBoxFuel.Text = "0";
		}

		private void RefreshTourTable()
		{
			this._pi.FetchDatabaseEntries();
			CacheModel tours = JsonConvert.DeserializeObject<CacheModel>(File.ReadAllText("./Userdata/cache.dat"));
			this.dataGridView1.Rows.Clear();
			this.dataGridView1.Refresh();
			Thread.Sleep(1000);
			for (int i = 0; i < (int)tours.CachedTours.Length; i++)
			{
				this.dataGridView1.Rows.Add();
				this.dataGridView1.Rows.Insert(i, new object[] { tours.CachedTours[i].Id, tours.CachedTours[i].Driver, tours.CachedTours[i].Truck, tours.CachedTours[i].From, tours.CachedTours[i].To, tours.CachedTours[i].Freight, tours.CachedTours[i].Distance, tours.CachedTours[i].Driven, tours.CachedTours[i].Income, tours.CachedTours[i].Total, tours.CachedTours[i].Fuel });
			}
		}
	}
}