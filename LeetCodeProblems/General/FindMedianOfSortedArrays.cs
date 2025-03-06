using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace LeetCodeProblems.General
{
    internal class FindMedianOfSortedArrays
    {

        //Find the median of two sorted arrays.
        //We perform a binary search on the smaller array to partition both arrays such that:
        //The left half contains the smaller elements.
        //The right half contains the larger elements.
        //The median is the average of the maximum left and minimum right.
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Ensure nums1 is the smaller length array
            if (nums1.Length > nums2.Length)
                return FindMedianSortedArrays(nums2, nums1);

            int nums1Length = nums1.Length, numes2Length = nums2.Length;
            int low = 0, high = nums1Length;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (nums1Length + numes2Length + 1) / 2 - partitionX;

                // Edge cases: left partition values (or MIN_VALUE if empty)
                int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];

                // Edge cases: right partition values (or MAX_VALUE if empty)
                int minRightX = (partitionX == nums1Length) ? int.MaxValue : nums1[partitionX];
                int minRightY = (partitionY == numes2Length) ? int.MaxValue : nums2[partitionY];

                // Valid partition found
                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    if ((nums1Length + numes2Length) % 2 == 0)
                    {
                        return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxLeftX, maxLeftY);
                    }
                }
                // Adjust partition
                else if (maxLeftX > minRightY)
                {
                    high = partitionX - 1;
                }
                else
                {
                    low = partitionX + 1;
                }
            }
            throw new ArgumentException("Input arrays are not sorted correctly.");
        }
    }
}
