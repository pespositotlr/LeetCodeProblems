using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    public class ReverseArrayInPlace
    {
        static void ReverseArray(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]); // Swap
                left++;
                right--;
            }
        }

        static void ReverseArrayInPlaceMain()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            ReverseArray(arr);
            Console.WriteLine(string.Join(", ", arr)); // Output: 5, 4, 3, 2, 1
        }
        // Time Complexity: O(n)
        // Space Complexity: O(1) (In-Place)
    }
}
