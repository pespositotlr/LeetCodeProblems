using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeetCodeProblems.General
{
    //https://leetcode.com/problems/container-with-most-water/
    //You are given an integer array height of length n.
    //There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and(i, height[i]).
    //Find two lines that together with the x-axis form a container, such that the container contains the most water.
    //Return the maximum amount of water a container can store.
    internal class ContainerWithMostWater
    {
        public int MaxArea1(int[] height)
        {
            //Brute Force method
            int result = 0;
            int area;

            for (int l = 0; l < height.Length; l++)
            {
                for (int r = (l + 1); r < height.Length; r++)
                {
                    //Get the rectangle area. Height is whichever is the "lower wall"
                    area = (r - l) * Math.Min(height[l], height[r]);
                    result = Math.Max(result, area);
                }
            }

            return result;
        }
        public int MaxArea2(int[] height)
        {
            //Two Pointer technique
            //Linear time solution O(n)
            //Shift whichever pointer is at a lower value between the two until they meet
            int result = 0;
            int l = 0;
            int r = height.Length - 1;
            int area;

            while (l < r)
            {
                area = (r - l) * Math.Min(height[l], height[r]);
                result = Math.Max(result, area);

                //Shift the pointer of the lower value in hopes of getting a higher one
                if (height[l] <= height[r])
                    l++;
                else
                    r--;
            }

            return result;
        }
    }
}
