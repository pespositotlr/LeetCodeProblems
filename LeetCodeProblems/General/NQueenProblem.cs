using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://www.c-sharpcorner.com/article/fun-with-backtracking-the-n-queen-problem/
    /// In backtracking algorithms, we try to build a solution one step at a time. 
    /// If, at some step, it becomes clear that the current path that we are on cannot lead to a solution, we go back to the previous step (backtrack) and choose a different path. 
    /// Basically, once we exhaust all our options at a certain step we go back. The classic example of backtracking is the Eight Queen Problem.
    /// 
    /// N Queen's Problem
    /// The idea is to place queens one by one in different columns, starting from the leftmost column. When we place a queen in a column, we check for clashes with already placed queens. 
    /// In the current column, if we find a row for which there is no clash, we mark this row and column as part of the solution. 
    /// If we do not find such a row due to clashes then we backtrack and return false.
    /// 1. Start in the leftmost column.
    /// 2. If all queens are placed, return true.
    /// 3. Try all rows in the current column.
    /// 4. Do the following for every tried row.
    ///    -If the queen can be placed safely in this row, then mark this [row, column] as part of the solution and recursively check if placing the queen here leads to a solution.
    ///    -If placing the queen in [row, column] leads to a solution, then return true.
    ///    -If placing queen doesn't lead to a solution then mark this [row, column] (Backtrack) and go to step (a) to try other rows.
    /// 5. If all rows have been tried and nothing worked, return false to trigger backtracking.
    /// </summary>
    public class NQueenProblem
    {
        static int N;
        static void printBoard(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        static bool toPlaceOrNotToPlace(int[,] board, int row, int col)
        {
            int i, j;
            for (i = 0; i < col; i++) //Check all columns for this row
            {
                if (board[row, i] == 1) //If value is 1, then a Queen is already placed there
                    return false;
            }
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--) //Check this row and column
            {
                if (board[i, j] == 1)
                    return false;
            }
            for (i = row, j = col; j >= 0 && i < N; i++, j--) //Check all other squares
            {
                if (board[i, j] == 1)
                    return false;
            }
            return true;
        }

        static bool theBoardSolver(int[,] board, int col)
        {
            if (col >= N)
                return true;
            for (int i = 0; i < N; i++)
            {
                if (toPlaceOrNotToPlace(board, i, col))
                {
                    board[i, col] = 1; //If it's ok to place there, place there
                    if (theBoardSolver(board, col + 1)) //Recur to the next column
                        return true;
                    // Backtracking is important in this one.
                    board[i, col] = 0; //If a recurrnace failed, undo this placement
                }
            }
            return false;
        }
        public static void MainNQueenProblem(string[] args)
        {
            Console.WriteLine("State the value of N in this program!");
            N = Convert.ToInt32(Console.ReadLine());
            int[,] board = new int[N, N];
            if (!theBoardSolver(board, 0))
            {
                Console.WriteLine("Solution not found.");
            }
            printBoard(board);
            Console.ReadLine();
        }
    }
}
