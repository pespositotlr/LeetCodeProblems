using LeetCodeProblems.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class KthLargest
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
