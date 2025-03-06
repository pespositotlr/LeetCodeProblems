using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    //Methods for getting a specific digit from a number
    internal class GetSpecificDigit
    {

        //If you want the N-th digit from the left, converting to a string is the simplest approach:
        public void ConvertToString()
        {
            long number = 9876543210;
            int position = 3; // Get the 3rd digit from the left (0-based index)

            char digitChar = number.ToString()[position];
            int digit = digitChar - '0'; // Convert char to int

            Console.WriteLine(digit); // Output: 7
        }

        //Use Modulus and Division (Position-Based)
        public void UseModulusAndDivision()
        {
            long number = 9876543210;
            int position = 3; // Get the 3rd digit from the right (1-based)

            int digit = (int)(number / (long)Math.Pow(10, position - 1)) % 10;

            Console.WriteLine(digit); // Output: 2
        }

        //Extract Each Digit Using a Loop
        public void ExctractDigitUsingALoop()
        {
            long number = 9876543210;
            List<int> digits = new List<int>();

            while (number > 0)
            {
                digits.Add((int)(number % 10)); // Get last digit
                number /= 10; // Remove last digit
            }

            digits.Reverse(); // To maintain left-to-right order
            Console.WriteLine(string.Join(", ", digits)); // Output: 9, 8, 7, 6, 5, 4, 3, 2, 1, 0
        }

        //Summary
        //Method                Use Case                                Pros                                Cons
        //String Conversion     Get a specific digit by index           Simple, readable                    Not efficient for large numbers
        //Modulus & Division    Get a digit by position from the right  Fast, no conversions                Harder to read
        //Loop Method           Extract all digits                      Useful for processing all digits    Extra computation

        //Would you like an optimized solution for very large numbers or handling negative numbers? 🚀
    }
}
