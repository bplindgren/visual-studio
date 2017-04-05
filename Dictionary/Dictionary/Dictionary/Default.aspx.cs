using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Dictionary {
    public partial class _Default : Page {

        public List<string> Words = new List<string>();

        public string myString = "Hello123";

        protected void Page_Load(object sender, EventArgs e) {

            try {   
                foreach (string line in File.ReadLines(@"C:\Users\Eileen\Documents\Visual Studio 2015\Projects\Dictionary\Dictionary\dictionary-words2.txt")) { 
                        Words.Add(line);
                }
            } catch (Exception ex) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> GetWords() {
            return Words;
        }

        protected void myButton_Click(object sender, EventArgs e) {
            //Result.Text = string.Format("{0}, {1}", ddlLetter.Text, ddlQuery.Text);

            if (ddlQuery.Text.Equals("begin")) {
                int count = 0;
                foreach(string word in Words) {
                    if (word.StartsWith(ddlLetter.Text)) {
                        count++;
                    }
                }
                Result.Text = "There are " + count.ToString() + " words that start with the letter '" + ddlLetter.Text + "'";
            }

            if (ddlQuery.Text.Equals("end")) {
                int count = 0;
                foreach (string word in Words) {
                    if (word.EndsWith(ddlLetter.Text)) {
                        count++;
                    }
                }
                Result.Text = "There are " + count.ToString() + " words that end with the letter '" + ddlLetter.Text + "'";
            }

            if (ddlQuery.Text.Equals("avgNumChar")) {
                List<string> letterArray = new List<string>();
                foreach(string word in Words) {
                    if (word.StartsWith(ddlLetter.Text)) {
                        letterArray.Add(word);
                    }
                }

                string longStr = String.Join("", letterArray);
                float avg = ((float)longStr.Length / (float)letterArray.Count);
                Result.Text = "The average length of a word that starts with '" + ddlLetter.Text + "' is " + avg;
            }
        }
    }
}