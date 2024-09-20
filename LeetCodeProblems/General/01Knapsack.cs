using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/
    /// Given N items where each item has some weight and profit associated with it and also given a bag with capacity W, [i.e., the bag can hold at most W weight in it]. 
    /// The task is to put the items into the bag such that the sum of profits associated with them is the maximum possible. 
    /// Note: The constraint here is we can either put an item completely into the bag or cannot put it at all [It is not possible to put a part of an item into the bag].
    //Examples:
    //    Input: N = 3, W = 4, profit[] = { 1, 2, 3 }, weight[] = { 4, 5, 1 }
    //    Output: 3
    //
    //    Explanation: There are two items which have weight less than or equal to 4. If we select the item with weight 4, the possible profit is 1. 
    //    And if we select the item with weight 1, the possible profit is 3. So the maximum possible profit is 3.
    //    Note that we cannot put both the items with weight 4 and 1 together as the capacity of the bag is 4.
    //
    //    Input: N = 3, W = 3, profit[] = { 1, 2, 3 }, weight[] = { 4, 5, 6 }
    //    Output: 0
    /// </summary>
    public class _01Knapsack
    {
        // Returns the maximum value that can be put in a knapsack of capacity maxWeight
        static int knapSack_recursive(int maxWeight, int[] weights, int[] values, int numberOfItems)
        {

            // Base Case
            if (numberOfItems == 0 || maxWeight == 0)
                return 0;

            // If weight of the nth item is more than Knapsack capacity W,
            // then this item cannot be included in the optimal solution
            if (weights[numberOfItems - 1] > maxWeight) //This item weighs too much so don't add it. Go to next item. (decrement numberOfItems)
            {
                return knapSack_recursive(maxWeight, weights, values, numberOfItems - 1);

            }
            else //This item IS small enough to fit in your capacity so keep recurring with this item added to your running subtotal
            {
                // Return the maximum (return value) of two cases:
                // (1) nth item included
                // (2) nth item NOT included
                return Math.Max(
                    values[numberOfItems - 1] + knapSack_recursive(maxWeight - weights[numberOfItems - 1], weights, values, numberOfItems - 1),
                    knapSack_recursive(maxWeight, weights, values, numberOfItems - 1)
                );
            }
                
        }


        // Returns the value of maximum profit
        static int knapSackRec_dp(int maxWeight, int[] weights, int[] values, int numberOfItems, int[,] dpMemo)
        {

            // Base condition
            if (numberOfItems == 0 || maxWeight == 0)
                return 0; 
            if (dpMemo[numberOfItems, maxWeight] != -1) //If you have a value for this item# and weight value already, return it rather than re-calculate it
                return dpMemo[numberOfItems, maxWeight];
            if (weights[numberOfItems - 1] > maxWeight) //This item weighs too much so don't add it. Go to next item. (decrement numberOfItems)
            {
                // Store the value of function call stack in table before return
                return dpMemo[numberOfItems, maxWeight] = knapSackRec_dp(maxWeight, weights, values, numberOfItems - 1, dpMemo);
            }
            else //This item IS small enough to fit in your capacity so keep recurring with this item added to your running subtotal
            {
                // Return value of table after storing
                return dpMemo[numberOfItems, maxWeight] = Math.Max(
                            (values[numberOfItems - 1] + knapSackRec_dp(maxWeight - weights[numberOfItems - 1], weights, values, numberOfItems - 1, dpMemo)),
                          knapSackRec_dp(maxWeight, weights, values, numberOfItems - 1, dpMemo)
                     );
            }

        }

        static int knapSack_DynamicProgramming(int maxWeight, int[] weights, int[] values, int numberOfItems)
        {

            // Declare the table dynamically
            int[,] dp = new int[numberOfItems + 1, maxWeight + 1];

            // Loop to initially filled the table with -1
            for (int i = 0; i < numberOfItems + 1; i++)
                for (int j = 0; j < maxWeight + 1; j++)
                    dp[i, j] = -1;

            return knapSackRec_dp(maxWeight, weights, values, numberOfItems, dp);
        }

        // Returns the maximum value that can be put in a knapsack of capacity W
        //weight⇢
        //item⇣/	0	1	2	3	4	5	6
        //        0	0	0	0	0	0	0	0
        //        1	0	10	10	10	10	10	10
        //        2	0	10	15	25	25	25	25
        //        3	0	10	15	40	50	55	65
        static int knapSack_BottomUp(int maxWeight, int[] weights, int[] values, int numberOfItems)
        {
            int itemIndex, currentWeightMax;
            int[,] knapsackTable = new int[numberOfItems + 1, maxWeight + 1];

            // Build table K[][] in bottom-up manner
            for (itemIndex = 0; itemIndex <= numberOfItems; itemIndex++)
            {
                for (currentWeightMax = 0; currentWeightMax <= maxWeight; currentWeightMax++)
                {
                    if (itemIndex == 0 || currentWeightMax == 0)
                        knapsackTable[itemIndex, currentWeightMax] = 0;
                    else if (weights[itemIndex - 1] <= currentWeightMax) //This item fits in the capacity so take the max of the two branch results)
                        knapsackTable[itemIndex, currentWeightMax] = Math.Max(
                                                            values[itemIndex - 1] + knapsackTable[itemIndex - 1, currentWeightMax - weights[itemIndex - 1]],
                                                            knapsackTable[itemIndex - 1, currentWeightMax]
                                                         );
                    else //This item doesn't fit in the capacity so tabularize last item's weight
                        knapsackTable[itemIndex, currentWeightMax] = knapsackTable[itemIndex - 1, currentWeightMax];
                }
            }

            return knapsackTable[numberOfItems, maxWeight];
        }

        // Driver code
        public static void Main01Knapsack()
        {
            int[] profit = new int[] { 60, 100, 120 };
            int[] weight = new int[] { 10, 20, 30 };
            int W = 50;
            int n = profit.Length;

            Console.WriteLine(knapSack_recursive(W, weight, profit, n));
        }
    }
}
