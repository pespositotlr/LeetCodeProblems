using LeetCodeProblems.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://algodaily.com/challenges/k-largest-elements-from-list
    /// We're given a list or array of numbers, like the following:
    /// const nums = [5, 16, 7, 9, -1, 4, 3, 11, 2]
    /// Can you write an algorithm to find the k largest values in a list of n elements? 
    /// If k were 3, we'd want the three largest numbers returned. The correct logic would return [16, 11, 9]. Order is not a consideration.
    /// Constraints
    /// Length of the array <= 100000
    /// The array will contain values between -1000000000 and 1000000000
    /// The final answer will always fit in the integer range
    /// Expected time complexity : O(n logk) where k is the size of the heap
    /// Expected space complexity : O(k)
    /// </summary>
    class KLargestElementsFromList
    {

        /// <summary>
        /// Time Complexity: O((n-k)*k). If we want the output sorted then O((n-k)*k + klogk)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] kLargestMethod1(int[] nums, int k)
        {
            //https://tutorialspoint.dev/language/c-and-cpp-programs/k-largestor-smallest-elements-in-an-array
            //Method 1 (Use Bubble k times)
            //Method 2 (Use temporary array)
            //Method 3 (Use Sorting)
            //Method 4 (Use Max Heap)
            //Method 5 (Use Order Statistics)
            //Method 6 (Use Min Heap) 

            var topNums = new int[k];
            var min = nums[0];
            var minIndex = 0;
            topNums[0] = nums[0];

            //Store an arbitrary k numbers to start
            for (int i = 1; i < k; i++)
            {
                topNums[i] = nums[i];

                //Store the smallest number of these in "min"
                if (nums[i] < min)
                {
                    min = nums[i];
                    minIndex = i;
                }
            }

            //Loop through the rest of the items, if a value is larger than min, then replace it in the array and find the new min
            for (int j = k; j < nums.Length; j++)
            {
                if (nums[j] > min)
                {
                    topNums[minIndex] = nums[j];
                    var minTuple = getMin(topNums, k);
                    min = minTuple.Item1;
                    minIndex = minTuple.Item2;
                }
            }

            return topNums;
        }


        /// <summary>
        /// Time complexity: O(n + klogn)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] kLargestMethod2(int[] nums, int k)
        {
            //This would be to use a MaxHeap

            //Add all items to the heap
            var heap = new MaxHeap(nums.Length);
            for(int i = 0; i < nums.Length; i++)
            {
                heap.Add(nums[i]);
            }

            var topNums = new int[k];
            for(int j = 0; j < k; j++)
            {
                //Retrieve K items from the heap
                //(Using this perticular method is a bit slow because it re-structures the heap every Pop)
                topNums[j] = heap.Pop();
            }

            return topNums;
        }

        //Get mininum of an array of length k
        public Tuple<int, int> getMin(int[] items, int k)
        {
            int min = items[0];
            int minIndex = 0;

            for (int i = 0; i < k; i++)
            {
                if (items[i] < min)
                {
                    min = items[i];
                    minIndex = i;
                }
            }

            return new Tuple<int, int>(min, minIndex);
        }

        public void Test1()
        {
            var result = kLargestMethod2(new int[] { 5, 16, 7, 9, -1, 4, 3, 11, 2 }, 3);

            if (assertSameMembers(result, new int[] { 9, 11, 16 }))
                Console.WriteLine("PASSED: `kLargest([5, 16, 7, 9, -1, 4, 3, 11, 2], 3)` returns `[9, 11, 16]`");
            else
                Console.WriteLine("FAILED: `kLargest([5, 16, 7, 9, -1, 4, 3, 11, 2], 3)`");
        }

        public void Test2()
        {
            var result = kLargestMethod2(new int[] { 29, 17, 9, -1, -3, 11, 2 }, 6);

            if (assertSameMembers(result, new int[] { 29, 17, 11, 9, 2, -1 }))
                Console.WriteLine("PASSED: `kLargest([29, 17, 9, -1, -3, 11, 2], 6)` returns `[29, 17, 11, 9, 2, -1]`");
            else
                Console.WriteLine("FAILED: `kLargest([29, 17, 9, -1, -3, 11, 2], 6)`");
        }
        public bool assertSameMembers(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);

            return Enumerable.SequenceEqual(a, b);
        }
    }
}
