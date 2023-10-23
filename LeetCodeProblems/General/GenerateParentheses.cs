using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/generate-parentheses/
    /// A set is valid when you hev n open and n closed parentheses
    /// If you have an equal number of open and closed parentheses, you can only add an open parenthese
    /// You can only add a closing parentheses if the number of closed parentheses is less than the number of open parentheses
    /// for n = 3
    ///          []
    ///           |
    ///           (
    ///       /         \
    ///      ((           ()
    ///    /     \           \
    /// (((       (()          ()(
    ///  |      /     \        /   \
    ///((()   (()(   (())     ()((  ()()
    ///  |     |      |        |      |
    ///((())  (()()  (())(   ()(()  ()()(
    ///   |    |       |       |       |
    ///((())) (()()) (())()  ()(()) ()()() <-- The 5 results
    /// </summary>
    internal class GenerateParentheses
    {
        List<char> parensList; //Holds parentheses
        List<string> result; //Holds valid parenthese combinations
        int n;
        public IList<string> GenerateParenthesis(int n)
        {
            this.parensList = new List<char>(); //Holds parentheses
            this.result = new List<string>(); //Holds valid parenthese combinations
            this.n = n;
            Backtrack(0, 0);
            return result;
        }

        void Backtrack(int openN, int closedN)
        {
            //Base case, we have enough n opened and closed paretheses, return a result
            if (openN == n && closedN == n)
            {
                result.Add(String.Join("", parensList));
                return;
            }

            //Backtracking methods
            if (openN < n)
            {
                parensList.Add('(');
                Backtrack(openN + 1, closedN);
                //Need to pop this added item from the stack so it doesn't get carried into every recursive call
                parensList.RemoveAt(parensList.Count - 1);
            }

            if (closedN < openN)
            {
                parensList.Add(')');
                Backtrack(openN, closedN + 1);
                parensList.RemoveAt(parensList.Count - 1);
            }

        }
    }
}
