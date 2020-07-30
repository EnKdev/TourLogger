namespace TourLogger.Forms
{
    partial class SingleTourForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleTourForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTourId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTDriver = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTFrom = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTTo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTFreight = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTTourDist = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTDrivenDist = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTJobIncome = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTOdo = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTFuelUsed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Showing Info for Tour:";
            // 
            // lblTourId
            // 
            this.lblTourId.AutoSize = true;
            this.lblTourId.Location = new System.Drawing.Point(184, 9);
            this.lblTourId.Name = "lblTourId";
            this.lblTourId.Size = new System.Drawing.Size(68, 19);
            this.lblTourId.TabIndex = 2;
            this.lblTourId.Text = "{TourID}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Driver:";
            // 
            // lblTDriver
            // 
            this.lblTDriver.AutoSize = true;
            this.lblTDriver.Location = new System.Drawing.Point(146, 69);
            this.lblTDriver.Name = "lblTDriver";
            this.lblTDriver.Size = new System.Drawing.Size(75, 19);
            this.lblTDriver.TabIndex = 4;
            this.lblTDriver.Text = "{TDriver}";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "From:";
            // 
            // lblTFrom
            // 
            this.lblTFrom.AutoSize = true;
            this.lblTFrom.Location = new System.Drawing.Point(146, 99);
            this.lblTFrom.Name = "lblTFrom";
            this.lblTFrom.Size = new System.Drawing.Size(68, 19);
            this.lblTFrom.TabIndex = 8;
            this.lblTFrom.Text = "{TFrom}";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "To:";
            // 
            // lblTTo
            // 
            this.lblTTo.AutoSize = true;
            this.lblTTo.Location = new System.Drawing.Point(146, 129);
            this.lblTTo.Name = "lblTTo";
            this.lblTTo.Size = new System.Drawing.Size(46, 19);
            this.lblTTo.TabIndex = 10;
            this.lblTTo.Text = "{TTo}";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Freight:";
            // 
            // lblTFreight
            // 
            this.lblTFreight.AutoSize = true;
            this.lblTFreight.Location = new System.Drawing.Point(146, 161);
            this.lblTFreight.Name = "lblTFreight";
            this.lblTFreight.Size = new System.Drawing.Size(81, 19);
            this.lblTFreight.TabIndex = 12;
            this.lblTFreight.Text = "{TFreight}";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Tour-Distance:";
            // 
            // lblTTourDist
            // 
            this.lblTTourDist.AutoSize = true;
            this.lblTTourDist.Location = new System.Drawing.Point(146, 191);
            this.lblTTourDist.Name = "lblTTourDist";
            this.lblTTourDist.Size = new System.Drawing.Size(90, 19);
            this.lblTTourDist.TabIndex = 14;
            this.lblTTourDist.Text = "{TTourDist}";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 19);
            this.label13.TabIndex = 15;
            this.label13.Text = "Driven Distance:";
            // 
            // lblTDrivenDist
            // 
            this.lblTDrivenDist.AutoSize = true;
            this.lblTDrivenDist.Location = new System.Drawing.Point(146, 222);
            this.lblTDrivenDist.Name = "lblTDrivenDist";
            this.lblTDrivenDist.Size = new System.Drawing.Size(105, 19);
            this.lblTDrivenDist.TabIndex = 16;
            this.lblTDrivenDist.Text = "{TDrivenDist}";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 252);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 19);
            this.label15.TabIndex = 17;
            this.label15.Text = "Job Income:";
            // 
            // lblTJobIncome
            // 
            this.lblTJobIncome.AutoSize = true;
            this.lblTJobIncome.Location = new System.Drawing.Point(146, 252);
            this.lblTJobIncome.Name = "lblTJobIncome";
            this.lblTJobIncome.Size = new System.Drawing.Size(108, 19);
            this.lblTJobIncome.TabIndex = 18;
            this.lblTJobIncome.Text = "{TJobIncome}";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 283);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 19);
            this.label17.TabIndex = 19;
            this.label17.Text = "ODO:";
            // 
            // lblTOdo
            // 
            this.lblTOdo.AutoSize = true;
            this.lblTOdo.Location = new System.Drawing.Point(146, 283);
            this.lblTOdo.Name = "lblTOdo";
            this.lblTOdo.Size = new System.Drawing.Size(57, 19);
            this.lblTOdo.TabIndex = 20;
            this.lblTOdo.Text = "{TOdo}";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 313);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 19);
            this.label19.TabIndex = 21;
            this.label19.Text = "Fuel Used:";
            // 
            // lblTFuelUsed
            // 
            this.lblTFuelUsed.AutoSize = true;
            this.lblTFuelUsed.Location = new System.Drawing.Point(146, 313);
            this.lblTFuelUsed.Name = "lblTFuelUsed";
            this.lblTFuelUsed.Size = new System.Drawing.Size(97, 19);
            this.lblTFuelUsed.TabIndex = 22;
            this.lblTFuelUsed.Text = "{TFuelUsed}";
            // 
            // SingleTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 405);
            this.Controls.Add(this.lblTFuelUsed);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblTOdo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblTJobIncome);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblTDrivenDist);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblTTourDist);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTFreight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTFrom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTDriver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTourId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SingleTourForm";
            this.Text = "TourLogger - Single Tour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTourId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTDriver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTFreight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTTourDist;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTDrivenDist;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTJobIncome;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTOdo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblTFuelUsed;
    }
}