using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class BinarySearch
    {

        /// <summary>
        /// Search where you take the midpoint between the left index and right index 
        /// of a sorted array until you find the target
        /// O(log n) time search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(List<int> nums, int target)
        {
            int left = 0;
            int right = nums.Count - 1;
            int mid = 0;

            while (left <= right)
            {
                //Alternative: mid = left + ((right - left) / 2); 
                //Avoid adding left and right together to avoid overflow
                mid = (left + right) / 2; //Remember mid will always be an integer and within the bounds of the array
                if (nums[mid] > target) //If midpoint is larger than target, move right bound left
                    right = mid - 1;
                else if (nums[mid] < target) //If midpoint is smaller than target, move left bound right
                    left = mid + 1;
                else 
                    return mid; //nums[mid] is the target so return it
            }

            return -1; //Did not find a result
        }
    }
}
