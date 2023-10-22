using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    //https://leetcode.com/problems/top-k-frequent-elements/
    public class TopKFrequent
    {
        //Ex: 3, 3, 3, 2, 2, 1
        public static IList<int> GetTopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> numberToCount = new Dictionary<int, int>();

            //The max number of occurances has to be the length of numbs
            //It's possible to have ties (But it doesn't say what to do then)

            //we count how many times each number appears
            //Key = Numerical Value
            //Value = Frequency (count of that numerical value)
            foreach (var num in nums)
            {
                numberToCount.TryGetValue(num, out var temp);
                numberToCount[num] = temp + 1;
            }

            //Now we bucket-sort them into buckets where each bucket is based on frequency
            //and the values are lists of which numbers have that frequency
            List<int>[] bucket = new List<int>[nums.Length + 1];

            //we allocate an array in the size of the original list of numbers
            //we iterate all of the numbers and for add each number to the index in the array
            //the index represents how many times that number appeared
            //
            //    0 times -> none
            //    1 times -> number 3
            //    2 times -> number 2
            //    3 times -> number 1
            //    4 times -> none
            //    5 times -> none
            foreach (var key in numberToCount.Keys)
            {
                int frequency = numberToCount[key];
                if (bucket[frequency] == null)
                {
                    bucket[frequency] = new List<int>(); //Put a blank list by default
                }
                bucket[frequency].Add(key);
            }

            List<int> result = new List<int>();
            // we iterate the list bucket in reverse until the number of items in the result
            // list equals k, because we iterate in reverse we get the biggest numbers
            for (int pos = bucket.Length - 1; pos >= 0 && result.Count < k; pos--)
            {
                if (bucket[pos] != null)
                {
                    result.AddRange(bucket[pos]);
                }
            }

            return result;
        }

        public IList<int> TopKFrequentLinqQuery(int[] nums, int k)
        {
            var answer = (from int n in nums
                          group n by n into g
                          orderby g.Count() descending
                          select g.Key).Take(k).ToList();
            return answer;
        }
    }
}
