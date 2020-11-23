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

        // https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes 
        // http://csharphelper.com/blog/2014/08/use-the-sieve-of-eratosthenes-to-find-prime-numbers-in-c/
        private bool isPrimeWithSieveOfEratosthenes(int max)
        {
            bool[] is_prime = MakeSieve(max);

            return is_prime[max];
        }

        // Build a Sieve of Eratosthenes.
        private bool[] MakeSieve(int max)
        {
            // Make an array indicating whether numbers are prime.
            bool[] is_prime = new bool[max + 1];
            for (int i = 2; i <= max; i++) is_prime[i] = true;

            // Cross out multiples.
            for (int i = 2; i <= max; i++)
            {
                // See if i is prime.
                if (is_prime[i])
                {
                    // Knock out multiples of i.
                    for (int j = i * 2; j <= max; j += i)
                        is_prime[j] = false;
                }
            }
            return is_prime;
        }
    }
}
