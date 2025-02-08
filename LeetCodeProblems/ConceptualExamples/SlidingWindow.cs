using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace LeetCodeProblems.ConceptualExamples
{
    //https://leetcode.com/problems/longest-continuous-increasing-subsequence/solutions/746548/c-sliding-window-technique-simple-and-easy-with-explanation/
    //The same pattern can be applied for most of the sliding Window Problems i.e continuous SubArray of string or number problems
    public class SlidingWindow
    {
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }
            int windowEnd = 0;
            int windowStart = 0;
            int currentLength = 0;
            int maxLength = 0;
            for (windowEnd = 1; windowEnd < nums.Length; windowEnd++) //Go through whole list of nums once
            {
                if (nums[windowEnd - 1] >= nums[windowEnd]) //If last item is not smaller, then you're not in an increasing subsequence, so shift start of window forward
                { //the key logic is when to change windowStart
                    windowStart = windowEnd;
                }

                currentLength = windowEnd - windowStart + 1;
                maxLength = Math.Max(currentLength, maxLength); //Store th greatest length of increasing values
            }

            return maxLength;
        }

        //https://stackoverflow.com/questions/8269916/what-is-sliding-window-algorithm-examples
        //[ 5, 7, 1, 4, 3, 6, 2, 9, 2 ]
        //How would we find the largest sum of five consecutive elements? Well, we'd first look at 5, 7, 1, 4, 3 and see
        //that the sum is 20. Then we'd look at the next set of five consecutive elements, which is 7, 1, 4, 3, 6. The sum of those is 21.
        //This is more than our previous sum, so 7, 1, 4, 3, 6 is currently the best we've got so far.

        //Let's see if we could improve. 1, 4, 3, 6, 2? No, that sums to 16. 4, 3, 6, 2, 9? That sums to 24, so now that's the best sequence we've got.
        //Now we move along to the next sequence, 3, 6, 2, 9, 2. That one sums to 22, which doesn't beat our current best of 24.
        //And we've reached the end, so we're done.

        //The brute force approach to implementing this programmatically is as follows:
        //O(n*k)
        public int getMaxSumOfFiveContiguousElements(int[] arr)
        { 
            var maxSum = -1;
            var currSum = 0;

            for (int i = 0; i <= arr.Length - 5; i++) //Start from the left and work right until you're 5 away from the end (Can't move forward)
            {
                currSum = 0;

                for (int j = i; j < i + 5; j++) //Add the next 5 elements from the current position
                {
                    currSum += arr[j];
                }

                maxSum = Math.Max(maxSum, currSum);
            }

            return maxSum;
        }

        //More efficient version that doesn't do extra additions, only checks leftmost and rightmost elements
        public int getLargestSumOfFiveConsecutiveElements(int[] arr)
        { 
            var currSum = getSum(arr, 0, 4);
            var largestSum = currSum;

            for (var i = 1; i <= arr.Length - 5; i++) //Only goes to length - 5 because you don't need to keep going once only 4 indexes are left
            {
                currSum -= arr[i - 1]; // subtract element to the left of curr window
                currSum += arr[i + 4]; // add last element in curr window (This won't get an out-of-bounds error because we never go to more than 4 from the end)
                largestSum = Math.Max(largestSum, currSum);
            }

            return largestSum;
        }

        //Get sum of values from staring index to endind index
        public int getSum (int[] arr, int start, int end)
        {
            var sum = 0;

            for (var i = start; i <= end; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
    }
}
