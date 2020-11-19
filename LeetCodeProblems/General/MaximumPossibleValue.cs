using System;
using System.Collections.Generic;
using System.Text;

//https://brainly.in/question/12867502#:~:text=Answered-,Write%20a%20function%20solution%20that%2C%20given%20an%20integer%20N%2C%20returns,the%20function%20should%20return%205268.&text=Given%20N%20%2D999%2C%20the%20function%20should%20return%20%2D5999.
//<div class="brinza-task-description">
//<p>Write a function<tt style="white-space:pre-wrap"> solution</tt> that, given an integer N, returns the maximum possible value obtained by inserting one '5' digit inside the decimal representation of integer N.</p>
//<p><b>Examples:</b></p>
//<p>1. Given N = 268, the function should return <b>5</b>268.</p>
//<p>2. Given N = 670, the function should return 67<b>5</b>0.</p>
//<p>3. Given N = 0, the function should return <b>5</b>0.</p>
//<p>4. Given N = −999, the function should return −<b>5</b>999.</p>
//<p>Assume that:</p>
//<blockquote><ul style = "margin: 10px;padding: 0px;" >< li > N is an integer within the range[< span class="number">−8,000</span>..<span class="number">8,000</span>].</li>
//</ul>
//</blockquote><p>In your solution, focus on<b><b>correctness</b></b>. The performance of your solution will not be the focus of the assessment.</p>
//</div>
namespace LeetCodeProblems
{
    class MaximumPossibleValue
    {
        public static int Solution(int N)
        {

            //Base case
            if (N == 0)
            {
                return 50;
            }

            List<int> digitsList = new List<int>();
            bool isPositive = N > 0;
            N = Math.Abs(N); //Use absolute to avoid negative number problems

            //Loop to add all digits of N to the digitsList
            while (N > 0)
            {
                digitsList.Add(N % 10);
                N /= 10;
            }

            int outputValue = 0;
            bool isAdded = false;

            //Chose position based on largest valued digit where adding 5 at that point would increase positive value
            for (int i = digitsList.Count - 1; i >= 0; i--)
            {
                if (isPositive)
                {
                    if (!isAdded && digitsList[i] < 5)
                    {
                        outputValue = outputValue * 10 + 5;
                        isAdded = true;
                    }
                }
                else
                {
                    if (!isAdded && digitsList[i] > 5)
                    {
                        outputValue = outputValue * 10 + 5;
                        isAdded = true;
                    }
                }

                outputValue = outputValue * 10 + digitsList[i];
            }

            //Operation didn't find anything so add 5 to the last digit
            if (!isAdded)
            {
                outputValue = outputValue * 10 + 5;
            }

            //Return as negative if needed
            return outputValue * (isPositive ? 1 : -1);

        }
    }
}