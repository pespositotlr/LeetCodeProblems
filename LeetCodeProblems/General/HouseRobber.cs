using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/house-robber/
    /// You want to rob houses but you can't rob adjacent houses. Each has a different amount of money stashed in it.
    /// Find the maximum amount of money you can rob without robbing adjacent houses.
    /// Houses:
    /// [1|2|3|1]
    ///      -
    ///    /   \
    ///   1     2  
    ///  / \     \ 
    /// 3  1      1
    /// The trick is once you've chosen one, you then want the max of a subarray [Everything non-adjacent to your first pick]
    /// Ultimatley we have an array of "max total robbed" as we continue on the array
    /// Houses:                   [1|2|3|1]
    /// Max totals at that index:  1 2 4 3
    /// You only need to remember "the most so far" one house back and two houses back, so you don't need the whole array
    ///</summary>
    internal class HouseRobber
    {
        public int Rob(int[] nums)
        {
            //We only need to remember the last two choices, since we're moving linearly, so thes are our memo
            int rob1 = 0; //Previous maximum amount robbed
            int rob2 = 0; //Current maximum amount robbed
            //You can't take both rob1 and rob2 becasue they're adjacent
            
            //rob1 first, rob2 second, n, n+1 etc...
            foreach(int n in nums)
            {
                //Find which is more, the current house and "the total up to two houses ago",
                //or "the total up to one house ago"
                var temp = Math.Max(n + rob1, rob2); 

                //Get the memo variables ready for the next iteration
                rob1 = rob2; //shift rob1 up to rob 2 (the next max forward)
                rob2 = temp; //rob2 is now shifted forward to the next max
            }

            return rob2; //rob 2 at the end includes our last "max" (stored in temp)
        }
    }
}
