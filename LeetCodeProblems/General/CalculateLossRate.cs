using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class CalculateLossRate
    {
        public static int Calculate(int input1, int input2)
        {
            int percentageLoss = input1;
            int numberOfYears = input2;
            //We want what percent is lost in 1 year, we're given what's lost in all years.

            //double percentageLoss = 5.91;

            //percentageLoss was 5.91
            //This results in .9409
            //You're algebraically undoing (1-.03)*(1-.03)... for however many years went by
            double remainingPercentageAfterLosses = 1.0 - ((double)percentageLoss * .01);

            //Square root for 2 years, cube root for 3 years, etc.
            //This gets you what the (1-.03) value was you multiplied by for x years.
            double yearlyChangeRemainingPercent = Math.Pow(remainingPercentageAfterLosses, (1.0/(double)numberOfYears));

            //Turn this back into the percentage subtracted rather than remainder (97% to 3%)
            double result = (1.0 - yearlyChangeRemainingPercent) * 100.0;

            return Convert.ToInt32(Math.Floor(result));

        }
    }
}
