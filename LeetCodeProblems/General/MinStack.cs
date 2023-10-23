using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/min-stack/
    /// </summary>
    internal class MinStack
    {
        List<int> stack;
        List<int> minStack;
        public MinStack()
        {
           //Remember a C# list adds items to the END when you do .Add()
           stack = new List<int>();
           minStack = new List<int>();
        }

        public void Push(int val)
        {
            stack.Add(val);

            if(minStack.Count > 0)
                minStack.Add(Math.Min(minStack.Last(), val)); //Take the previous min or the new val, whichever is lower
            else
                minStack.Add(val); //If stack is empty, assume this is the current min
        }

        public void Pop()
        {
            //Need to remove from both so the minstack stays up to date
            stack.RemoveAt(stack.Count - 1);
            minStack.RemoveAt(minStack.Count - 1);
        }

        public int Top()
        {
            if (stack.Count > 0)
                return stack.LastOrDefault();
            else
                return -1;
        }

        //The key to this is we need to keep track of the minimum at every point in the stack
        //The "minimum" is stored in another stack
        public int GetMin()
        {
            if (minStack.Count > 0)
                return minStack.LastOrDefault();
            else
                return -1;
        }
    }
}
