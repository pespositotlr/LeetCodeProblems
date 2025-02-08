using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    //https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    /* Neetcode: https://www.youtube.com/watch?v=cQ1Oz4ckceM
     * The array is already in ascending order.
     * Input numbers = [2, 7, 11, 1], target = 9
     * Output: [1,2]
     * Explanation: The sum of 2 is 7 and 9. Therefore index1 = 1, index2 = 2.
     * Indexes are one-based for some reason so you need to +1 at the end.
     * Start by counting with moving l to the right ->, checking for the target.
     * Since it's already sorted, if the two numbers added together are > the target as we move left, we know we don't need to look further left.
     * At that point, move r to the left <-.
     * This two-pointer solution is O(n) since it only checks everything once.
     */
    internal class TwoSumII
    {
        public int[] GetTwoSumII(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;

            while (l < r) { //We're guaranteed a solution so what the "while" statement is doesn't really matter.

                if (numbers[l] + numbers[r] > target) //Current sum is too big, so move r (the bigger number) left (to a smaller number)
                {
                    r--;
                } else if (numbers[l] + numbers[r] < target) //Current sum is too small, so move l (the smaller number) right (to a bigger number)
                {
                    l++;
                } else { //Else we found the target. Add 1 to the indexes because the result they want is index + 1
                    return new int[2] { l + 1, r + 1 }; 
                }
            }

            return null;

        }
    }
}
