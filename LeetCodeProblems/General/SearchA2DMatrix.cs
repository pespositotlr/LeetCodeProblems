using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// Basically Binary Search with an extra step
    /// https://leetcode.com/problems/search-a-2d-matrix/
    /// time is O(log m) * O(log n)
    /// Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    /// </summary>
    internal class SearchA2DMatrix
    {
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int ROWS = matrix.Length;
            int COLS = matrix[0].Length;
            int row;

            //Binary search of rows
            int top = 0;
            int bottom = ROWS - 1;
            while (top <= bottom)
            {
                row = (top + bottom) / 2; //Set row to middle row between the two
                if (target > matrix[row][COLS - 1]) //Check if target is > largest value in that row
                    top = row + 1; //Shift top down
                else if (target < matrix[row][0]) //Check if target is < smallest value in that row
                    bottom = row - 1; //Shift bottom up
                else
                    break;
            }

            //If not in the bounds of any row, return false
            if (!(top <= bottom))
                return false;

            row = (top + bottom) / 2;
            int left = 0;
            int right = COLS - 1;
            int mid;

            //Past here is a normal binary search
            while (left <= right)
            {
                mid = (left + right) / 2; 
                if (target > matrix[row][mid]) //Check if value is right of the midpoint
                    left = mid + 1; //Shift right
                else if (target < matrix[row][mid]) //Check if target is left of the midpoint
                    right = mid - 1; //Shift left
                else
                    return true;
            }

            return false; //If we got here, assume false
        }
    }
}
