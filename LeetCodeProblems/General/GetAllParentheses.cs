using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


/*
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
For example, given n = 3, a solution set is:
[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
[
    (()),
    ()()
]
*/


namespace LeetCodeProblems.General
{
    [ServiceContract]
    public interface IInventoryService
    {
        int GetQuantityInStock(int productId);
    }

    class GetAllParentheses
    {

        public static void MainGetAllParentheses(int n)
        {
            int AnswerA = MyFunction(1, z: 100);
            int AnswerB = MyFunction(1, y:100, z: 1);
            int AnswerC = MyFunction(1, 1000);
            int AnswerD = MyFunction(1, z:10, y:10);
            int AnswerE = MyFunction(10, 1, 10);

            Dictionary<int, int> schedule = new Dictionary<int, int>();

            foreach(KeyValuePair<int, int> entry in schedule)
            {

            }

            int total = schedule.Count;

            GetAll(n, 0, "");
        }

        public static int MyFunction(int x, int y = 10, int z = 1)
        {
            int Answer;
            Answer = x * y / 10 * z;
            return Answer;
        }




        public static void GetAll(int openStock, int closedStock, string currentString)
        {

            if (openStock == 0 && closedStock == 0)
            {
                Console.WriteLine(currentString);
            }

            if (openStock > 0)
            {
                GetAll(openStock - 1, closedStock + 1, currentString + "(");
            }

            if (closedStock > 0)
            {
                GetAll(openStock, closedStock - 1, currentString + ")");
            }


        }
    }
}
