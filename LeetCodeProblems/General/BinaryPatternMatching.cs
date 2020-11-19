using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeProblems.General
{
    class BinaryPatternMatching
    {
        public static int binaryPatternMatching(string pattern, string s)
        {
            int patternLen = pattern.Length;

            if (!IsValidPattern(pattern))
                throw new InvalidOperationException("Only 0 and 1 allowed");
            else if (!IsValidInputString(s))
                throw new InvalidOperationException("Only lowercase letters allowed");

            string sBinary = ConvertToBinaryString(s);

            int result = 0;

            for (int i = 0; i <= sBinary.Length - patternLen; i++)
            {
                var sBinarySubstring = sBinary.Substring(i, patternLen);
                if (sBinarySubstring == pattern)
                    result++;
            }

            return result;
        }
        private static string ConvertToBinaryString(string s)
        {
            string vowels = "aeiouy";

            string sBinary = "";

            for (int i = 0; i < s.Length; i++)
            {
                sBinary += vowels.Contains(s[i]) ? '0' : '1';
            }

            return sBinary;
        }

        private static bool IsValidInputString(string s)
        {
            if (s == null || s == "") return false;

            Regex Validator = new Regex(@"^[a-z]+$");

            return Validator.IsMatch(s);
        }

        private static bool IsValidPattern(string pattern)
        {
            if (pattern == null || pattern == "") return false;

            Regex Validator = new Regex(@"^[0-1]+$");

            return Validator.IsMatch(pattern);
        }
    }

}
