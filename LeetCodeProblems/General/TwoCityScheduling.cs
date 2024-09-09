using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://leetcode.com/problems/two-city-scheduling/description/
    /// A company is planning to interview 2n people. 
    /// Given the array costs where costs[i] = [aCosti, bCosti], 
    /// the cost of flying the ith person to city a is aCosti, and the cost of flying the ith person to city b is bCosti.
    /// (It says at the bottom that the length of cost[] is 2n
    /// </summary>
    class TwoCityScheduling
    {
        /// <summary>
        /// The key to what you want to do is you need half the people to go to City A and half the people to go to City B.
        /// One way to do it is to brute-force it where you do every combination where half go to City A and half City B and take the minimum.
        ///             [10, 20]
        ///             /       \
        ///        [30,200]   [30,200] 
        /// This solution is a 2^2n solution (inefficient)
        /// You could save time by using a cache (dynamic programming memo) as in dfs(i, aCount, bCount, totalCost) and cache based on aCount and bCount
        /// This is n^2 complexity.
        /// Then the best solution is a Greedy algorithm
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public static int TwoCitySchedCost(int[][] costs)
        {
            int total = 0;
            List<(int, int)> differenceList = new List<(int, int)>();
            //Could also do this as int[][][] just holding diff, costA, and costB. You could also make these an object with three values.

            //Calculate difference (Positive values mean B is cheaper, negative values mean A is cheaper)
            for (int i = 0; i < costs.Length; i++)
            {
                var difference = costs[i][0] - costs[i][1];
                differenceList.Add((i, difference));
            }

            //Sort the list of differences (Descending, so cheapter B values first)
            differenceList.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            //The sort causes this to be Big-O(nlogn)

            //Based on the sorted differences, add the A cost or B cost to the total
            //1st half are the cheaper B values and 2nd half are the cheaper A values 
            int j = 0;
            foreach ((int, int) items in differenceList)
            {
                if (j < Math.Floor((double)costs.Length / 2)) //Lets you know if you're in the first half
                {
                    total += costs[items.Item1][1];
                }
                else
                {
                    total += costs[items.Item1][0];
                }

                j++;
            }

            //List<(int, int[])> differenceList = new List<(int, int[])>();

            ////Calculate difference (Positive values mean B is cheaper, negative values mean A is cheaper)
            //for (int i = 0; i < costs.Length; i++)
            //{
            //    var difference = costs[i][0] - costs[i][1];
            //    differenceList.Add((difference, costs[i]));
            //}

            ////Sort the list of differences (Descending, so cheapter B values first)
            //differenceList.Sort((x, y) => y.Item1.CompareTo(x.Item1));

            //for(int i = 0; i < differenceList.Count; i++)
            //{
            //    if (i < Math.Floor((double)differenceList.Count / 2))
            //    {
            //        total += differenceList[i].Item2[1];
            //    }
            //    else
            //    {
            //        total += differenceList[i].Item2[0];
            //    }
            //}

            return total;
        }

        /// <summary>
        /// Test data: [10,100],[10,1000], [50,500], [1,100]
        /// In this case:   B    A          A            B
        /// You need to quantify "how much more important" it is to send someone to City A VS City B
        /// The easiest way would be to check the "cost difference" of the two items. (1000 - 10).
        /// If you compute this for every single person in the input array, then you can compare all the people.
        /// In this case our diff is: [90, 990, 450, 99]. 
        /// All values are positive because A is always better. But we need to send two to City B, so we should choose the ones that are relatively cheaper.
        /// So: B, A, A, B
        /// To get this we would sort this input array to:
        /// [90, 99, 450, 990] and then the first half go to City B and the second half to City A.
        /// A way to solve this is to do that but just preserve the original values somewhere so you can output the minimum cost. (100 + 10 + 50 + 100 = 260)
        /// This is nlogn because of the sorting stage which multiplies logn.
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public static int TwoCitySchedCost2(int[][] costs)
        {
            int res = 0;
            List<(int difference, int cityA, int cityB)> diffs = new List<(int difference, int cityA, int cityB)>();

            //Calculate difference (Positive/larger values mean *B* is cheaper, negative/smaller values mean *A* is cheaper)
            for (int i = 0; i < costs.Length; i++)
            {
                var cityA = costs[i][0]; //First number in the pair
                var cityB = costs[i][1]; //Second number in the pair

                diffs.Add((cityB - cityA, cityA, cityB));
            }

            //Sort based on difference in increasing order (City B values in first half, City A values in second half)
            diffs = diffs.OrderBy(x => x.difference).ToList();
            //Can also use Sort and CompareTo: diffs.Sort((x, y) => y.difference.CompareTo(x.difference));
            //Can also use default sort diffs.Sort();

            for (int i = 0; i < diffs.Count; i++)
            {
                if (i < diffs.Count / 2) //First half of the array
                {
                    res += diffs[i].cityB; //Add cost of City B
                } else //Second half of the array
                {
                    res += diffs[i].cityA; //Add cost of City A
                }

            }

            return res;
        }
    }
}
