using System;
using System.Collections.Generic;

namespace LeetCodeProblems.ConceptualExamples
{
    internal class HigherOrderFunctionForMemoization
    {
    }
    //How it works:

    //Memoizer.Memoize<TArg, TResult> is a higher-order function that takes a function func as an argument and returns a new function that caches the results.
    //The returned function checks whether the result for the given argument is already in the cache(cache.ContainsKey(arg)). If it is, it returns the cached result;
    //if not, it calls the original function, stores the result in the cache, and then returns it.

    //Example usage:
    //The Fibonacci function is a recursive, computationally expensive function that will benefit from memoization.
    //The memoizedFibonacci function is the memoized version of Fibonacci and can be used like the original function, but with much faster repeated calls.
    //When you run this code, the first call to memoizedFibonacci(40) will compute the result, while subsequent calls with the same argument will return the cached result,
    //greatly improving performance.
    public class Memoizer
    {
        // Memoization function that takes a function as a parameter and returns a memoized version of it
        public static Func<TArg, TResult> Memoize<TArg, TResult>(Func<TArg, TResult> func)
        {
            // Dictionary to store the results of function calls
            var cache = new Dictionary<TArg, TResult>();

            // Return the memoized version of the function
            return arg =>
            {
                if (cache.ContainsKey(arg))
                {
                    return cache[arg];  // Return cached result
                }

                var result = func(arg);  // Call the original function
                cache[arg] = result;  // Cache the result
                return result;
            };
        }
    }

    class MemoizerProgram
    {
        // Example function to demonstrate memoization (expensive computation)
        static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void MemoizerProgramMain()
        {
            // Create the memoized version of the Fibonacci function
            var memoizedFibonacci = Memoizer.Memoize<int, int>(Fibonacci);

            // Call the memoized function
            Console.WriteLine(memoizedFibonacci(40));  // First call, computes the result
            Console.WriteLine(memoizedFibonacci(40));  // Second call, returns cached result
        }
    }
}


