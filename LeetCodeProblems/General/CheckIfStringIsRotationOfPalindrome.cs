using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeProblems.General
{
    //Given a string, check if it is a rotation of a palindrome. For example your function should return true for “aab” as it is a rotation of “aba”. 
    public class CheckIfStringIsRotationOfPalindrome
    {
        //Approach:

        //Generate all rotations of the string.
        //Check if any of the rotations is a palindrome.        
        //Return true if at least one palindrome is found, otherwise return false.
        //Function to check if a string is a palindrome
        static bool IsPalindrome(string str)
        {
            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        // Function to check if any rotation of the string is a palindrome
        static bool IsRotationOfPalindrome(string str)
        {
            int n = str.Length;
            string concatenated = str + str;  // Concatenate string to itself (Avoid having to manually rotate)

            // Try all possible rotations
            for (int i = 0; i < n; i++)
            {
                string rotated = concatenated.Substring(i, n); //Check every possible rotation of length n
                if (IsPalindrome(rotated))
                    return true;
            }

            return false;
        }

        static void CheckIfStringIsRotationOfPalindrome_Main()
        {
            string str = "aab";
            Console.WriteLine($"Is '{str}' a rotation of a palindrome? " + IsRotationOfPalindrome(str));
            //Explanation:
            //Rotations: "aab", "aba", "baa"
            //"aba" is a palindrome.

            str = "abc";
            Console.WriteLine($"Is '{str}' a rotation of a palindrome? " + IsRotationOfPalindrome(str));

            str = "aaa";
            Console.WriteLine($"Is '{str}' a rotation of a palindrome? " + IsRotationOfPalindrome(str));


        }

        //Explanation:

        //Checking for a palindrome:
        //    Use a two-pointer approach to check if a given string is a palindrome.

        //Generating rotations efficiently:
        //    Instead of manually rotating strings, concatenate str with itself (str + str).
        //    This way, every possible rotation of length n appears as a substring of this concatenated string.
        //    We extract n-length substrings from concatenated and check if any of them is a palindrome.

        //    Complexity Analysis:
        //Palindrome check: O(n)
        //Generating substrings: O(n²) (since we check n substrings)
        //Overall Complexity: O(n²)

        //Use Manacher’s Algorithm (O(n) approach for finding palindromes) if optimizing further.
        //You could add an edge case check for if all characters are the same
    }
}
