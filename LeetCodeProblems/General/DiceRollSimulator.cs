using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    // https://leetcode.com/problems/dice-roll-simulation/
    // A die simulator generates a random number from 1 to 6 for each roll.
    // You introduced a constraint to the generator such that it cannot roll the number i more than rollMax[i] (1-indexed) consecutive times.
    // Given an array of integers rollMax and an integer n, return the number of distinct sequences that can be obtained with exact n rolls.
    // Two sequences are considered different if at least one element differs from each other. Since the answer may be too large, return it modulo 10^9 + 7.

    class DiceRollSimulator
    {
        int ans = 0;
        public int dieSimulator(int n, int[] rollMax)
        {
            dfs(n, rollMax, -1, 0);
            return ans;
        }

        // dieLeft : the number of dies
        // last : last number we rolled
        // curlen : current len of same number
        // This function trys to traverse all the valid permutations
        private void dfs(int dieLeft, int[] rollMax, int last, int curlen)
        {
            if (dieLeft == 0)
            {
                ans++;
                return;
            }
            for (int i = 0; i < 6; i++)
            {
                if (i == last && curlen == rollMax[i]) continue;
                dfs(dieLeft - 1, rollMax, i, i == last ? curlen + 1 : 1);
            }
        }
    }

    class DiceRollSimulatorMemoization
    {
        int[,,] dp = new int[5000, 6, 16];
        const int MAX_CONST = 1000000007;

        public int dieSimulator(int n, int[] rollMax)
        {
            return dfs(n, rollMax, -1, 0);
        }

        private int dfs(int dieLeft, int[] rollMax, int last, int curlen)
        {
            if (dieLeft == 0) return 1;
            if (last >= 0 && dp[dieLeft,last,curlen] > 0) return dp[dieLeft,last,curlen];
            int ans = 0;
            for (int i = 0; i < 6; i++)
            {
                if (i == last && curlen == rollMax[i]) continue;
                ans = (ans + dfs(dieLeft - 1, rollMax, i, i == last ? curlen + 1 : 1)) % MAX_CONST;
            }
            if (last >= 0) dp[dieLeft,last,curlen] = ans;
            return ans;
        }
        public static void DiceRollSimulatorMemoization_Main()
        {
            var diceRoller = new DiceRollSimulatorMemoization();

            // Input: n = 2, rollMax = [1,1,2,2,2,3]
            // Output: 34
            Console.WriteLine(diceRoller.dieSimulator(2, new int[] { 1, 1, 2, 2, 2, 3 }));
            // Input: n = 2, rollMax = [1, 1, 1, 1, 1, 1]
            // Output: 30
            Console.WriteLine(diceRoller.dieSimulator(2, new int[] { 1, 1, 1, 1, 1, 1 }));
            // Input: n = 3, rollMax = [1,1,1,2,2,3]
            // Output: 181
            Console.WriteLine(diceRoller.dieSimulator(3, new int[] { 1, 1, 1, 2, 2, 3 }));

        }
    }

}
