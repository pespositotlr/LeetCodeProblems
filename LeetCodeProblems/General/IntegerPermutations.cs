using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/permutations/
    /// Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
    /// Example 1:
    /// Input: nums = [1,2,3]
    /// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    /// This is a backtracking problem. 
    /// But because you need to have the full length of the items you remove them in later iterations 
    /// only to add them back at higher-level calls.
    /// </summary>
    public class IntegerPermutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            //Reset the result set every time so it only tracks the outermost call with the full length of the input array
            List<IList<int>> result = new List<IList<int>>();

            //Base case, you have only one item on the list
            if (nums.Length == 1)
                return new List<IList<int>>() { new List<int>(nums) };

            //Turn the input array into a list so it's easier to manipulate
            var numsList = new List<int>(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                //Pop the 0th item
                var n = numsList[0];
                numsList.RemoveAt(0);

                //Get other permutations of the rest
                var permutations = Permute(numsList.ToArray()).ToList();
                foreach (var perm in permutations)
                {
                    perm.Add(n); //Add the item to the end of the array                    
                }

                //Add all finished permutations to the result set
                result.AddRange(permutations);

                //Add the popped item back
                numsList.Add(n);
            }

            return result;
        }

        //Other version where you swap the numbers around
        public IList<IList<int>> Permute2(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            void Backtrack(int i)
            {
                //Once i is greater than nums.length we save that "row"
                if (i >= nums.Length)
                {
                    res.Add(new List<int>(nums));
                }
                //While i is less than the length of nums we swap values around
                for (int j = i; j < nums.Length; j++)
                {
                    Swap(i, j);
                    Backtrack(i + 1);
                    Swap(i, j);
                }
            }

            void Swap(int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            Backtrack(0);
            return res;
        }

    }
}
