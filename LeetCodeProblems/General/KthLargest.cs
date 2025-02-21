using LeetCodeProblems.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    public class KthLargest
    {
        MinHeap minHeap;
        int k;

        public KthLargest(int k, int[] nums)
        {
            //minheap with K largest integers
            this.k = k;
            //I'm using a Minheap implementation I found somewhere, there's no default one in C#
            minHeap = new MinHeap(nums.Length);
            foreach (int n in nums)
                minHeap.Add(n);

            //Now remove everything but the kth largest integers
            while (minHeap.Length > k)
                minHeap.Pop(); //Pop the smallest values, since it's a MinHeap
        }

        public int Add(int val)
        {
            minHeap.Add(val);
            while (minHeap.Length > k)
                minHeap.Pop(); //Pop smallest value
            return minHeap.Peek();
        }

        //Using C#'s build in PriorityQueue (Min Heap)
        static int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            foreach (var num in nums)
            {
                minHeap.Enqueue(num, num);
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue(); //Removes item at lowest priority
                }
            }

            return minHeap.Peek(); //Returns lowest priority element (kth)
        }

        //Time Complexity: O(n log k) (Loop through all nums and also prioritize k of them)
        //Space Complexity: O(k)

        static void Main()
        {
            int[] nums = { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            Console.WriteLine(FindKthLargest(nums, k)); // Output: 5
        }
    }

    //Alternative using a queue in place of a min heap
    //https://www.geeksforgeeks.org/kth-largest-element-in-a-stream/
    public class GFG
    {

        /*
        using min heap DS

        how data are stored in min Heap DS
               1
             2   3
        if k==3 , then top element of heap
        itself the kth largest element

        */
        static Queue<int> min;
        static int k;

        static List<int> getAllKthNumber(int[] arr)
        {

            // List to store kth largest number
            List<int> list = new List<int>();

            // One by one adding values to the min heap
            foreach (int val in arr)
            {

                // if the heap size is less than k, we add to the heap
                if (min.Count < k)
                    min.Enqueue(val);

                /*
                Otherwise,
                first we compare the current value with the
                min heap TOP value

                if TOP val > current element, no need to
                remove TOP, because it will be the largest kth
                element anyhow

                else we need to update the kth largest element
                by removing the top lowest element
                */
                else
                {
                    if (val > min.Peek())
                    {
                        min.Dequeue();
                        min.Enqueue(val);
                    }
                }

                // if heap size >=k we add
                // kth largest element
                // otherwise -1

                if (min.Count >= k)
                    list.Add(min.Peek());
                else
                    list.Add(-1);
            }
            return list;
        }

        /// <summary>
        /// https://medium.com/@dorlugasigal/c-10-priorityqueue-is-here-5067e2628470
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        int FindKthLargestPriorityQueue(int[] nums, int k)
        {
            PriorityQueue<int, int> pq = new();
            foreach(var item in nums)
            {
                pq.Enqueue(item, item);
                if (pq.Count > k)
                    pq.Dequeue();
            }

            return pq.Peek();

        }

        // Driver Code
        public static void Main_Kth(String[] args)
        {
            min = new Queue<int>();
            k = 3;
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            // Function call
            List<int> res = getAllKthNumber(arr);
            foreach (int x in res) Console.Write(
                "Kth largest element is " + x + "\n");
        }
    }
}
