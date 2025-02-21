using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    public class FindMaximumSubarray
    {
        //Find the contiguous subarray (with at least one number) which has the largest sum.
        static int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0], currentSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        static void FindMaximumSubarrayMain()
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine(MaxSubArray(nums)); // Output: 6 (Subarray: [4, -1, 2, 1])

        }

        // Time Complexity: O(n)
        // Space Complexity: O(1)
    }
}
