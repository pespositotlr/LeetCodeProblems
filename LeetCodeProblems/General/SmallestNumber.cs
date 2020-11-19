using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    class SmallestNumber
    {
        public static int solution(int[] A)
        {
            int ans = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < ans)
                {
                    ans = A[i];
                }
            }
            return ans;
        }
    }
}
