using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApplication {
    class Hangman {
        public List<string> WordList = new List<string>();
        public List<string> Drawing = new List<string> { "__________\n", "|      | \n", "|\n", "|\n", "|\n", "|      O \n", "|      | \n", "|    --| \n", "|    --|-- \n", "|     / \n", "|     / \\ \n" };
        public List<char> IncorrectGuesses = new List<char>();
        public char[] WordToGuess { get; set; }
        public char[] WordDisplay;
        public int GuessesRemaining;

        public Hangman() {
            // Populate the word list
            foreach (string line in File.ReadLines("../../../HangManWords.txt"))
                WordList.Add(line.ToLower());
        }

        public void ChooseWord() {
            Random r = new Random();
            int random = r.Next(0, WordList.Count-1);
            WordToGuess = WordList[random].ToCharArray();
            WordDisplay = Enumerable.Repeat('*', WordToGuess.Length).ToArray();
        }

        public static void Proceed(string answer) {
            if (answer.Equals("y")) {
                Console.WriteLine("Great, let's get started. \n");
                System.Threading.Thread.Sleep(500);
            } else if (answer.Equals("n")) {
                Console.WriteLine("Fine, cya later.");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            } else {
                Console.WriteLine("Cmon buddy, it's a yes or no question. You want to play? (Y/N)");
                string response = Console.ReadLine().ToLower();
                Proceed(response);
            }
        }

        public char PromptGuess() {
            Console.WriteLine("Guess a letter: ");
            char input = System.Convert.ToChar(Console.ReadLine().ToLower().Substring(0, 1));
            return input;
        }

        public string ShowWord() {
            return String.Join("", WordDisplay);
        }

        public string ShowIncorrectGuesses() {
            return String.Join(" ", IncorrectGuesses);
        }

        public bool CheckGuess(char letter) {
            bool correctGuess = false;
            for (int i = 0; i < WordToGuess.Count(); i++) {
                if (WordToGuess[i].Equals(letter)) {
                    WordDisplay[i] = letter;
                    correctGuess = true;
                } 
            }

            if (!correctGuess)
                IncorrectGuesses.Add(letter);

            return correctGuess;
        }

        public string DisplayMan() {
            switch (GuessesRemaining) {
                case 6:
                    return (Drawing[0] + Drawing[1] + Drawing[2] + Drawing[3] + Drawing[4]);
                case 5:
                    return (Drawing[0] + Drawing[1] + Drawing[5] + Drawing[2] + Drawing[3]);
                case 4:
                    return (Drawing[0] + Drawing[1] + Drawing[5] + Drawing[6] + Drawing[3]);
                case 3:
                    return (Drawing[0] + Drawing[1] + Drawing[5] + Drawing[7] + Drawing[3]);
                case 2:
                    return (Drawing[0] + Drawing[1] + Drawing[5] + Drawing[8] + Drawing[3]);
                case 1:
                    return (Drawing[0] + Drawing[1] + Drawing[5] + Drawing[8] + Drawing[9]);
                case 0:
                    return (Drawing[0] + Drawing[1] + Drawing[5] + Drawing[8] + Drawing[10]);
                default:
                    return ("default case");
            }
        }

        public void PlayGame() {
            GuessesRemaining = 6;
            while ((GuessesRemaining > 0) && (WordDisplay.Contains('*'))) {
                Console.WriteLine(DisplayMan());
                Console.WriteLine("\nGuessesRemaining: " + GuessesRemaining);
                Console.WriteLine("Incorrect Guesses: " + ShowIncorrectGuesses());
                Console.WriteLine("Here is your word: " + ShowWord() + '\n');
                char guess = PromptGuess();

                if (CheckGuess(guess)) {
                    continue;
                } else {
                    GuessesRemaining--;
                }
            }

            if (GuessesRemaining == 0) {
                Console.WriteLine(DisplayMan());
                Console.WriteLine("Sorry, you're out of guesses. Better luck next time, n00b. \nThe correct answer was " + String.Join("", WordToGuess) + "\n");
                System.Threading.Thread.Sleep(500);
            }
            if (!WordDisplay.Contains('*')) {
                Console.WriteLine("Congrats buddy, you won. The word was '" + ShowWord() + ".'\n");
                System.Threading.Thread.Sleep(500);
            }

            IncorrectGuesses.Clear();
        }

        static void Main(string[] args) {
            Hangman hangman = new Hangman();

            Console.WriteLine("Ready for a new game of Hangman? (Y/N)");
            string answer = Console.ReadLine().ToLower();

            while (answer != "n") {
                Proceed(answer);

                hangman.ChooseWord();

                hangman.PlayGame();

                Console.WriteLine("Ready for a new game of Hangman? (Y/N)");
                answer = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Thanks for playing");
        }

    }
}
