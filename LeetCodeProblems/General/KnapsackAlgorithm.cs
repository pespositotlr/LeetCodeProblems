using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://www.csharpstar.com/csharp-knapsack-problem/
    /// https://en.wikipedia.org/wiki/Knapsack_problem
    /// The knapsack problem is a problem in combinatorial optimization: Given a set of items, each with a weight and a value, 
    /// determine the number of each item to include in a collection so that the total weight is less than or equal to a given limit and the total value is as large as possible.
    /// </summary>
    class KnapsackAlgorithm
    {
        public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] knapSackValue = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        knapSackValue[i, w] = 0; //If total items or total weight is 0, that value is 0
                    else if (weight[i - 1] <= w)
                    {
                        // i-1 is used so i represents item 1 but index 0
                        // store max value of current item's value plus previous and previous output at same weight an
                        var currentValue = value[i - 1];
                        var currentWeight = weight[i - 1];
                        var knapSackValueForCurrentItemAndWeight = knapSackValue[i - 1, w];
                        var knapSackValueForCurrentItemAndDifferenceWithPreviousWeight = knapSackValue[i - 1, w - currentWeight];
                        knapSackValue[i, w] = Math.Max(currentValue + knapSackValueForCurrentItemAndDifferenceWithPreviousWeight, knapSackValueForCurrentItemAndWeight);
                    }
                    else
                        knapSackValue[i, w] = knapSackValue[i - 1, w];
                }
            }

            return knapSackValue[itemsCount, capacity];
        }
    }
}
