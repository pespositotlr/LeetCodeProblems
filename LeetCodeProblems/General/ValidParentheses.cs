using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class ValidParentheses
    {
        /// <summary>
        /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        ///An input string is valid if:
        ///Open brackets must be closed by the same type of brackets.
        ///Open brackets must be closed in the correct order.
        ///Every close bracket has a corresponding open bracket of the same type.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            //If first char is a close character, no need to continue, it's false
            var endChars = new char[] { ')', '}', ']' };
            if (endChars.Contains(s[0]))
                return false;

            var stack = new Stack<char>();
            //Keys contain closing chars, values contain opening chars
            var closeToOpen = new Dictionary<char, char> {
                {')', '(' }, 
                {'}', '{' }, 
                {']', '[' }
            };

            foreach(char c in s)
            {
                if(closeToOpen.ContainsKey(c)) //Is a closed char
                {
                    //Check to see if the previous item in the stack is the correct opening char. If so, pop.
                    if (stack.Any() && stack.Peek() == closeToOpen[c])
                        stack.Pop();
                    else
                        return false;
                }
                else if(closeToOpen.ContainsValue(c)) //Is an open char
                {
                    //Add this opening char to the stack. So you can get ((())) and it's valid.
                    stack.Push(c);
                }
            }

            return !stack.Any();

        }
    }
}
