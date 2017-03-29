using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzApplication
{
    public class FizzBuzz
    {
        public int startNumber;
        public int endNumber;
        public static string three = "fizz";
        public static string five = "buzz";

        // no-arg constructor
        public FizzBuzz()
        {
            this.startNumber = 0;
            this.endNumber = 0;
        }

        // constructor with start and end arguments
        public FizzBuzz(int startNumber, int endNumber)
        {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }

        // Sets the start and end numbers
        public void SetRange(int startNumber, int endNumber)
        {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
        }

        public bool sayTrue()
        {
            return true;
        }

        public bool sayFalse()
        {
            return false;
        }


        static void Main(string[] args)
        {



        }
    }
}
