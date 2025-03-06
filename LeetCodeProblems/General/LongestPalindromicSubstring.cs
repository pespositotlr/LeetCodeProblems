using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    public class LongestPalindromicSubstring
    {
        //To find the longest palindromic substring in a given string, we can use two efficient approaches:
        //Expand Around Center(O(n²) Time, O(1) Space)
        //Dynamic Programming(O(n²) Time, O(n²) Space)
        //There's a third brute-force version which is "check all possible substrings" which is n^3

        //1. Expand Around Center Approach (Recommended)
        //Each character(or pair of characters) is considered as a possible center of a palindrome.
        //Expand outward while the substring remains a palindrome.
        //Keep track of the longest palindrome found.
        static string GetLongestPalindromicSubstring(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            int start = 0, maxLength = 1;

            for (int i = 0; i < str.Length; i++)
            {
                ExpandAroundCenter(str, i, i, ref start, ref maxLength);  // Odd length palindrome (Start at 0-0)
                ExpandAroundCenter(str, i, i + 1, ref start, ref maxLength);  // Even length palindrome (Start at 0-1)
            }

            return str.Substring(start, maxLength);
        }

        static void ExpandAroundCenter(string str, int left, int right, ref int start, ref int maxLength)
        {
            while (left >= 0 && right < str.Length && str[left] == str[right])
            {
                int currLength = right - left + 1;
                if (currLength > maxLength) //Found a new maxLength so savce your values to get final substring
                {
                    start = left;
                    maxLength = currLength;
                }
                left--; //Expand indexes outward
                right++;
            }
        }

        static void GetLongestPalindromicSubstring_Main()
        {
            string str = "babad";
            Console.WriteLine("Longest Palindromic Substring: " + GetLongestPalindromicSubstring(str));
        }

        //2. Dynamic Programming Approach(Alternative)
        //Use a DP table where dp[i][j] is true if str[i..j] is a palindrome.
        //Expand substrings and track the longest palindromic one.
        static string LongestPalindromicSubstringDP(string str)
        {
            int n = str.Length;
            if (n == 0) return "";

            bool[,] dp = new bool[n, n]; //2D array of length n
            int start = 0, maxLength = 1;

            for (int i = 0; i < n; i++) //Set all 0-0, 1-1 2-2 etc (one-letter long) values to to true
                dp[i, i] = true;

            for (int i = 0; i < n - 1; i++) //Set two-length values (0-1, 1-2) to true if they are equal
            {
                if (str[i] == str[i + 1])
                {
                    dp[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            //At this point we've found all of the 1 or 2 length palindromes
            //Check 3 or more
            for (int len = 3; len <= n; len++) //Check all lengths from 3 to whole array
            {
                for (int i = 0; i < n - len + 1; i++) //Check all substrings of this length to see if they're a palindrome
                {
                    int j = i + len - 1;
                    if (str[i] == str[j] && dp[i + 1, j - 1]) //Check if the new bounds are equal, if so you have a new palindrome
                    {
                        dp[i, j] = true;
                        start = i;
                        maxLength = len;
                    }
                }
            }

            return str.Substring(start, maxLength);
        }

        //There's another solution called Manacher's Algorithm
    }
}
