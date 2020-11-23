using System;
using System.Collections.Generic;
using System.Text;

// C# program to find palindromic
// substrings of a string
namespace LeetCodeProblems.General
{
    class PalindromeSubstrings
    {
        // Returns total number of
        // palindrome substring of
        // length greater then equal to 2
        public static int CountPS(char[] str, int n)
        {
            // create empty 2-D matrix that counts
            // all palindrome substring. dp[i][j]
            // stores counts of palindromic
            // substrings in st[i..j]
            int[][] rectangularIntArray = RectangularArrays.ReturnRectangularIntArray(n, n);

            // P[i][j] = true if substring str[i..j]
            // is palindrome, else false
            bool[][] rectangularBoolArray = RectangularArrays.ReturnRectangularBoolArray(n, n);

            // palindrome of single length
            for (int i = 0; i < n; i++)
            {
                rectangularBoolArray[i][i] = true;
            }

            // palindrome of length 2
            for (int i = 0; i < n - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    rectangularBoolArray[i][i + 1] = true;
                    rectangularIntArray[i][i + 1] = 1;
                }
            }

            // Palindromes of length more then 2.
            // This loop is similar to Matrix Chain Multiplication. 
            // We start with a gap of length 2 and fill DP table in a way that gap between starting and
            // ending indexes increases one by one by outer loop.
            for (int gap = 2; gap < n; gap++)
            {
                // Pick starting point for current gap
                for (int i = 0; i < n - gap; i++)
                {
                    // Set ending point
                    int j = gap + i;

                    // If current string is palindrome
                    if (str[i] == str[j] && rectangularBoolArray[i + 1][j - 1])
                    {
                        rectangularBoolArray[i][j] = true;
                    }

                    // Add current palindrome substring
                    // ( + 1) and rest palindrome substring
                    // (dp[i][j-1] + dp[i+1][j]) remove common
                    // palindrome substrings (- dp[i+1][j-1])
                    if (rectangularBoolArray[i][j] == true)
                    {
                        rectangularIntArray[i][j] = rectangularIntArray[i][j - 1] + rectangularIntArray[i + 1][j]
                                   + 1 - rectangularIntArray[i + 1][j - 1];
                    }
                    else
                    {
                        rectangularIntArray[i][j] = rectangularIntArray[i][j - 1] + rectangularIntArray[i + 1][j]
                                   - rectangularIntArray[i + 1][j - 1];
                    }
                }
            }

            // return total palindromic substrings
            return rectangularIntArray[0][n - 1];
        }

        public static class RectangularArrays
        {
            public static int[][] ReturnRectangularIntArray(
                int size1, int size2)
            {
                int[][] newArray = new int[size1][];
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new int[size2];
                }

                return newArray;
            }

            public static bool[][] ReturnRectangularBoolArray(
                int size1, int size2)
            {
                bool[][] newArray = new bool[size1][];
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new bool[size2];
                }

                return newArray;
            }
        }

        // Driver Code
        public static void PalindromeSubstringsMain()
        {
            string str = "abaab";
            Console.WriteLine(
                CountPS(str.ToCharArray(), str.Length));
        }
    }
}
