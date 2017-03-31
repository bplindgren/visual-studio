using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzApplication
{
    public class FizzBuzz {
        public int startNumber;
        public int endNumber;
        public string result;

        // No-arg constructor
        public FizzBuzz() {
            this.startNumber = 0;
            this.endNumber = 0;
            this.result = "";
        }

        // Constructor with start and end arguments
        public FizzBuzz(int startNumber, int endNumber) {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
            this.result = "";
        }

        // Sets the start and end numbers
        public void SetRange(int startNumber, int endNumber) {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }

        // Generate the output string
        public string getOutput() {
            // Loop over the range
            for (int i = this.startNumber; i <= this.endNumber; i++) {
                // Start with an empty output string
                string s = "";

                // Build the output string accordingly
                if ((i % 3) == 0) {
                    s += "fizz";
                }
                if ((i % 5) == 0) {
                    s += "buzz";
                }

                // If neither 'fizz' or 'buzz' is added, add i
                if (String.IsNullOrWhiteSpace(s)) {
                    s += (i.ToString() + " ");
                } else {
                    s += " ";
                }

                // Add the output string to the FizzBuzz object result property
                this.result += s;
            }

            // After looping over entire range, return the result
            return this.result.Substring(0, (this.result.Length - 1));
        }

        static void Main(string[] args) {
            FizzBuzz fb = new FizzBuzz(1, 20);
            Console.Write(fb.getOutput());
        }
    }
}
