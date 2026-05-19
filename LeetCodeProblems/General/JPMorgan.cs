using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    public class JPMorgan
    {
        //Two parameters
        //Array wit no duplicates (two numbers)
        // 1 3 5 7 11 17 29 63 73 83 93
        //Target 18, index of 7 and 11. When you add them you get 18
        //An integer called target
        //WHen you add the two items in the array it will equal the target
        public int[] GetTarget(int[] inputArray, int target)
        {
            inputArray = new int[]{ 1, 3, 5, 7, 11, 17, 29, 63, 73, 83, 93};
            target = 18;

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 1; j < inputArray.Length; j++)
                {
                    if(i != j)
                    {
                        if (inputArray[i] + inputArray[j] == target)
                            return new int[] { i, j };

                    }

                }
            }

            return null;

        }

        public int[] TwoSum(int[] nums, int target)
        {
            // We use a Dictionary to store: Key = the number, Value = its index
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                // Calculate the 'complement' needed to reach the target
                int complement = target - nums[i];

                // If the complement exists in our map, we found the pair!
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                // Otherwise, add the current number and its index to the map
                // and keep moving forward.
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }

            // Return an empty array or throw an exception if no solution exists
            return new int[0];
        }
    }
}
