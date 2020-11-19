using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    static class Permutations
    {
        public static void GetPermutations(string str)
        {
            GetAllPermutations(str, "");
        }

        //Example recursion
        //abc, ""
        ///bc, a
        ////c, ab 
        /////"", abc <-- printed
        ////b, ac
        /////"", acb <-- printed
        ///ac, b
        ////c, ba
        //////"", bac <-- printed
        ////a, bc
        /////"", bca <-- printed
        ///ab, c
        ////b, ca
        /////"", cab <-- printed
        ////a, cb
        /////"", cba <-- printed
        public static void GetAllPermutations(string str, string prefix)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string beforei = str.Substring(0, i);
                    string afteri = str.Substring(i + 1);
                    string rem = beforei + afteri;
                    GetAllPermutations(rem, prefix + str[i]);
                }
            }
        }
    }
}
