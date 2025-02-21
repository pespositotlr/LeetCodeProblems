using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    internal class KathLargestElementInAnArray
    {

        /*
         * The Kth Largest Element in an Array problem is a common problem that can be efficiently solved using a MinHeap (Priority Queue).
         * Optimal Solution Using a MinHeap (PriorityQueue)
            Approach

                Use a MinHeap of size k:
                    Insert elements into the heap.
                    If the heap size exceeds k, remove the smallest element (ensuring we always keep the k largest elements).
                    The root of the heap will be the k-th largest element.

            Time Complexity

                Heap operations (Add and Remove) take O(log k) time.
                Iterating through nums takes O(N) time.
                Overall Complexity: O(N log k), which is much more efficient than sorting (O(N log N)).
         */

        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            // Add elements to the min-heap
            foreach (int num in nums)
            {
                minHeap.Enqueue(num, num);

                // Keep only k elements in the heap
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue(); //This removes the item with the lowest value only
                }
            }

            // The root of the heap is the kth largest element
            return minHeap.Peek();
        }

        // Test the function
        public static void KathLargestElementInAnArrayMain()
        {
            KathLargestElementInAnArray solution = new KathLargestElementInAnArray();
            int[] nums = { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            int k = 4;

            Console.WriteLine(solution.FindKthLargest(nums, k)); // Output: 4
        }
    }
}
