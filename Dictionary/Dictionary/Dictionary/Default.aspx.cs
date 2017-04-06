using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.Entity;

namespace Dictionary {
    public partial class _Default : Page {

        public List<string> Words = new List<string>();

        protected void Page_Load(object sender, EventArgs e) {
            try {
                foreach (string line in File.ReadLines(@"C:\Users\Eileen\Documents\Visual Studio 2015\Projects\Dictionary\Dictionary\dictionary-words.txt")) {
                    Word word = new Word();
                    word.Text = line;
                    Words.Add(line);
                }
            } catch (Exception ex) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> GetLetterWords(string letter) {
            // Get a List of the words that start with the specified letter
            return Words.Where((word) => word[0].ToString() == (letter)).ToList();
        }

        public string GenerateOutputString(List<string> words) {
            string output = "";
            foreach(string word in words) {
                output += (word + "\n");
            }
            return output;
        }

        protected void myButton_Click(object sender, EventArgs e) {

            switch (ddlQuery.Text) {
                case ("begin"):
                    int beginCount = Words.Where((word) => word[0].ToString() == (ddlLetter.Text)).Count();

                    Result.Text = "There are " + beginCount.ToString() + " words that start with the letter '" + ddlLetter.Text + "'";
                    break;

                case ("end"):
                    int endCount = Words.Where((word) => word[word.Length - 1].ToString() == (ddlLetter.Text)).Count();

                    Result.Text = "There are " + endCount.ToString() + " words that end with the letter '" + ddlLetter.Text + "'";
                    break;

                case ("avgNumChar"):
                    List<string> letterList = GetLetterWords(ddlLetter.Text);

                    // Join the words into one string and divide it by the length of letterList
                    string longStr = String.Join("", letterList);
                    float avg = (float)Math.Round(((float)longStr.Length / (float)letterList.Count), 2);

                    Result.Text = "The average length of a word that starts with '" + ddlLetter.Text + "' is " + avg;
                    break;

                case ("shortest"):
                    List<string> letterWords = GetLetterWords(ddlLetter.Text);
                    
                    int shortLength = letterWords.OrderBy(x => x.Length).ToList()[0].Length;

                    // Get all words whose length == shortLength
                    List<string> shortestWords = letterWords.Where((word) => word.Length == shortLength).ToList();
                    
                    string shortString = GenerateOutputString(shortestWords);

                    Result.Text = "The ten shortest words that start with '" + ddlLetter.Text + "' are: \n" + shortString;
                    break;

                case ("longest"):
                    List<string> letterWords2 = GetLetterWords(ddlLetter.Text);
                    
                    int longLength = letterWords2.OrderBy(x => x.Length).ToList()[letterWords2.Count - 1].Length;

                    // Get all words whose length == longLength
                    List<string> longestWords = letterWords2.Where((word) => word.Length == longLength).ToList();
                    
                    string longString = GenerateOutputString(longestWords);

                    Result.Text = "The ten longest words that start with '" + ddlLetter.Text + "' are: \n" + longString;
                    break;
            }
        }

    }
}