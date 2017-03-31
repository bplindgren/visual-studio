using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzApplication {
    public class FizzBuzz {
        public int startNumber;
        public int endNumber;
        public string result = "";

    // No-arg constructor
    public FizzBuzz() {
            this.startNumber = 0;
            this.endNumber = 0;
        }

        // Constructor with start and end arguments
        public FizzBuzz(int startNumber, int endNumber) {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }

        // Sets the start and end numbers
        public void SetRange(int startNumber, int endNumber) {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }

        // Generate the substring for and integer
        public string BuildSubString(int i) {
            string s = "";

            // Build the output string accordingly
            if ((i % 3) == 0) {
                s += "fizz";
            }
            if ((i % 5) == 0) {
                s += "buzz";
            }

            // If neither 'fizz' or 'buzz' is added, add i
            if (String.IsNullOrWhiteSpace(s))
                s = i.ToString();

            return s;
        }

        // Generate the output string
        public string GetOutput() {
            // Loop over the range
            for (int i = startNumber; i <= endNumber; i++) {
                // Add the output string to the FizzBuzz object result property
                result += (BuildSubString(i) + " ");
            }

            return result.Substring(0, (result.Length - 1));
        }

        static void Main(string[] args) {
            FizzBuzz fb = new FizzBuzz(1, 20);
            Console.Write(fb.GetOutput());
        }
    }

    public class FizzBuzzTwo : FizzBuzz {

        private Dictionary<string, int> report = new Dictionary<string, int>() {
                { "fizz", 0 },
                { "buzz", 0 },
                { "fizzbuzz", 0 },
                { "lucky", 0 },
                { "integer", 0 }
            };

        public FizzBuzzTwo() : base() {
        }

        public FizzBuzzTwo(int startNumber, int endNumber) : base(startNumber, endNumber) {
        }

        // Generate the output string
        public new string GetOutput() {
            // Loop over the range
            for (int i = startNumber; i <= endNumber; i++) {

                string outputString = "";

                // If i contains a '3', output 'lucky'
                if (i.ToString().Contains('3')) {
                    outputString = "lucky";
                } else {
                    outputString = BuildSubString(i);
                }

                // Add the output string to the FizzBuzzTwo object 'result' property
                result += (outputString + " ");

                // Update the report
                if (report.ContainsKey(outputString)) {
                    report[outputString] += 1;
                } else {
                    report["integer"] += 1;
                }

            }

            // After looping over entire range, return the result
            return result.Substring(0, (result.Length - 1));
        }

        public string GetReport() {
            string reportString = String.Format("fizz: {0} \n" + "buzz: {1} \n" + "fizzbuzz: {2} \n" + "lucky: {3} \n" + "integer: {4}" , report["fizz"], report["buzz"], report["fizzbuzz"], report["lucky"], report["integer"]);
            return reportString;
        }

        static void Main(string[] args) {
            FizzBuzzTwo fb2 = new FizzBuzzTwo(1, 100);
            Console.WriteLine(fb2.GetOutput());
            Console.WriteLine(fb2.GetReport());
        }
    }
}
