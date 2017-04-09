using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace StudentsApplication {
    public partial class Form1 : Form {

        DataTable StudentData = new DataTable();

        public Form1() {
            InitializeComponent();
            StudentData = GetStudentsDataFromCSVFile(@"C:\Users\Eileen\Documents\Visual Studio 2015\Projects\StudentsApplication\student-mat2.csv");
        }

        private DataTable GetStudentsDataFromCSVFile(string path) {
            DataTable csvData = new DataTable();
            try {
                using (TextFieldParser csvReader = new TextFieldParser(path)) {
                    csvReader.SetDelimiters(new string[] { "\";\"", "\";", ";\"", ";" });
                    csvReader.HasFieldsEnclosedInQuotes = false;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields) {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = false;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData) {
                        string[] fieldData = csvReader.ReadFields();
                        for (int i = 0; i < fieldData.Length; i++) {
                            string newString = fieldData[i].Replace("\"", "");
                            fieldData[i] = newString;
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            } catch (Exception ex) {
                Console.Write(ex.Message);
            }
            foreach (DataRow row in csvData.Rows) {
                Console.WriteLine();
                for (int x = 0; x < csvData.Columns.Count; x++) {
                    Console.Write(row[x].ToString() + " ");
                }
            }
            return csvData;
        }

        public float CalculateAverageGrade(EnumerableRowCollection students) {
            int total = 0;
            int numStudents = 0;
            foreach (DataRow row in students) {
                int j;
                Int32.TryParse(row["G3"].ToString(), out j);
                total += j;
                numStudents++;
            }
            return ((float)total/(float)numStudents);
        }

        private void InternetAccess_Click(object sender, EventArgs e) {
            Dictionary<string, int> grades = new Dictionary<string, int>() {
                { "yes", 0 },
                { "yesStudents", 0 },
                { "no", 0 },
                { "noStudents", 0 }
            };
            
            EnumerableRowCollection rows = StudentData.AsEnumerable();
            foreach (DataRow student in rows) {
                // Get the proper key
                string key = student["internet"].ToString();

                // Get the student's score and update it accordingly
                int score;
                Int32.TryParse(student["G3"].ToString(), out score);
                grades[key] += score;

                // Update the correct student count
                grades[key + "Students"]++;
            }

            result.Text = "The average grade of students with internet access was " +  
                Math.Round(((float)grades["yes"] / (float)grades["yesStudents"]),2) + ".\n" + 
                " The average grade of students without internet access was " +
                Math.Round(((float)grades["no"] / (float)grades["noStudents"]), 2) + ".";
        }

        private void NumFailures_Click(object sender, EventArgs e) {
            EnumerableRowCollection rows = StudentData.AsEnumerable()
                .Where(row => row.Field<string>("famsize").IsNormalized());
            foreach (DataRow row in StudentData.AsEnumerable()) {
                Console.WriteLine(row["failures"]);
            }


        }

        private void StudyTime_Click(object sender, EventArgs e) {
            result.Text = StudentData.Rows[3]["studytime"].ToString();
        }

        private void Absences_Click(object sender, EventArgs e) {
            result.Text = StudentData.Rows[3]["absences"].ToString();
        }

        private void result_TextChanged(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
