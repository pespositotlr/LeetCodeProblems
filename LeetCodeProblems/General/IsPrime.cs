using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class IsPrime
    {
        // The following method checks if a number is prime by checking for divisibility on numbers less than it.It only
        // needs to go up to the square root of n because if n is divisible by a number greater than its square root then
        // it's divisible by something smaller than it.
        public bool isPrime(int n)
        {
            for (int x = 2; x * x <= n; x++)
            {
                if (n % x == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
