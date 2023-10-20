using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    //https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    internal class TwoSumII
    {
        public int[] GetTwoSumII(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length;

            while (l < r) {

                if (numbers[l] + numbers[r] > target)
                {
                    r--;
                } else if (numbers[l] + numbers[r] < target)
                {
                    l--;
                } else { 
                    return new int[2] { l + 1, r + 1 }; 
                }
            }

            return null;

        }
    }
}
