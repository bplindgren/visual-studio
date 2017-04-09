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
            this.InternetAccess = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.NumFailures = new System.Windows.Forms.Button();
            this.StudyTime = new System.Windows.Forms.Button();
            this.Absences = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InternetAccess
            // 
            this.InternetAccess.Location = new System.Drawing.Point(12, 12);
            this.InternetAccess.Name = "InternetAccess";
            this.InternetAccess.Size = new System.Drawing.Size(97, 45);
            this.InternetAccess.TabIndex = 0;
            this.InternetAccess.Text = "internet";
            this.InternetAccess.UseVisualStyleBackColor = true;
            this.InternetAccess.Click += new System.EventHandler(this.Button_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(246, 12);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(326, 120);
            this.result.TabIndex = 1;
            this.result.Text = "0";
            this.result.TextChanged += new System.EventHandler(this.result_TextChanged);
            // 
            // NumFailures
            // 
            this.NumFailures.Location = new System.Drawing.Point(12, 74);
            this.NumFailures.Name = "NumFailures";
            this.NumFailures.Size = new System.Drawing.Size(97, 45);
            this.NumFailures.TabIndex = 2;
            this.NumFailures.Text = "failures";
            this.NumFailures.UseVisualStyleBackColor = true;
            this.NumFailures.Click += new System.EventHandler(this.Button_Click);
            // 
            // StudyTime
            // 
            this.StudyTime.Location = new System.Drawing.Point(12, 138);
            this.StudyTime.Name = "StudyTime";
            this.StudyTime.Size = new System.Drawing.Size(97, 45);
            this.StudyTime.TabIndex = 3;
            this.StudyTime.Text = "studytime";
            this.StudyTime.UseVisualStyleBackColor = true;
            this.StudyTime.Click += new System.EventHandler(this.Button_Click);
            // 
            // Absences
            // 
            this.Absences.Location = new System.Drawing.Point(12, 204);
            this.Absences.Name = "Absences";
            this.Absences.Size = new System.Drawing.Size(97, 45);
            this.Absences.TabIndex = 4;
            this.Absences.Text = "absences";
            this.Absences.UseVisualStyleBackColor = true;
            this.Absences.Click += new System.EventHandler(this.Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.Absences);
            this.Controls.Add(this.StudyTime);
            this.Controls.Add(this.NumFailures);
            this.Controls.Add(this.result);
            this.Controls.Add(this.InternetAccess);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Student Grades";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InternetAccess;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button NumFailures;
        private System.Windows.Forms.Button StudyTime;
        private System.Windows.Forms.Button Absences;
    }
}

