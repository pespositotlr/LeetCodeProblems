using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCodeProblems.General
{

    //Given two integer arrays nums1 and nums2, where nums1 is a subset of nums2, find the next greater element for each element in nums1 within nums2.

    //    The next greater element of an element x in nums2 is the first greater element to the right of x in nums2.
    //    If no greater element exists, return -1.

    /*
         Example 1
         Input: nums1 = [4,1,2], nums2 = [1,3,4,2]
         Output: [-1,3,-1]
         Explanation: 
         - 4 → No greater element, so `-1`
         - 1 → Next greater element is `3`
         - 2 → No greater element, so `-1`

        Example 2
        Input: nums1 = [2,4], nums2 = [1,2,3,4]
        Output: [3,-1]
        Explanation:
        - 2 → Next greater element is `3`
        - 4 → No greater element, so `-1`
     */


    //    Optimal Solution: Monotonic Stack

    //    The best approach is to use a monotonic decreasing stack:

    //    Iterate over nums2 from left to right.
    //    Use a stack to keep track of elements whose next greater element is yet to be found.
    //    If the current element is greater than the top of the stack, pop elements from the stack and store their next greater element in a dictionary.
    //    Map results from nums2 to nums1 using a dictionary.

    //    Time Complexity:

    //    O(N + M) where N is the size of nums2, and M is the size of nums1.
    //    Each element is pushed and popped at most once → O(N).
    //    Lookup in the dictionary is O(1).
    public class NextGreaterElementI
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> nextGreaterMap = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();

            // Iterate over nums2 to find the next greater elements
            foreach (int num in nums2)
            {
                // If the current number is greater than the top of the stack, map it
                while (stack.Count > 0 && stack.Peek() < num)
                {
                    nextGreaterMap[stack.Pop()] = num;
                }
                stack.Push(num);
            }

            // Elements left in the stack have no greater element, set them to -1
            while (stack.Count > 0)
            {
                nextGreaterMap[stack.Pop()] = -1;
            }

            // Build result for nums1
            int[] result = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = nextGreaterMap[nums1[i]];
            }

            return result;
        }
    }
}
