using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeProblems.General
{
    public class IsValidPalindrom
    {

        public static bool GetIsValidPalindome1(string s)
        {
            string newString = String.Empty;
            foreach (char c in s.ToLower())
            {
                if (char.IsLetterOrDigit(c))
                    newString += c;
            }

            return newString == new string(newString.Reverse().ToArray());

        }
        public static bool GetIsValidPalindome2(string s)
        {
            string newString = String.Empty;
            int l = 0; 
            int r = s.Length - 1;

            while (l < r)
            {
                //Skip non-letters and non-digits
                while (l < r && !char.IsLetterOrDigit(s[l]))
                    l++;

                while (r > l && !char.IsLetterOrDigit(s[r]))
                    r--;

                if (s[l] != s[r])
                    return false;

                l++;
                r--;
            }

            return true;

        }

        public static bool GetIsValidPalindrome3(string s)
        {
            var charArray = s.ToCharArray();
            var txtEntitites = charArray.GroupBy(c => c)
                            .OrderByDescending(g => g.Count())
                            .Where(e => Char.IsLetter(e.Key))
                            .Select(t => t.Key).ToList();

            foreach(var t in txtEntitites)
            {
                Console.WriteLine(t);
            }

            return true;

        }

        public static bool IsPalindrome4(string s)
        {
            var reversed = new string(Enumerable.Range(1, s.Length)
                                                .Select(i => s[s.Length - i])
                                                .ToArray());

            return String.Compare(s, reversed, true) == 0;
        }

        public static bool IsPalindrome5(string s)
        {
            var textA = s.ToCharArray();
            var textB = textA.Reverse();

            return textA.SequenceEqual(textB);
        }


        bool IsPalindrome6(string input)
        {
            return Enumerable.Range(0, input.Length / 2)
                            .Select(i => input[i] == input[input.Length - i - 1])
                            .All(b => b);
        }

        private static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(strToCheck);
        }

        private static bool IsAsciiAlphaNumeric(string str)
        {
            //48-> 57 are numerics
            //65-> 90 are capital letters
            //97-> 122 are lower case letters

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 48) // Numeric are 48 -> 57
                {
                    return false;
                }

                if (str[i] > 57 && str[i] < 65) // Capitals are 65 -> 90
                {
                    return false;
                }

                if (str[i] > 90 && str[i] < 97) // Lowers are 97 -> 122
                {
                    return false;
                }

                if (str[i] > 122)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
