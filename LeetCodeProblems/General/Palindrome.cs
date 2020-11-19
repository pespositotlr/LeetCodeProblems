using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class Palindrome
    {
        public static bool IsPalindrome(string inputstr)
        {
            string reversestr = string.Empty;
            if (inputstr != null)
            {
                for (int i = inputstr.Length - 1; i >= 0; i--)
                {
                    reversestr += inputstr[i].ToString();
                }
                if (reversestr == inputstr)
                {
                    Console.WriteLine("String is Palindrome Input = {0} and Output= {1}", inputstr, reversestr);
                }
                else
                {
                    Console.WriteLine("String is not Palindrome Input = {0} and Output= {1}", inputstr, reversestr);
                }
            } else
            {
                Console.WriteLine("Null input");
                return false;
            }

            return reversestr == inputstr;
        }
        public static bool IsPalindrome2(string inputstr)
        {
            for (int i = 0; i < inputstr.Length; i++)
            {
                if (inputstr[i] != inputstr[(inputstr.Length -1) - i])
                {
                    Console.WriteLine("String is not Palindrome");
                    return false;
                }

                if(i >= inputstr.Length - i)
                {
                    break;
                }
            }
            return true;
        }
    }
}
