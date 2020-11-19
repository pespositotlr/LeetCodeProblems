using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
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

    }
}
