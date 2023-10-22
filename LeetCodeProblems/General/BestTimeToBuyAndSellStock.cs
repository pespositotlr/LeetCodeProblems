using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class BestTimeToBuyAndSellStock
    {
        /// <summary>
        /// This is a sliding window problem
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// The max profit would be to buy at the minimum and then sell at the highest value chronologically AFTER the minimum
        /// Use two pointers. Left is "buy day", right is "sell day"
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int l = 0; //Buy day (We want this to be lower)
            int r = 1; //Sell day (We want this to be higher)
            int maxProfit = 0;

            while( r < prices.Length)
            {
                //If sell price is lower than buy price, check the profit margin and possibly update the max profit
                if (prices[l] < prices[r])
                {
                    var currentProfit = prices[r] - prices[l];
                    maxProfit = Math.Max(maxProfit, currentProfit);
                } else
                {
                    //Move left pointer to new minimum (You don't just increment 1 because, this is a situation where price[l] >= price[r]
                    l = r;
                }

                //Increment the right value to check the next day until all days are checked
                r++;
            }

            return maxProfit;

        }
    }
}
