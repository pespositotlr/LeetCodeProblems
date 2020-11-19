using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class NonRepeatingElement
    {
        public static int FirstNonRepeating(int[] inputArray, int inputArrayLength)
        {
            for (int i = 0; i < inputArrayLength; i++) //Loop through all letters from beginning
            {
                int j;
                for (j = 0; j < inputArrayLength; j++) //Loop through all letters from beginning, break if on different index and same letter
                {
                    if (i != j && inputArray[i] == inputArray[j])
                        break;
                }
                if (j == inputArrayLength) //Did not "break", so no duplicate was found
                    return inputArray[i];
            }
            return -1;
        }
    }
}
