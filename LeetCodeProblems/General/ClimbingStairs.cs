using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/climbing-stairs/
    /// n = 5
    ///               0
    ///        /              \
    ///       1                2
    ///   /      \         /        \ 
    ///  2        3       3          4
    /// / \      / \     / \         /\
    /// 3  4     4   5  4  5         5 6
    /// /\  /\  / \    / \        
    /// 4 5 5 6 5 6    5 6
    /// |
    /// 5
    /// If you get to 6, return +0 (Don't count that list of choices)
    /// 8 valid paths for n=5
    /// To avoid redoing decisions we want to use 1-D DP (Memoization)
    /// For example, there's 2 ways we can reach the result from "step 3"
    /// The whole subtree below "2" is the same to get to 5
    /// DFS would be O(2^n) (2 choices made for every n items)
    /// The dynamic verison is O(n) because each subproblem is only solved once
    /// We start at the base case (at the top/5th step) and work our way up to solving for 0 steps (bottom-up DP)
    /// Step:             0th 1st 2nd 3rd 4th 5th
    /// Possible choices: [8] [5] [3] [2] [1] [1]
    /// You don't actually need a whole array because you don't care about the top 2 steps once you get to the lower steps
    /// So to save space we'll just use "one" and "two"
    /// </summary>
    internal class ClimbingStairs
    {
        public int ClimbStairs(int n)
        {
            if(n <= 0) return 0;

            int one = 1; //From the top step, there's one way to get there
            int two = 1; //From the second-to-top step, we can only take one step

            //Start at the top step and work our way down. (Assume 1 way from the top step)
            //Each lower step is the choices from the higher steps plus the choices to get there
            //This results in a fibbonaci sequence
            for(int i = 0; i < n - 1; i++)
            {
                var temp = one;
                one = one + two;
                two = temp;
            }

            return one;
        }

    }
}
