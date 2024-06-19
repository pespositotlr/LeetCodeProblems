using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    public class MedianOfTwoSortedArrays
    {

        // Function to calculate median
        // Count while merging
        // array1[] = {1, 12, 15, 26, 38}
        // array2[] = {2, 13, 17, 30, 45}
        // Output: 16
        // After merging two arrays, we get {1, 2, 12, 13, 15, 17, 26, 30, 38, 45}
        // The middle two elements are 15 and 17
        // The average of middle elements is (15 + 17)/2 which is equal to 16
        // https://www.geeksforgeeks.org/csharp-program-for-median-of-two-sorted-arrays-of-same-size/
        //Use merge procedure of merge sort. Keep track of count while comparing elements of two arrays.
        //If count becomes n(For 2n elements), we have reached the median.
        //Take the average of the elements at indexes n-1 and n in the merged array.
        static int getMedian(int[] array1, int[] array2, int lengthOfArray)
        {
            int i = 0;
            int j = 0;
            int count;
            int median1 = -1, median2 = -1;

            // Since there are 2n elements, the median will be average of 
            // elements at index n-1 and n in the array obtained after merging array1 and array2
            for (count = 0; count <= lengthOfArray; count++)
            {
                // Below is to handle case where all elements of array[] are smaller than smallest (or first) element of array2[] 
                if (i == lengthOfArray)
                {
                    median1 = median2;
                    median2 = array2[0];
                    break;
                }

                // Below is to handle case where all elements of array2[] are smaller than the smallest (or first) element of array1[]
                else if (j == lengthOfArray)
                {
                    median1 = median2;
                    median2 = array1[0];
                    break;
                }
                // equals sign because if two arrays could have some common elements 
                if (array1[i] <= array2[j])
                {
                    // Store the prev median 
                    median1 = median2;
                    median2 = array1[i];
                    i++;
                }
                else
                {
                    // Store the prev median 
                    median1 = median2;
                    median2 = array2[j];
                    j++;
                }
            }

            return (median1 + median2) / 2;
        }

        // Driver Code
        public static void Run()
        {
            int[] ar1 = { 1, 12, 15, 26, 38 };
            int[] ar2 = { 2, 13, 17, 30, 45 };

            int n1 = ar1.Length;
            int n2 = ar2.Length;
            if (n1 == n2)
                Console.Write("Median is " +
                            getMedian(ar1, ar2, n1));
            else
                Console.Write("arrays are of unequal size");
        }

        public static double getMedianBinarySearch(int[] nums1, int[] nums2, int n)
        {
            // according to given constraints all numbers are in
            // this range
            var low = (int)-1.0E9;
            var high = (int)1.0E9;
            var pos = n;
            var ans = 0.0;
            // binary search to find the element which will be
            // present at pos = totalLen/2 after merging two
            // arrays in sorted order
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                // total number of elements in arrays which are
                // less than mid
                var ub = upperBound(nums1, mid) + upperBound(nums2, mid);
                if (ub <= pos)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            ans = low;
            // As there are even number of elements, we will
            // also have to find element at pos = totalLen/2 - 1
            pos--;
            low = (int)-1.0E9;
            high = (int)1.0E9;
            while (low <= high)
            {
                var mid = low + ((high - low) >> 1);
                var ub = upperBound(nums1, mid) + upperBound(nums2, mid);
                if (ub <= pos)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            // average of two elements in case of even
            // number of elements
            ans = (ans + low * 1.0) / 2;
            return ans;
        }
        // a function which returns the index of smallest
        // element which is strictly greater than key (i.e. it
        // returns number of elements which are less than or
        // equal to key)
        public static int upperBound(int[] arr, int key)
        {
            var low = 0;
            var high = arr.Length;
            while (low < high)
            {
                var mid = low + ((high - low) >> 1);
                if (arr[mid] <= key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }
        public static void Main(String[] args)
        {
            int[] arr = { 1, 4, 5, 6, 10 };
            int[] brr = { 2, 3, 4, 5, 7 };
            var median = getMedian(arr, brr, arr.Length);
            Console.WriteLine("Median is " + median.ToString());
        }
    }
}
