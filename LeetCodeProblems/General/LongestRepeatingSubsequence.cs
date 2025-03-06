using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static LeetCodeProblems.LinkedList;

namespace LeetCodeProblems.General
{
    //Input: s= “abc”
    //Output: 0
    //Explanation: There is no repeating subsequence

    //Input: s= “aab”
    //Output: 1
    //Explanation: The two subsequence are ‘a'(0th index) and ‘a'(1th index). Note that ‘b’ cannot be considered as part of subsequence as it would be at same index in both.
    public class LongestRepeatingSubsequence
    {

        //Approach: Dynamic Programming(DP)

        //We use Dynamic Programming(DP) to solve this problem efficiently.
        //Construct a DP table dp[i][j], where:
        //dp[i][j] stores the length of the longest repeating subsequence considering substrings s[0...i-1] and s[0...j-1].
        //If characters match at different indices (i != j), we increase the count.
        //Otherwise, we take the maximum from the previous computations.
        static int GetLongestRepeatingSubsequence(string str)
        {
            int n = str.Length;
            int[,] dp = new int[n + 1, n + 1]; //Goes to length + 1
            //i is x-axis (left/right) and j is y-axis (top/bottom)

            // Build the DP table
            for (int i = 1; i <= n; i++) //Loop through whole string twice n^2 (Start at 1 to avoid an out of index issue)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (str[i - 1] == str[j - 1] && i != j) //Don't store values if indexes are the same
                    {
                        //A repeating subsequence is forming
                        dp[i, j] = 1 + dp[i - 1, j - 1];  // Take previous diagonal value and add 1
                    }
                    else
                    {
                        //Not in a repeating subsequence here
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);  // Take max of left or top
                    }
                }
            }

            return dp[n, n];  // The bottom-right cell has the answer
        }

        static void LongestRepeatingSubsequence_Main()
        {
            string str = "aabebcdd";
            Console.WriteLine("Length of Longest Repeating Subsequence: " + GetLongestRepeatingSubsequence(str));
        }

        //        Explanation

        //    Define a 2D DP table:
        //        dp[i][j] represents the length of the longest repeating subsequence considering up to i and j characters of the string.

        //    Filling the DP table:
        //        If s[i - 1] == s[j - 1] and i != j, it means a repeating subsequence is forming, so:
        //        dp[i][j]=1+dp[i−1][j−1]
        //        dp[i][j]=1+dp[i−1][j−1]
        //        Otherwise, take the maximum of either:
        //        dp[i−1][j] (excluding current i)ordp[i][j−1] (excluding current j)
        //        dp[i−1][j] (excluding current i)ordp[i][j−1] (excluding current j)

        //    Return dp[n][n] as the result(bottom-right corner of the DP table).

        //Complexity Analysis

        //    Time Complexity: O(n²) (Filling the DP table)
        //    Space Complexity: O(n²) (2D DP array)
    }
}
