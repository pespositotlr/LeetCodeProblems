using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeProblems.ConceptualExamples
{
    /// <summary>
    /// https://www.geeksforgeeks.org/tabulation-vs-memoization/
    /// Tabulation:
    //Bottom-up approach
    //Stores the results of subproblems in a table
    //Iterative implementation

    //Well-suited for problems with a large set of inputs
    //Used when the subproblems do not overlap
    //Here’s an example of using memoization and tabulation to solve the same problem – calculating the nth number in the Fibonacci sequence:

    ///In the memoization implementation, we use a dictionary object called cache to store the results of function calls, and we use recursion to compute the results.
    ///In the tabulation implementation, we use an array called table to store the results of subproblems, and we use iteration to compute the results.
    ///Both implementations achieve the same result, but the approach used is different.
    ///Memoization is a top-down approach that uses recursion, while tabulation is a bottom-up approach that uses iteration.
    /// </summary>
    public class TabulationFibonacci
    {
        public static int CalculateFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                //Unlike a cache that only stores solved subproblems, this solves every problem
                //This is faster (than memoization) if every subproblem must be solved at least once
                //Good for when subproblems don't overlap
                //Bottom-Up approach
                int[] table = new int[n + 1];
                table[0] = 0;
                table[1] = 1;

                for (int i = 2; i <= n; i++)
                {
                    table[i] = table[i - 1] + table[i - 2];
                }

                return table[n];
            }
        }

        public static void TabulationFibonacciMain()
        {
            int n = 6;  // Find the 6th Fibonacci number
            int result = CalculateFibonacci(n);
            Console.WriteLine($"The {n}th Fibonacci number is: {result}");
        }
    }
}
