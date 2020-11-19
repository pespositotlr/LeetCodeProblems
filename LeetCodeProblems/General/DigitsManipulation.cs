using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    class DigitsManipulation
    {
        public static int digitsManipulations(int n)
        {
            int sum = 0;
            int product = 1;

            //Loop to add all digits of n to the digitsList
            while (n > 0)
            {
                var currentDigit = n % 10; //Gets value past the 10s digit
                sum += currentDigit;
                product *= currentDigit;
                n /= 10; //Shifts decimal place over
            }

            return product - sum;
        }

    }
}
