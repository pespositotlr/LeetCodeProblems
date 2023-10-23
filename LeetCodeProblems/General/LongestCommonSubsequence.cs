using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    //https://leetcode.com/problems/longest-common-subsequence/

    // Given two strings text1 and text2, return the length of their longest common subsequence.
    // A subsequence of a string is a new string generated from the original string with some characters (can be none) 
    // deleted without changing the relative order of the remaining characters. (eg, "ace" is a subsequence of "abcde" while "aec" is not). 
    // A common subsequence of two strings is a subsequence that is common to both strings.
    // If there is no common subsequence, return 0.
    class LongestCommonSubsequence
    {

        //Dynamic Programming version
        /* Returns length of LCS for X[0..m-1], Y[0..n-1] */
        static int lcs(char[] firstArray, char[] secondArray)
        {
            int[,] memo = new int[firstArray.Length + 1, secondArray.Length + 1];

            /* Following steps build L[m+1][n+1] in bottom up fashion. 
             * Note that L[i][j] contains length of LCS of firstArray[0..i-1] and secondArray[0..j-1] */
            // You're going through every item in the second array for every item in the first array.
            // As you move towards the "bottom right of the chart" iterating through both arrays" you store the largest value you found "so far".
            // You basically check if you have a "match" with anything in the second array to the first letter of the first array, 
            // and you keep track of it through all the other letters of the second array.
            // This is O(mn) time, as in length of firstArray * length of secondArray
            for (int i = 0; i <= firstArray.Length; i++)
            {
                for (int j = 0; j <= secondArray.Length; j++)
                {
                    if (i == 0 || j == 0) //To avoid issues with -1 index
                        memo[i, j] = 0;
                    else if (firstArray[i - 1] == secondArray[j - 1]) //If values are equal
                        memo[i, j] = memo[i - 1, j - 1] + 1; //Increment 1 from the "diagonal up/left" value (if you were looking at this on a chart) 
                                                             //(You don't increment for the same letter in one array hitting two of the same letter in a second array. So GX and AGG, the LCS is still 1.)
                    else //Values are not equal
                        memo[i, j] = max(memo[i - 1, j], memo[i, j - 1]); //Take maximum of "left" and "above" cell (if looking at this on a chart)
                }
            }
            return memo[firstArray.Length, secondArray.Length];
        }
        //To get the actuall letters in that longest common subsequence, you take the Memo you made
        //Start at bottom right. If "top" cell and left cell are equal, then you got your higher number from the diagonal, so that value is in the LCS.

        int slowerRecursiveLCS(char[] firstArray, char[] secondArray)
        {
            if (firstArray.Length == 0 || secondArray.Length == 0)
                return 0;
            if (firstArray[firstArray.Length - 1] == secondArray[secondArray.Length - 1])
                return 1 + slowerRecursiveLCS(firstArray, secondArray);
            else
                return max(slowerRecursiveLCS(firstArray, secondArray), slowerRecursiveLCS(firstArray, secondArray));
        }


        /* Utility function to get max of 2 integers */
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Driver code 
        public static void LongestCommonSubsequenceMain()
        {

            String s1 = "AGGTAB";
            String s2 = "GXTXAYB";

            char[] X = s1.ToCharArray();
            char[] Y = s2.ToCharArray();

            Console.Write("Length of LCS is" + " " + lcs(X, Y));
        }

        ///<summary>
        /// https://leetcode.com/problems/longest-common-subsequence/
        /// https://www.youtube.com/watch?v=Ua0GhsJSlWM
        /// Ex. ace, abcde
        ///        j
        ///      a c e -
        ///   a +1
        ///   b   +0+0
        /// i c   +1
        ///   d     +0 +0
        ///   e     +1
        ///   -        +0
        /// You want to get the top-left value at a,a
        /// If you match, you go diagonally down right
        /// Otherwise you go right or down (You're removing b)
        /// You're essentially eliminating the top left and comparing the bottom right as "subproblems"
        /// The c's match so go diagonally down-right (You're eliminating the top c and left c)
        /// When you don't have a match you go right or down. And you take whatever is the max of either one.
        /// If you get a match, +1. If you don't get a match, +0 (including out of bounds).
        /// You can think of going down or right to going to later recurrsions
        /// Once you go back up your path you get three +1's so your result is 3.
        /// So this is a bottom-up Dynamic Programming solution. You first get the bottom value and work your way up to the rersult.
        /// Time complexity is O(n*m) the lenfth of the two strings
        /// Essentially you're finding the LCS of the ENDS of the two strings and whenever you get a match you move towards the begining
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public static int GetLongestCommonSubsequence(string text1, string text2)
        {
            //values are 0 by default
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];

            //Create the dp graph shown above. Bottom-up approach where values are added and we work our way up to 0,0 which has the answer
            for(int i = text1.Length - 1; i > -1; i--)
            {
                for (int j = text2.Length - 1; j > -1; j--)
                {
                    if (text1[i] == text2[j])
                        dp[i,j] = 1 + dp[i + 1,j + 1]; //If items match, assign the value found down and to the right + 1
                    else
                        dp[i, j] = Math.Max(dp[i, j + 1], dp[i+1,j]); //If items down't match assign the max of below and right
                }
            }

            return dp[0, 0];
        }
    }
}
