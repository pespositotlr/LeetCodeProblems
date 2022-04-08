using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    class CoinChange
    {

        /// <summary>
        /// Coin Change - Dynamic Programming Bottom Up - Leetcode 322
        /// Explanation video:
        /// https://www.youtube.com/watch?v=H9bfqozjoqs
        /// Speed: O(amount * lenfth(count)
        /// Space: O(amount)
        /// </summary>
        /// <param name="coins">Coin valuations</param>
        /// <param name="amount">Target amount you want to coins to add up to exactly</param>
        /// <returns></returns>
        public static int getCoinChange(List<int> coins, int amount)
        {
            //Array is only as big as the target amount
            //dp[a] represents the dynamic programmed stored value of the subproblem of "the minimum number of coins for that amount".
            int[] dp = new int[amount + 1]; 

            for (var i = 0; i < dp.Length; ++i)
                dp[i] = amount + 1; //Default values

            dp[0] = 0; //Base case

            //Compute every value in dp. Bottom up, storing amount from 0 up to the target amount.
            for (int amt = 1; amt < (amount + 1); amt++)
            {
                foreach (int coin in coins)
                {
                    if (amt - coin >= 0) //If a - c is negative, then you went past the total
                    {
                        //For example:
                        //coin = 4
                        //a = 7
                        //dp[7] = 1 + dp[3]
                        dp[amt] = Math.Min(dp[amt], 1 + dp[amt - coin]);
                    }
                }
            }

            //Print dynamic values
            for (int a = 1; a < (amount + 1); a++)
            {
                Console.WriteLine($"dp[{a}] = {dp[a]}");
            }

            //If there was no value found, so the index is the default value, then return -1, meaning it's impossible to get the amount with the given coins.
            return dp[amount] != amount + 1 ? dp[amount] : -1;
        }

    }
}
