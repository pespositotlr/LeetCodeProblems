using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.Sorting
{
    class Quicksort
    {
        // https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php
        // Quick sort is a comparison sort, meaning that it can sort items of any type for which a "less-than" relation (formally, a total order) is defined.
        // Two or three times faster (at best) than merge sort or heap sort

        // It works by selecting a 'pivot' element from the array and partitioning the other elements into two sub-arrays,
        // according to whether they are less than or greater than the pivot. The sub-arrays are then sorted recursively. 
        // This can be done in-place, requiring small additional amounts of memory to perform the sorting. 

        // Efficient implementations of Quicksort are not a stable sort, meaning that the relative order of equal sort items is not preserved. 

        // Mathematical analysis of quicksort shows that, on average, the algorithm takes O(n log n) comparisons to sort n items. 
        // In the worst case, it makes O(n2) comparisons, though this behavior is rare. 

        // Best: Ω(n log(n))
        // Average: Θ(n log(n))
        // Worst: O(n^2)
        // Space Complexity Worst: O(log(n))
        public static void QuickSortMain()
        {
            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

            Console.WriteLine("Original array : ");
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();

            Quick_Sort(arr, 0, arr.Length - 1);

            Console.WriteLine();
            Console.WriteLine("Sorted array : ");

            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }
    }
}
