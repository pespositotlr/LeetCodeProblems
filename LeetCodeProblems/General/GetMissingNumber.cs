using System;
using System.Collections.Generic;
using System.Text;

//https://www.geeksforgeeks.org/find-the-missing-number/
namespace LeetCodeProblems
{
    class GetMissingNumber
    {

        //Complexity Analysis: 
        
        //Time Complexity: O(n). 
        //Only one traversal of the array is needed.
        //Space Complexity: O(1). 
        //No extra space is needed

        // Function to find missing number
        public static int GetMissingNumber1(int[] a, int n)
        {
            int total = (n + 1) * (n + 2) / 2;

            for (int i = 0; i < n; i++)
                total -= a[i];

            return total;
        }


        //Complexity Analysis: 
        //Time Complexity: O(n). 
        //Only one traversal of the array is needed.
        //Space Complexity:O(1). 
        //No extra space is needed

        // a represents the array
        // n : Number of elements in array a
        public static int GetMissingNumber2(int[] a, int n)
        {
            int i, total = 1;

            for (i = 2; i <= (n + 1); i++)
            {
                total += i;
                total -= a[i - 2];
            }
            return total;
        }


        //    Method 2: This method uses the technique of XOR to solve the problem.
        //Approach: 
        //XOR has certain properties
        //    Assume a1 ^ a2 ^ a3 ^ …^ an = a and a1 ^ a2 ^ a3 ^ …^ an-1 = b
        //    Then a ^ b = an
        //Algorithm: 
        //    Create two variables a = 0 and b = 0
        //    Run a loop from 1 to n with i as counter.
        //    For every index update a as a = a ^ i
        //    Now traverse the array from start to end.
        //    For every index update b as b = b ^ array[i]
        //    Print the missing number as a ^ b.
        public static int GetMissingNumber3(int[] a, int n)
        {
            int x1 = a[0];
            int x2 = 1;

            /* For xor of all the elements 
            in array */
            for (int i = 1; i < n; i++)
                x1 = x1 ^ a[i];

            /* For xor of all the elements 
            from 1 to n+1 */
            for (int i = 2; i <= n + 1; i++)
                x2 = x2 ^ i;

            return (x1 ^ x2);
        }

    }

    // This code is contributed by Sam007_
}
