using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class LongestSubstringWithoutRepeatingCharacters
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// The brute force method of checking all possible substrings 
        /// We don't need to check all of them with Sliding Window technique
        /// You hold a local "maximum" and then shift your "left pointer" if you get a double.
        /// You can check if you have a duplicate with a HashSet
        /// Time complexity is O(n), space is O(n) because of our set.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int l = 0;
            int r = 0;
            var charSet = new HashSet<char>();
            int maxLength = 0;

            while(r < s.Length)
            {

                while (charSet.Contains(s[r]))
                {
                    //Found a duplicate, so we need to "shrink" our sliding window until we no longer have duplicates
                    //You remove more than just that one letter because everything from the left up until (and including) the duplicate must be removed so there are no duplicates.
                    charSet.Remove(s[l]);
                    l++;
                }

                //Set doesn't contain this character so add it to the set
                charSet.Add(s[r]);
                //The length of the input string we have that doesn't contain duplicates is the the distance from l to r (Add 1 due to index 0)
                maxLength = Math.Max(maxLength, r - l + 1);
                r++;
            }

            return maxLength;

        }
    }
}
