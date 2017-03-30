using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome { 

    class Palindrome {

        public bool IsPalindrome(String word) {

            // Create a string of the argument 'word' in all lowercase
            string wordLower = word.ToLower();

            // Create a reversed string of the argument 'word' in all lowercase
            char[] charArray = wordLower.ToArray();
            Array.Reverse(charArray);
            string reversedString = string.Join("", charArray);

            // Determine if the two strings are equal
            return (wordLower.Equals(reversedString));

        }

        static void Main(string[] args) {

            Palindrome p = new Palindrome();
            
            Console.WriteLine(p.IsPalindrome("ABCdef"));
            Console.WriteLine(p.IsPalindrome("Noon"));
            Console.WriteLine(p.IsPalindrome("racecar"));
            Console.WriteLine(p.IsPalindrome("hello"));
            Console.WriteLine(p.IsPalindrome("pneumonoultramicroscopicsilicovolcanoconiosi"));
            Console.WriteLine(p.IsPalindrome("tatTARrattat"));

        }
    }
}
