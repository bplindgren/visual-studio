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

        private Dictionary<string, int> BuildDictionary(string statistic) {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            EnumerableRowCollection rows = StudentData.AsEnumerable();

            foreach (DataRow student in rows) {
                // Get the correct key
                string key = student[statistic].ToString();

                // Get the student's score
                int score;
                Int32.TryParse(student["G3"].ToString(), out score);

                if (dict.ContainsKey(key)) {
                    // Update the dictionary accordingly
                    dict[key] += score;
                    dict[key + "Students"]++;
                } else {
                    // Update dictionary accordingly
                    dict.Add(key, score);
                    dict.Add((key + "Students"), 1);
                }
            }
            return dict;
        }

        private string GenerateOutput(Dictionary<string, int> stats) {
            string outputString = "";

            foreach (string key in stats.Keys) {
                if(!key.Contains("Students")) {
                    outputString += (key + "=>" + Math.Round(((float)stats[key] / (float)stats[key + "Students"]), 2)+ ", ");
                }
            }
            return outputString.Substring(0, outputString.Length - 1);
        }

        private void Button_Click(object sender, EventArgs e) {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            Button b = (Button)sender;

            // Build a new dictionary with results for the button clicked
            dictionary = BuildDictionary(b.Text);

            // Generate an output string
            result.Text = GenerateOutput(dictionary);
        }

        private void result_TextChanged(object sender, EventArgs e) {
        }

        private void Form1_Load(object sender, EventArgs e) {
        }
    }
}
