using System;
using System.Linq;
//<div class="task-description__TaskContentWrapper-sc-380ibo-1 xtrBv task-description-content">

//<meta http-equiv="content-type" content="text/html; charset=utf-8">


//<div class="brinza-task-description">
//<p>We are given a string S of length N consisting only of letters 'A' and/or 'B'. Our goal is to obtain a string in the format "A...AB...B" (all letters 'A' occur before all letters 'B') by deleting some letters from S.In particular, strings consisting only of letters 'A' or only of letters 'B' fit this format.</p>
//<p>Write a function:</p>
//<blockquote><p style = "font-family: monospace; font-size: 9pt; display: block; white-space: pre-wrap" >< tt >class Solution { public int solution(string S); }</tt></p></blockquote>
//<p>that, given a string S, returns the minimum number of letters that need to be deleted from S in order to obtain a string in the above format.</p>
//<p><b>Examples:</b></p>
//<p>1. Given S = "BAAABAB", the function should return 2. We can obtain "AAABB" by deleting the first occurrence of 'B' and the last occurrence of 'A'.</p>
//<p>2. Given S = "BBABAA", the function should return 3. We can delete all occurrences of 'A' or all occurrences of 'B'.</p>
//<p>3. Given S = "AABBBB", the function should return 0. We do not have to delete any letters, because the given string is already in the expected format.</p>
//<p>Write an<b><b>efficient</b></b> algorithm for the following assumptions:</p>
//<blockquote><ul style = "margin: 10px;padding: 0px;" >< li > N is an integer within the range[< span class="number">1</span>..<span class="number">100,000</span>];</li>
//<li>string S consists only of the characters 'A' and/or 'B'.</li>
//</ul>
//</blockquote></div>
//<div style = "margin-top:5px" >
//< small > Copyright 2009–2020 by Codility Limited.All Rights Reserved.Unauthorized copying, publication or disclosure prohibited.</small>
//</div>

//</div>

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class MinDeletionsToObtainStringInRightFormat
{
    public int solution(string S)
    {
        if (S.Length == 0)
            return 0;

        //Take count of all As and Bs
        int Acount = S.Count(x => x == 'A');
        int Bcount = S.Length - Acount;
        int numberToRemove = 0;

        for (int i = 0; i < S.Length; i++)
        {
            char currentChar = S[i];
            if (currentChar == 'B')
            {
                //If more A's then B's then delete the B,
                //If more B's then A's left then delete the A
                if (Acount >= Bcount)
                {
                    numberToRemove++;
                }
                else
                {
                    // More Bs than As left so we are keeping the B.
                    // Assume you delete the rest of the As.
                    return numberToRemove + Acount;
                }

                //Represents deleting an B
                Bcount--;
            }
            else
            {
                //Represents deleting an A
                Acount--;
            }
        }

        return numberToRemove;
    }
}
