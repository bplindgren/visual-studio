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
            StudentData = GetStudentsDataFromCSVFile(@"C:\Users\Eileen\Documents\Visual Studio 2015\Projects\StudentsApplication\student-mat.csv");
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
            return csvData;
        }

        private SortedDictionary<string, int> BuildDictionary(string statistic) {
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
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

        private List<KeyValuePair<string, double>> GetSortedResults(List<KeyValuePair<string, double>> list) {
            int key;
            if ((Int32.TryParse(list[0].Key, out key)) == true) {
                // Change the string keys to int keys
                List<KeyValuePair<int, double>> sorted = new List<KeyValuePair<int, double>>();
                List<KeyValuePair<int, double>> sortedList2 = new List<KeyValuePair<int, double>>();
                foreach (KeyValuePair<string, double> kvp in list) {
                    int keyInt;
                    Int32.TryParse(kvp.Key, out keyInt);
                    sorted.Add(new KeyValuePair<int, double>(keyInt, kvp.Value));
                    // sort by int keys
                    sortedList2 = sorted.OrderBy(x => x.Key).ToList();
                }

                // Change the keys back to strings
                List<KeyValuePair<string, double>> sortedString = new List<KeyValuePair<string, double>>();
                foreach (KeyValuePair<int, double> kv in sortedList2) {
                    sortedString.Add(new KeyValuePair<string, double>(kv.Key.ToString(), kv.Value));
                }
                return sortedString;
            } else {
                return list.OrderBy(o => o.Key).ToList();
            }
        }


        private string GenerateOutput(SortedDictionary<string, int> stats) {
            List<KeyValuePair<string, double>> results = new List<KeyValuePair<string, double>>();

            // To add a value to results, find its value in stats SortedDictionary and divide it by the numStudents for that value
            foreach (string key in stats.Keys) {
                if (!key.Contains("Students")) {
                    KeyValuePair<string, double> option = new KeyValuePair<string, double>(key, Math.Round(((float)stats[key] / (float)stats[key + "Students"]), 2));
                    results.Add(option);
                }
            }

            // Sort the results (because the keys need to be converted to ints to be properly sorted in some cases)
            List<KeyValuePair<string, double>> sortedResults = GetSortedResults(results);

            string outputString = "";

            foreach (KeyValuePair<string, double> kvp in sortedResults) {
                outputString += (kvp.Key + " => " + kvp.Value + "\r\n");  
            }

            return outputString;
        }

        private void ComboBox_Selected(object sender, EventArgs e) {
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();

            ComboBox cb = (ComboBox)sender;

            // Build a new dictionary with results for the button clicked
            dictionary = BuildDictionary(cb.Text);

            // Generate an output string
            result.Text = GenerateOutput(dictionary);

            // Clear old results from chart and add new results
            this.chart1.Series["Series1"].Points.Clear();
            foreach (string key in dictionary.Keys) {
                if (!key.Contains("Students")) {
                    this.chart1.Series["Series1"].Points.AddXY(key, Math.Round(((float)dictionary[key] / (float)dictionary[key + "Students"]), 2));
                }
            }
        }

        private void result_TextChanged(object sender, EventArgs e) {
        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }
        
    }
}
