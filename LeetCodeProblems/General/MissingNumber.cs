using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LeetCodeProblems.General
{
    internal class MissingNumber
    {
        //Simpler approach using a hash (This uses an array, could also use a hashset)
        static int FindMissingNumber_Hash(int[] arr)
        {
            int n = arr.Length + 1;

            // Create hash array of size n+1
            int[] hash = new int[n + 1];

            // Store frequencies of elements
            foreach (int num in arr) { hash[num]++; }

            // Find the missing number
            for (int i = 1; i <= n; i++)
            {
                if (hash[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        //To find the missing element in an array that contains a permutation of numbers from 1 to n with one missing, we can use Mathematical Summation or Bitwise XOR for an efficient solution.
        //1. Mathematical Summation Approach(O(n) Time, O(1) Space)

        //Since the numbers are from 1 to n, the sum of the first n natural numbers is:
        //Sum=n(n+1)2
        //Sum=2n(n+1)​

        //The missing number is simply:
        //Missing Number = Sum−∑(array elements)
        //Missing Number=Sum−∑(array elements)
        static int FindMissingNumber(int[] arr, int n)
        {
            int totalSum = (n * (n + 1)) / 2;
            int arraySum = 0;

            foreach (int num in arr)
                arraySum += num;

            return totalSum - arraySum;
        }

        static void MissingNumber_Main()
        {
            int[] arr = { 1, 2, 4, 5, 6 }; // n = 6, missing = 3
            int n = 6;
            Console.WriteLine("Missing Number: " + FindMissingNumber(arr, n));
        }

        //2. Bitwise XOR Approach (O(n) Time, O(1) Space)

        //Using XOR properties:

        //x ^ x = 0
        //x ^ 0 = x

        //If we XOR all numbers from 1 to n and all elements of the array, the missing number remains.
        static int FindMissingNumberXOR(int[] arr, int n)
        {
            int xorAll = 0, xorArray = 0;

            for (int i = 1; i <= n; i++)
                xorAll ^= i;

            foreach (int num in arr)
                xorArray ^= num;

            return xorAll ^ xorArray;
        }

        static void FindMissingNumberXOR_Main()
        {
            int[] arr = { 1, 2, 4, 5, 6 }; // n = 6, missing = 3
            int n = 6;
            Console.WriteLine("Missing Number: " + FindMissingNumberXOR(arr, n));
        }
    }
}
