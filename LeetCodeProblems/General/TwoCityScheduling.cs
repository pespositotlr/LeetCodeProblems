using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class TwoCityScheduling
    {
        public static int TwoCitySchedCost(int[][] costs)
        {
            int total = 0;
            List<(int, int)> differenceList = new List<(int, int)>();

            //Calculate difference (Positive values mean B is cheaper, negative values mean A is cheaper)
            for (int i = 0; i < costs.Length; i++)
            {
                var difference = costs[i][0] - costs[i][1];
                differenceList.Add((i, difference));
            }

            //Sort the list of differences (Descending, so cheapter B values first)
            differenceList.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            //Based on the sorted differences, add the A cost or B cost to the total
            //1st half are the cheaper B values and 2nd half are the cheaper A values 
            int j = 0;
            foreach ((int, int) items in differenceList)
            {
                if (j < Math.Floor((double)costs.Length / 2))
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
    }
}
