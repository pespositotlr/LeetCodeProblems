using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    public class FindAllSubsetsOfNumbers1
    {
        public static IList<IList<int>> Subsets(int[] nums)
        {

            //Loop through ints
            //Add 3/3 (one), 2/3 (several), 1/3 (One for each item), 0/3 (only one)
            IList<IList<int>> result = new List<IList<int>>();

            //Check for empty input
            if (nums == null || nums.Length == 0)
                return result;

            //Sort array to more easily creat lists
            Array.Sort(nums);

            List<int> subset = new List<int>();

            //Add empty set
            result.Add(new List<int>());

            //Add all other sets recursively
            SubsetUtil(nums, nums.Length, subset, 0, result);

            return result;
        }

        private static void SubsetUtil(int[] nums, int maxLen, List<int> subset, int start, IList<IList<int>> res)
        {
            for (int i = start; i < maxLen; i++)
            {
                subset.Add(nums[i]);
                res.Add(new List<int>(subset));
                SubsetUtil(nums, maxLen, subset, i + 1, res); //Recursively add all sets, shifting start forward once each time
                subset.RemoveAt(subset.Count - 1); //Remove duplicate sets
            }

        }

        public static void Print(IList<IList<int>> result)
        {

            foreach (IList<int> subset in result)
            {
                var subsetString = "[";

                foreach (int item in subset)
                {
                    subsetString += item;
                    subsetString += ", ";
                }

                subsetString = subsetString.Trim();
                subsetString = subsetString.TrimEnd(',');

                subsetString += "]";

                Console.WriteLine(subsetString);
            }
            Console.WriteLine();
        }
    }

    public class FindAllSubsetsOfNumbers2
    {
        public static IList<IList<int>> Subsets(int[] nums)
        {

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> subset = new List<int>();
            SubsetsHelper(0, nums, subset, result);
            return result;
        }

        private static void SubsetsHelper(int start, int[] nums, IList<int> subset, IList<IList<int>> result)
        {
            // enable print to understand code
            Print(subset, start);
            result.Add(new List<int>(subset));
            for (int i = start; i < nums.Length; i++)
            {
                subset.Add(nums[i]);
                SubsetsHelper(i + 1, nums, subset, result);
                //subset.Remove(nums[i]);
            }
        }

        public static void Print(IList<int> subset, int index)
        {
            Console.WriteLine("Index: " + index);
            foreach (int i in subset)
            {
                Console.WriteLine(i);
            }
        }
    }
}
