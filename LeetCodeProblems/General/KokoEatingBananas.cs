using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// The default way of doing this would be to do a brute-force approach of all possible rates until you find it
    /// We're doing a binary search of "possible rates" (k) that Koko could eat the piles of bananas, looking for the minimum
    /// Can't jump to a new pile until one hour is done
    /// https://leetcode.com/problems/koko-eating-bananas/
    /// </summary>
    internal class KokoEatingBananas
    {
        public static int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1;
            int right = piles.Max(); //the maximum rate is the largest pile value, since you would never need to eat more
            var result = right;
            int k; //Rate of eating bananas
            int hours;

            while (left <= right)
            {
                //Shift midpoint
                //left + ((right - left) / 2);
                k = (left + right) / 2;
                hours = 0;
                //Find the hours it would take to eat all piles
                foreach(int p in piles)
                {
                    double eatenPerHour = (double)p / (double)k;
                    hours += (int)Math.Ceiling(eatenPerHour);
                }

                //Shift binary search area
                if (hours <= h)
                {
                    result = Math.Min(result, k); //Decrease reuslt if current k is lower
                    right = k - 1;
                } else
                {
                    left = k + 1;
                }
            }

            return result;

        }
    }
}
