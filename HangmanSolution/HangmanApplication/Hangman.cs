using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApplication {
    class Hangman {
        public List<string> WordList = new List<string>();
        public List<string> Drawing = new List<string>
            { "\n__________\n",
              "|      | \n",
              "|\n",
              "|\n",
              "|\n",
              "|      O \n",
              "|      | \n",
              "|    --| \n",
              "|    --|-- \n",
              "|     / \n",
              "|     / \\ \n" };
        public List<char> IncorrectGuesses = new List<char>();
        public char[] WordToGuess;
        public char[] WordDisplay;
        public int GuessesRemaining;

        public Hangman(string path) {
            if (File.Exists(path)) {
                // Check that the file is not empty
                long length = new System.IO.FileInfo(path).Length;
                if (length < 1) {
                    throw new Exception("This file doesn't have any words in it. Sorry Charlie.");
                } else {
                    // Populate the word list
                    foreach (string line in File.ReadLines(path))
                        WordList.Add(line.ToLower());
                }
            } else {
                throw new FileNotFoundException("The file was not found");
            }
        }

        public void ChooseWord() {
            Random r = new Random();
            int random = r.Next(0, WordList.Count-1);
            WordToGuess = WordList[random].ToCharArray();
            WordDisplay = Enumerable.Repeat('*', WordToGuess.Length).ToArray();
        }

        public void Proceed(string answer) {
            if (answer.Equals("y")) {
                Console.WriteLine("Great, let's get started. \n");
                System.Threading.Thread.Sleep(500);
            } else if (answer.Equals("n")) {
                Console.WriteLine("Fine, cya later.");
                System.Threading.Thread.Sleep(500);
                Environment.Exit(0);
            } else {
                Console.WriteLine("Cmon buddy, it's a yes or no question. Do you want to play? (y/n)");
                string response = Console.ReadLine().ToLower();
                Proceed(response);
            }
        }

        public char PromptGuess() {
            Console.WriteLine("Guess a letter: ");
            char input = Console.ReadKey().KeyChar.ToString().ToCharArray()[0];
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
            // Iterate over the WordToGuess char[] to determine good/bad guess
            for (int i = 0; i < WordToGuess.Count(); i++) {
                // If the guess was a good guess, file correctGuess to true
                if (WordToGuess[i].Equals(letter)) {
                    WordDisplay[i] = letter;
                    correctGuess = true;
                } 
            }

            // If the guess was incorrect, add the letter to IncorrectGuesses
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

                // Prompt the user for a guess
                char guess = PromptGuess();

                // Process the guess
                if (CheckGuess(guess)) {
                    continue;
                } else {
                    GuessesRemaining--;
                }
            }

            // If they are out of guesses, tell them they lost
            if (GuessesRemaining == 0) {
                Console.WriteLine(DisplayMan());
                Console.WriteLine("Sorry, you're out of guesses. Better luck next time, n00b. \nThe correct answer was " + String.Join("", WordToGuess) + "\n");
                System.Threading.Thread.Sleep(500);
            }

            // If they have guessed all the letters correctly, tell them that they won
            if (!WordDisplay.Contains('*')) {
                Console.WriteLine("Congrats buddy, you won. The word was '" + ShowWord() + ".'\n");
                System.Threading.Thread.Sleep(500);
            }

            IncorrectGuesses.Clear();
        }

        static void Main(string[] args) {
            Hangman hangman = new Hangman("../../../HangManWords.txt");

            Console.WriteLine("Ready for a new game of Hangman? (y/n)");
            string answer = Console.ReadLine().ToLower();

            while (!(String.IsNullOrWhiteSpace(answer))) {
                hangman.Proceed(answer);

                hangman.ChooseWord();

                hangman.PlayGame();

                // After a game is completed, ask the user if they would like to play again
                Console.WriteLine("Ready for a new game of Hangman? (y/n)");
                answer = Console.ReadLine().ToLower();
            }
        }
    }
}
