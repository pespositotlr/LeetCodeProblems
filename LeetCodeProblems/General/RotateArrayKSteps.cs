using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    //Rotate an array to the right by k steps.
    public class RotateArrayKSteps
    {
        static void RotateArray(int[] nums, int k)
        {
            k %= nums.Length;
            Array.Reverse(nums, 0, nums.Length); //Reverse whole array
            //7, 6, 5, 4, 3, 2, 1
            Array.Reverse(nums, 0, k); //reverse from 0 to kth element
            //5, 6, 7, 4, 3, 2, 1
            Array.Reverse(nums, k, nums.Length - k); //Un-reverse from k to the end
            //5, 5, 6, 1, 2, 3, 4

        }

        static void RotateArrayKStepsMain()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            RotateArray(nums, k);
            Console.WriteLine(string.Join(", ", nums)); // Output: 5, 6, 7, 1, 2, 3, 4
        }
    }
}
