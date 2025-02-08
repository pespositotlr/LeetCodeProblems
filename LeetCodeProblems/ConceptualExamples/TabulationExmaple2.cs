using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Policy;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;

namespace LeetCodeProblems.ConceptualExamples
{
    /// <summary>
    /// Tabularization refers to solving problems (like dynamic programming problems) using a table (usually an array or matrix) to store intermediate results. 
    /// The idea is to fill up the table in a systematic way, using previously computed results to build up the final solution.
    /// A common example is solving the Fibonacci sequence using tabularization (bottom-up dynamic programming).
    /// 
    /// Explanation:
    //Table Creation: An array table is created to store the Fibonacci numbers. The size of the array is n+1 because we want to store results for F(0) through F(n).
    //Base Cases: The first two Fibonacci numbers are directly initialized:
    //    table[0] = 0 (F(0) = 0)
    //    table[1] = 1 (F(1) = 1)
    //Iterative Calculation: We use a loop to fill in the table for values from 2 to n using the recurrence relation:
    //    F(n) = F(n-1) + F(n-2)
    //Final Result: The function returns table[n], which holds the Fibonacci number for n.
    /// </summary>
    class TabulationExmaple2
    {
        // Function to compute Fibonacci using tabularization (bottom-up DP)
        static int FibonacciTabular(int n)
        {
            // If n is 0 or 1, return n directly
            if (n <= 1)
                return n;

            // Create a table (array) to store results of subproblems
            int[] table = new int[n + 1];

            // Base cases
            table[0] = 0;
            table[1] = 1;

            // Fill the table iteratively
            for (int i = 2; i <= n; i++)
            {
                table[i] = table[i - 1] + table[i - 2];  // F(n) = F(n-1) + F(n-2)
            }

            // Return the final result
            return table[n];
        }

        static void TabulationExmaple2Main()
        {
            int n = 10;

            // Compute Fibonacci using tabularization (bottom-up approach)
            int result = FibonacciTabular(n);
            Console.WriteLine($"Fibonacci of {n} is: {result}");
        }

        //Why Tabularization (Bottom-Up)?
        //Efficiency: Unlike recursion, this avoids redundant calculations, which would otherwise be done many times in the recursive approach.
        //The time complexity of this approach is O(n) instead of O(2n) in the naive recursive approach.
        //Space Complexity: The space complexity is O(n) due to the table used to store intermediate results.

        //Space Optimization:
        //If you want to reduce the space complexity to O(1)O(1), you can optimize the table to only store the last two Fibonacci numbers at any point:
        //Optimized Fibonacci using only two variables (space complexity O(1))

        //In this optimized version, we only store the last two Fibonacci numbers (a and b),
        //which reduces the space complexity to O(1)O(1) while maintaining the time complexity of O(n).
        static int FibonacciOptimized(int n)
        {
            if (n <= 1)
                return n;

            int a = 0;  // F(0)
            int b = 1;  // F(1)
            int result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = a + b;  // F(n) = F(n-1) + F(n-2)
                a = b;  // Update a to F(n-1)
                b = result;  // Update b to F(n)
            }

            return result;
        }

        static void TabulationExmaple2FibonacciOptimizedMain()
        {
            int n = 10;

            // Compute Fibonacci using optimized space
            int result = FibonacciOptimized(n);

            Console.WriteLine($"Fibonacci of {n} is: {result}");
        }
    }
}