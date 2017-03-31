using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApplication {
    class Hangman {
        public List<string> WordList = new List<string>();
        public List<string> Drawing = new List<string> { "__________\n", "|      | \n", "|      O \n", "|      | \n", "|     /| \n", "|     /|\\ \n", "|     / \n", "|     / \\ \n" };
        public List<string> IncorrectGuesses = new List<string>();
        public char[] WordToGuess { get; set; }
        public string[] WordDisplay;

        public Hangman() {
            // Populate the word list
            foreach (string line in File.ReadLines("../../../HangManWords.txt"))
                WordList.Add(line);
        }

        public void ChooseWord() {
            Random r = new Random();
            int random = r.Next(0, WordList.Count-1);
            WordToGuess = WordList[random].ToCharArray();
            WordDisplay = Enumerable.Repeat("*", WordToGuess.Length).ToArray();
        }

        public static void Proceed(string answer) {
            if (answer.Equals("y")) {
                Console.WriteLine("Great, let's get started.");
                System.Threading.Thread.Sleep(1500);
            } else if (answer.Equals("n")) {
                Console.WriteLine("Fine, cya later.");
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
            } else {
                Console.WriteLine("Cmon buddy, it's a yes or no question. You want to play? (Y/N)");
                string response = Console.ReadLine().ToLower();
                Proceed(response);
            }
        }

        public string PromptGuess() {
            Console.WriteLine("Guess a letter: ");
            return Console.ReadLine().ToLower();
        }

        public string ShowWord() {
            return String.Join("", WordDisplay);
        }

        public bool CheckGuess(string letter) {
            for (int i = 0; i < WordToGuess.Count(); i++) {
                if (WordToGuess[i].Equals(letter)) {
                    WordDisplay[i] = letter;
                    return true;
                } 
            }
            return false;
        }

        static void Main(string[] args) {
            Hangman hangman = new Hangman();

            Console.WriteLine("Ready for a new game of Hangman? (Y/N)");
            string answer = Console.ReadLine().ToLower();

            Proceed(answer);

            hangman.ChooseWord();

            int GuessesRemaining = 6;
            while ((hangman.IncorrectGuesses.Count()) < 6 && (Array.IndexOf(hangman.WordDisplay, "*") > 0)) {
                Console.WriteLine("GuessesRemaining: " + GuessesRemaining);
                Console.WriteLine("Here is your word: " + hangman.ShowWord());
                string guess = hangman.PromptGuess();

                if (hangman.CheckGuess(guess)) {
                    continue;
                } else {
                    GuessesRemaining--;
                }
            }


        }
    }
}
