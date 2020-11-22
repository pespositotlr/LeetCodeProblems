using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Sorting
{
    class BubbleSort
    {
        // Bubble sort, sometimes referred to as sinking sort, is a simple sorting algorithm that repeatedly steps through the list to be sorted, 
        // compares each pair of adjacent items and swaps them if they are in the wrong order. 
        // The pass through the list is repeated until no swaps are needed, which indicates that the list is sorted. 
        // The algorithm, which is a comparison sort, is named for the way smaller elements "bubble" to the top of the list. 

        // Although the algorithm is simple, it is too slow and impractical for most problems even when compared to insertion sort. 
        // It can be practical if the input is usually in sort order but may occasionally have some out-of-order elements nearly in position.

        // Best: Ω(n) 	
        // Average: Θ(n^2) 	
        // Worst: O(n^2) 	
        // Space Complexity Worst: O(1)
        public static void BubbleSortMain()
        {
            int[] inputArray = { 3, 0, 2, 5, -1, 4, 1 };

            Console.WriteLine("Original array :");

            foreach (int item in inputArray)
                Console.Write(item + " ");

            inputArray = Bubble_Sort(inputArray);

            Console.WriteLine("\n" + "Sorted array :");
            foreach (int item in inputArray)
                Console.Write(item + " ");

            Console.Write("\n");
        }

        public static int[] Bubble_Sort(int[] inputArray)
        {
            int temp;

            for (int p = 0; p <= inputArray.Length - 2; p++)
            {
                for (int i = 0; i <= inputArray.Length - 2; i++)
                {
                    if (inputArray[i] > inputArray[i + 1])
                    {
                        temp = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i];
                        inputArray[i] = temp;
                    }
                }
            }

            return inputArray;

        }
    }

}
