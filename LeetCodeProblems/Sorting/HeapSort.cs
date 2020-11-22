using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Sorting
{
    /// <summary>
    /// https://www.csharpstar.com/heap-sort-csharp-program/
    /// it divides its input into a sorted and an unsorted region, and it iteratively shrinks the unsorted region by extracting the largest element and moving that to the sorted region
    /// It first removes the topmost item (the largest) and replace it with the rightmost leaf.
    /// The topmost item is stored in an array and Re-establish the heap.
    /// This is done until there are no more items left in the heap.
    /// </summary>
    // Best: Ω(n log(n))
    // Average: Θ(n log(n))
    // Worst: O(n log(n))
    // Space Complexity Worst: O(1)
    class HeapSort
    {
        int[] inputArray = { 2, 5, 1, 10, 6, 9, 3, 7, 4, 8 };
        public void DoHeapSort()
        {
            int i, t;
            for (i = 5; i >= 0; i--) //Uses 5 as pivot point
            {
                Adjust(i, 9);
            }
            for (i = 8; i >= 0; i--)
            {
                t = inputArray[i + 1];
                inputArray[i + 1] = inputArray[0];
                inputArray[0] = t;
                Adjust(0, i);
            }
        }
        private void Adjust(int i, int n)
        {
            int t, j;
            try
            {
                t = inputArray[i];
                j = 2 * i;
                while (j <= n)
                {
                    if (j < n && inputArray[j] < inputArray[j + 1])
                        j++;
                    if (t >= inputArray[j])
                        break;
                    inputArray[j / 2] = inputArray[j];
                    j *= 2;
                }
                inputArray[j / 2] = t;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Array Out of Bounds ", e);
            }
        }
        public void PrintArray()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}", inputArray[i]);
            }

        }
        public static void MainHeapSort()
        {
            HeapSort obj = new HeapSort();
            Console.WriteLine("Elements Before sorting : ");
            obj.PrintArray();
            obj.DoHeapSort();
            Console.WriteLine("Elements After sorting : ");
            obj.PrintArray();
            Console.Read();
        }
    }
}
