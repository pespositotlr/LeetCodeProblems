using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    //https://leetcode.com/problems/two-sum/
    // Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    // You may assume that each input would have exactly one solution, and you may not use the same element twice.
    // Example:
    // Given nums = [2, 7, 11, 15], target = 9,
    // Because nums[0] + nums[1] = 2 + 7 = 9,
    // return [0, 1].
    // The trick is the dictionary keys are the input array values and the dictionary values are the indices
    class TwoSum
    {
        public static int[] GetTwoSum(int[] nums, int target)
        {
            var numsDictionary = new Dictionary<int, int>();
            var difference = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                // Looking for the "other index" 
                difference = target - nums[i];
                var index = 0;

                // Check if it exists based on what you've stored in the dictionary so far
                // Checking difference > 0 removes unnecessary checks to the dictionary
                if (difference > 0 && numsDictionary.TryGetValue(difference, out index))
                {
                    return new int[] { index, i };
                }

                // Memoize previous values
                if (!numsDictionary.ContainsKey(nums[i]))
                {
                    numsDictionary.Add(nums[i], i);
                }
            }

            return null;
        }
    }
}
