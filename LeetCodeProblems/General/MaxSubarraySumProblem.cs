using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    //https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
    public class MaxSubarraySumProblem
    {

        //Input: arr[] = {2, 3, -8, 7, -1, 2, 3}
        //Output: 11
        //Explanation: The subarray {7, -1, 2, 3}
        //has the largest sum 11.


        //Input: arr[] = {-2, -4}
        //Output: –2
        //Explanation: The subarray {-2}
        //has the largest sum -2.


        //Input: arr[] = {5, 4, 1, 7, 8}
        //Output: 25
        //Explanation: The subarray {5, 4, 1, 7, 8}
        //has the largest sum 25.

        // Function to find the sum of subarray with maximum sum
        //[Naive Approach] By iterating over all subarrays – O(n^2) Time and O(1) Space
        static int MaxSubarraySum(int[] arr)
        {
            int res = arr[0];

            // Outer loop for starting point of subarray
            for (int i = 0; i < arr.Length; i++)
            {
                int currSum = 0;

                // Inner loop for ending point of subarray
                for (int j = i; j < arr.Length; j++)
                {
                    currSum = currSum + arr[j];

                    // Update res if currSum is greater than res
                    res = Math.Max(res, currSum);
                }
            }
            return res;
        }

        static void MaxSubarraySumProblem_Main()
        {
            int[] arr = { 2, 3, -8, 7, -1, 2, 3 };
            Console.WriteLine(MaxSubarraySum(arr));
        }

        //[Expected Approach] Using Kadane’s Algorithm – O(n) Time and O(1) Space
        // Function to find the maximum subarray sum
        static int MaxSubarraySum_2(int[] arr)
        {
            int maxSoFar = arr[0];
            int currentMax = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {

                // Find the maximum sum ending at index i by either extending 
                // the maximum sum subarray ending at index i - 1 (maxEnding) or by
                // starting a new subarray from index i
                currentMax = Math.Max(currentMax + arr[i], arr[i]);
                //If Greater value is maxEnding + arr[i] you're continuing forward adding more items to the existing subarray
                //If arr[i] is greater that means you're "starting a new subarray from index i" by ignoring everything beofore i.
                //The only reason you want to "start over" is if you'd be better off re-starting from the new arr[i]

                //2 (0th index, currentMax at 2)
                //2 + 3 = 5 VS 3 (left wins, continue) (New currentMax is 5) (Greatest so far)
                //5 + -8 = -3 VS -8 (left wins, continue) (New currentMax is -3)
                //-3 + 7 = 4 VS 7 (right wins, so start new subarray at 7) (New currentMax is 7) (Greatest so far)
                //7 + -1 = 6 VS -1 (left wins, so continue) (New currentMax is 6)
                //6 + 2 = 8 VS 2 (left wins, so continue) (New currentMax is 8) (Greatest so far)
                //* + 3 = 11 VS 3 (left wins, so continue) (New currentMax is 11) (Greatest so far)
                //The largest subarray is {7, -1, 2, 3} = 11

                // Update maxSoFar if maximum subarray sum ending at index i > res
                maxSoFar = Math.Max(maxSoFar, currentMax);
            }
            return maxSoFar;
        }

        static void MaxSubarraySumProblem_Main_2()
        {
            int[] arr = { 2, 3, -8, 7, -1, 2, 3 };
            Console.WriteLine(MaxSubarraySum(arr));
        }
    }
}
