namespace TourLogger.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lDriver = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxTo = new System.Windows.Forms.TextBox();
            this.tBoxFreight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxTourDistance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBoxDrivenDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxJobIncome = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tBoxOdo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tBoxFuel = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lTruck = new System.Windows.Forms.Label();
            this.bSaveTour = new System.Windows.Forms.Button();
            this.bSaveProgress = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tBoxTourId = new System.Windows.Forms.TextBox();
            this.lblTourId = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.TourID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TruckUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TourDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistanceDriven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Driver:";
            // 
            // lDriver
            // 
            this.lDriver.AutoSize = true;
            this.lDriver.Location = new System.Drawing.Point(151, 34);
            this.lDriver.Name = "lDriver";
            this.lDriver.Size = new System.Drawing.Size(75, 19);
            this.lDriver.TabIndex = 1;
            this.lDriver.Text = "{TDriver}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "From:";
            // 
            // tBoxFrom
            // 
            this.tBoxFrom.Location = new System.Drawing.Point(155, 88);
            this.tBoxFrom.Name = "tBoxFrom";
            this.tBoxFrom.Size = new System.Drawing.Size(161, 27);
            this.tBoxFrom.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "To:";
            // 
            // tBoxTo
            // 
            this.tBoxTo.Location = new System.Drawing.Point(155, 120);
            this.tBoxTo.Name = "tBoxTo";
            this.tBoxTo.Size = new System.Drawing.Size(161, 27);
            this.tBoxTo.TabIndex = 5;
            // 
            // tBoxFreight
            // 
            this.tBoxFreight.Location = new System.Drawing.Point(155, 153);
            this.tBoxFreight.Name = "tBoxFreight";
            this.tBoxFreight.Size = new System.Drawing.Size(161, 27);
            this.tBoxFreight.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Freight:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tour-Distance:";
            // 
            // tBoxTourDistance
            // 
            this.tBoxTourDistance.Location = new System.Drawing.Point(155, 186);
            this.tBoxTourDistance.Name = "tBoxTourDistance";
            this.tBoxTourDistance.Size = new System.Drawing.Size(161, 27);
            this.tBoxTourDistance.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Driven Distance:";
            // 
            // tBoxDrivenDistance
            // 
            this.tBoxDrivenDistance.Location = new System.Drawing.Point(155, 219);
            this.tBoxDrivenDistance.Name = "tBoxDrivenDistance";
            this.tBoxDrivenDistance.Size = new System.Drawing.Size(161, 27);
            this.tBoxDrivenDistance.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Job Income:";
            // 
            // tBoxJobIncome
            // 
            this.tBoxJobIncome.Location = new System.Drawing.Point(155, 252);
            this.tBoxJobIncome.Name = "tBoxJobIncome";
            this.tBoxJobIncome.Size = new System.Drawing.Size(161, 27);
            this.tBoxJobIncome.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "€/$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "ODO:";
            // 
            // tBoxOdo
            // 
            this.tBoxOdo.Location = new System.Drawing.Point(155, 285);
            this.tBoxOdo.Name = "tBoxOdo";
            this.tBoxOdo.Size = new System.Drawing.Size(161, 27);
            this.tBoxOdo.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "km";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(322, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 19);
            this.label11.TabIndex = 18;
            this.label11.Text = "km";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(322, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 19);
            this.label12.TabIndex = 19;
            this.label12.Text = "km";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 321);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 19);
            this.label13.TabIndex = 20;
            this.label13.Text = "Fuel Used:";
            // 
            // tBoxFuel
            // 
            this.tBoxFuel.Location = new System.Drawing.Point(155, 318);
            this.tBoxFuel.Name = "tBoxFuel";
            this.tBoxFuel.Size = new System.Drawing.Size(161, 27);
            this.tBoxFuel.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(322, 321);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 19);
            this.label14.TabIndex = 22;
            this.label14.Text = "l";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 19);
            this.label15.TabIndex = 23;
            this.label15.Text = "Truck:";
            // 
            // lTruck
            // 
            this.lTruck.AutoSize = true;
            this.lTruck.Location = new System.Drawing.Point(151, 62);
            this.lTruck.Name = "lTruck";
            this.lTruck.Size = new System.Drawing.Size(69, 19);
            this.lTruck.TabIndex = 24;
            this.lTruck.Text = "{TTruck}";
            // 
            // bSaveTour
            // 
            this.bSaveTour.Location = new System.Drawing.Point(16, 354);
            this.bSaveTour.Name = "bSaveTour";
            this.bSaveTour.Size = new System.Drawing.Size(162, 36);
            this.bSaveTour.TabIndex = 25;
            this.bSaveTour.Text = "Save Tour";
            this.bSaveTour.UseVisualStyleBackColor = true;
            this.bSaveTour.Click += new System.EventHandler(this.bSaveTour_Click);
            // 
            // bSaveProgress
            // 
            this.bSaveProgress.Location = new System.Drawing.Point(184, 354);
            this.bSaveProgress.Name = "bSaveProgress";
            this.bSaveProgress.Size = new System.Drawing.Size(169, 36);
            this.bSaveProgress.TabIndex = 26;
            this.bSaveProgress.Text = "Save Progress";
            this.bSaveProgress.UseVisualStyleBackColor = true;
            this.bSaveProgress.Click += new System.EventHandler(this.bSaveProgress_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TourID,
            this.Driver,
            this.TruckUsed,
            this.From,
            this.To,
            this.Freight,
            this.TourDistance,
            this.DistanceDriven,
            this.JobIncome,
            this.ODO,
            this.FuelUsed});
            this.dataGridView1.Location = new System.Drawing.Point(375, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1234, 556);
            this.dataGridView1.TabIndex = 28;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 36);
            this.button2.TabIndex = 29;
            this.button2.Text = "Show Single Tour";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 36);
            this.button1.TabIndex = 27;
            this.button1.Text = "Refresh Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tBoxTourId
            // 
            this.tBoxTourId.Location = new System.Drawing.Point(253, 444);
            this.tBoxTourId.Name = "tBoxTourId";
            this.tBoxTourId.Size = new System.Drawing.Size(80, 27);
            this.tBoxTourId.TabIndex = 30;
            // 
            // lblTourId
            // 
            this.lblTourId.AutoSize = true;
            this.lblTourId.Location = new System.Drawing.Point(184, 447);
            this.lblTourId.Name = "lblTourId";
            this.lblTourId.Size = new System.Drawing.Size(63, 19);
            this.lblTourId.TabIndex = 31;
            this.lblTourId.Text = "Tour-ID";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1623, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rtbStatus
            // 
            this.rtbStatus.Location = new System.Drawing.Point(13, 481);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(344, 109);
            this.rtbStatus.TabIndex = 33;
            this.rtbStatus.Text = "";
            // 
            // TourID
            // 
            this.TourID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TourID.HeaderText = "Tour-ID";
            this.TourID.Name = "TourID";
            this.TourID.ReadOnly = true;
            this.TourID.Width = 88;
            // 
            // Driver
            // 
            this.Driver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Driver.HeaderText = "Driver";
            this.Driver.Name = "Driver";
            this.Driver.ReadOnly = true;
            this.Driver.Width = 80;
            // 
            // TruckUsed
            // 
            this.TruckUsed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TruckUsed.HeaderText = "Truck Used";
            this.TruckUsed.Name = "TruckUsed";
            this.TruckUsed.ReadOnly = true;
            this.TruckUsed.Width = 113;
            // 
            // From
            // 
            this.From.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            this.From.Width = 73;
            // 
            // To
            // 
            this.To.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.Width = 50;
            // 
            // Freight
            // 
            this.Freight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Freight.HeaderText = "Freight";
            this.Freight.Name = "Freight";
            this.Freight.ReadOnly = true;
            this.Freight.Width = 86;
            // 
            // TourDistance
            // 
            this.TourDistance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TourDistance.HeaderText = "Tour Distance";
            this.TourDistance.Name = "TourDistance";
            this.TourDistance.ReadOnly = true;
            this.TourDistance.Width = 133;
            // 
            // DistanceDriven
            // 
            this.DistanceDriven.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DistanceDriven.HeaderText = "Distance Driven";
            this.DistanceDriven.Name = "DistanceDriven";
            this.DistanceDriven.ReadOnly = true;
            this.DistanceDriven.Width = 136;
            // 
            // JobIncome
            // 
            this.JobIncome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.JobIncome.HeaderText = "Job Income";
            this.JobIncome.Name = "JobIncome";
            this.JobIncome.ReadOnly = true;
            this.JobIncome.Width = 107;
            // 
            // ODO
            // 
            this.ODO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ODO.HeaderText = "ODO";
            this.ODO.Name = "ODO";
            this.ODO.ReadOnly = true;
            this.ODO.Width = 65;
            // 
            // FuelUsed
            // 
            this.FuelUsed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FuelUsed.HeaderText = "Fuel Used";
            this.FuelUsed.Name = "FuelUsed";
            this.FuelUsed.ReadOnly = true;
            this.FuelUsed.Width = 97;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1623, 602);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.lblTourId);
            this.Controls.Add(this.tBoxTourId);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bSaveProgress);
            this.Controls.Add(this.bSaveTour);
            this.Controls.Add(this.lTruck);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tBoxFuel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tBoxOdo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tBoxJobIncome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBoxDrivenDistance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tBoxTourDistance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBoxFreight);
            this.Controls.Add(this.tBoxTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBoxFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lDriver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "TourLogger";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button bSaveProgress;
        private System.Windows.Forms.Button bSaveTour;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTourId;
        private System.Windows.Forms.Label lDriver;
        private System.Windows.Forms.Label lTruck;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox tBoxDrivenDistance;
        private System.Windows.Forms.TextBox tBoxFreight;
        private System.Windows.Forms.TextBox tBoxFrom;
        private System.Windows.Forms.TextBox tBoxFuel;
        private System.Windows.Forms.TextBox tBoxJobIncome;
        private System.Windows.Forms.TextBox tBoxOdo;
        private System.Windows.Forms.TextBox tBoxTo;
        private System.Windows.Forms.TextBox tBoxTourDistance;
        private System.Windows.Forms.TextBox tBoxTourId;

        #endregion

        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TourID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn TruckUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freight;
        private System.Windows.Forms.DataGridViewTextBoxColumn TourDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistanceDriven;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ODO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelUsed;
    }
}