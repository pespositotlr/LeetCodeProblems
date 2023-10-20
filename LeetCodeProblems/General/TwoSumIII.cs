using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class TwoSumIII
    {
        /// <summary>
        /// Sort the array, then use the TwoSumII two-pointer solution on everything to the right
        /// The time complexity of this is O(n^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);

            for(int i = 0; i < nums.Length; i++)
            {
                //Don't want to reuse the same first number to avoid duplicate result sets
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                //This part is basically the TwoSumII solution
                int l = i + 1;
                int r = nums.Length - 1;
                int threeSum;

                while (l < r)
                {
                    threeSum = nums[i] + nums[l] + nums[r];

                    if (threeSum > 0)
                        r--;
                    else if (threeSum < 0)
                        l++;
                    else
                    {
                        result.Add(new List<int> { nums[i], nums[l], nums[r] });
                        l++;

                        //Don't want to reuse the same second number to avoid duplicate sets
                        //We don't need to increment r because r is always the greater value which will result in > 0
                        while (nums[l] == nums[l-1] && l < r)
                            l++;
                    }
                }

            }

            return result;
        }
    }
}
