using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    public class SculptureCapProblem
    {
        //This is for the pre-screen for Sculpture Capital Markets
        //Write a program to check whether the entered number is not divisible by 3 and 7?
        public bool CheckDivisible(int input)
        {
            if (input % 3 == 0 || input % 7 == 0) {
                return false;
            }

            return true;
        }

        //Check if a given string is a palindrome
        //Alternative is to use String.Reverse()
        //This is the two-pointer solution
        public bool CheckPalindrome(string input)
        {
            int l = 0;
            int r = input.Length - 1;

            while (l < r)
            {
                if (input[l] != input[r]) 
                    return false;

                l++;
                r--;
            }

            return true;
        }


    }
}
