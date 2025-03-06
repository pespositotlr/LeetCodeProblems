using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://leetcode.com/problems/trapping-rain-water/description/
    /// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
    /// Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
    /// Output: 6    
    /// Explanation: The above elevation map(black section) is represented by array[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]. 
    /// In this case, 6 units of rain water (blue section) are being trapped.
    /// </summary>
    class TrappingRainWater    
    {
        /// <summary>
        /// Use stack to do it, scan the array, if we found that the current value is >= max in the stack, calculate how much water it is able to trap. otherwise, add to stack.
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int Trap(int[] heights)
        {
            var result = 0;
            var heightIndexStack = new Stack<int>();
            var maxHeight = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                while (heightIndexStack.Count > 0 && heights[i] >= maxHeight) //Went uphill
                {
                    var top = heightIndexStack.Pop();
                    result += maxHeight - heights[top];
                }

                heightIndexStack.Push(i);
                maxHeight = Math.Max(maxHeight, heights[i]);
            }

            var currentMax = heightIndexStack.Count > 0 ? heights[heightIndexStack.Peek()] : 0;
            while (heightIndexStack.Count > 0)
            {
                var top = heightIndexStack.Pop();
                if (currentMax <= heights[top])
                {
                    currentMax = heights[top];
                }
                else
                {
                    result += currentMax - heights[top];
                }
            }

            return result;
        }

        /// <summary>
        /// do not use stack. using two pointers to solve it. 
        /// find max value and its index, move left pointer from 0 to max index, right pointer from len – 1 to max index. 
        /// so every time, we know how much water it can trap.
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int Trap2(int[] heights)
        {
            var result = 0;
            var maxHeight = 0;
            var maxHeightIndex = -1;

            //Find overall max height and index
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] > maxHeight) //Assumes tha max height is the first "peak" of that height.
                {
                    maxHeight = heights[i];
                    maxHeightIndex = i;
                }
            }

            //Since water can't be "trapped" on the sides, you traverse to the peak from the left and the right with the max as a "pivot".
            var leftMaxHeight = 0;
            for (int i = 0; i < maxHeightIndex; i++)
            {
                leftMaxHeight = Math.Max(leftMaxHeight, heights[i]);
                result += leftMaxHeight - heights[i];
            }
            var rightMaxHeight = 0;
            for (int i = heights.Length - 1; i >= maxHeightIndex; i--)
            {
                rightMaxHeight = Math.Max(rightMaxHeight, heights[i]);
                result += rightMaxHeight - heights[i];
            }

            return result;
        }

        /// <summary>
        /// more concise solution for solution 2. we do not need to find the max value index.
        /// Max is just highest you've been to on either side.
        /// Instead of sliding the two sides equally, you're shifting based on which side's value is lower.
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int Trap3(int[] heights)
        {
            var res = 0;
            var max = 0;
            var left = 0;
            var right = heights.Length - 1;

            while (left <= right)
            {
                if (heights[left] < heights[right])
                {
                    max = Math.Max(max, heights[left]);
                    res += max - heights[left];
                    left++;
                }
                else
                {
                    max = Math.Max(max, heights[right]);
                    res += max - heights[right];
                    right--;
                }
            }

            return res;
        }

        /// <summary>
        /// Fourth method that's easier to read.
        /// Keep track of a leftmax and a rightmax.
        /// Formula for finding the current water amount is Min(leftmax, rightmax) - heights[currentIndex]
        /// You increment tha local max if you get to a new max moving from the left or the right.
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int Trap4(int[] heights)
        {
            var result = 0;
            var l = 0;
            var r = heights.Length - 1;
            var leftMax = 0;
            var rightMax = heights[r];

            while (l < r)
            {
                if (leftMax < rightMax)
                {
                    l++;
                    leftMax = Math.Max(leftMax, heights[l]);
                    result += leftMax - heights[l];
                }
                else
                {
                    r--;
                    rightMax = Math.Max(rightMax, heights[r]);

                    result += rightMax - heights[r];
                }
            }

            return result;
        }

        //This is an optimal approach with O(n) time complexity and O(1) space complexity.
        //Idea:
        //Use two pointers(left and right) to track the leftmost and rightmost bars.
        //Maintain two variables(leftMax and rightMax) to store the maximum height seen from the left and right.
        //Move the pointer with the smaller height inward, calculating the trapped water.
        static int TrapWater5(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            int left = 0, right = height.Length - 1; //Two-pointer start from each sideand move to center
            int leftMax = 0, rightMax = 0; //Start at height of 0
            int waterTrapped = 0;

            while (left < right)
            {
                if (height[left] < height[right]) //By drawing towards the center, you meet at the highest point
                {
                    if (height[left] >= leftMax)
                        leftMax = height[left];  // Update left max (No new water trapped)
                    else
                        waterTrapped += leftMax - height[left];  // Water trapped at this index

                    left++;  // Move left pointer
                }
                else
                {
                    if (height[right] >= rightMax)
                        rightMax = height[right];  // Update right max
                    else
                        waterTrapped += rightMax - height[right];  // Water trapped at this index

                    right--;  // Move right pointer
                }
            }

            return waterTrapped;
        }

        //Explanation of Algorithm:
        //Initialize two pointers: left = 0, right = n - 1.
        //Track leftMax and rightMax to store the highest bars on each side.
        //Move the pointer with the smaller height inward.
        //If height[left] < height[right]:
        //    If height[left] is greater than leftMax, update leftMax.
        //    Else, add leftMax - height[left] to the total trapped water.
        //    Move left pointer right.
        //Otherwise:
        //    If height[right] is greater than rightMax, update rightMax.
        //    Else, add rightMax - height[right] to the total trapped water.
        //    Move right pointer left.
        //Repeat until left meets right.

    }
}
