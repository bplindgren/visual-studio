namespace StudentsApplication {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.result = new System.Windows.Forms.TextBox();
            this.criteria = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(289, 12);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result.Size = new System.Drawing.Size(283, 203);
            this.result.TabIndex = 1;
            this.result.Text = "0";
            this.result.TextChanged += new System.EventHandler(this.result_TextChanged);
            // 
            // criteria
            // 
            this.criteria.FormattingEnabled = true;
            this.criteria.Items.AddRange(new object[] {
            "school",
            "sex",
            "age",
            "address",
            "famsize",
            "Pstatus",
            "Medu",
            "Fedu",
            "Mjob",
            "Fjob",
            "reason",
            "guardian",
            "traveltime",
            "studytime",
            "failures",
            "schoolsup",
            "famsup",
            "paid",
            "activities",
            "nursery",
            "higher",
            "internet",
            "romantic",
            "famrel",
            "freetime",
            "goout",
            "Dalc",
            "Walc",
            "health",
            "absences"});
            this.criteria.Location = new System.Drawing.Point(12, 37);
            this.criteria.MaxDropDownItems = 20;
            this.criteria.Name = "criteria";
            this.criteria.Size = new System.Drawing.Size(271, 21);
            this.criteria.TabIndex = 6;
            this.criteria.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Selected);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 221);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(560, 283);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Choose a Statistic";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 513);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.criteria);
            this.Controls.Add(this.result);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Student Grades";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.ComboBox criteria;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

