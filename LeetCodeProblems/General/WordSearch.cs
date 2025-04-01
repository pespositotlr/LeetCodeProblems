using System;
using System.Collections.Generic;

// Cognitiv problem
// Word Search:
// Given a 2D grid of letters (G), and a string (S). 
// Write a program that will find the string and output its location.

// Example:
// G =            S = "EASY"
// D R A H M
// T A U Z I
// R S R P D
// F O G T Y
// E A S Y X

// var G = new[,] {{'D', 'R', 'A', 'H', 'M'}, {'T', 'A', 'U', 'Z', 'I'}, {'R', 'S', 'R', 'P', 'D'}, {'F', 'O', 'G', 'T', 'Y'}, {'E', 'A', 'S', 'Y', 'X'}};
// var G = new char[][] {new char[] {'D', 'R', 'A', 'H', 'M'}, new char[] {'T', 'A', 'U', 'Z', 'I'}, new char[] {'R', 'S', 'R', 'P', 'D'}, new char[] {'F', 'O', 'G', 'T', 'Y'}, new char[] {'E', 'A', 'S', 'Y', 'X'}};

// var S = "EASY";

public class WordSearch
{
    public static void WordSearch_Main()
    {
        Console.WriteLine("Hello");
        //Look horizontal (left to right)
        //Look horizontal (right to left)
        //Look verticla (top to bottom)
        //Look vertical (bottom to top)
        //Look diagonal (top left to bottom right)
        //Look diagonal (bottom right to top left)
        //Two pointer, check elftmost and righmost
        //Based on length of string and length of "search area"
        var G = new char[][] { new char[] { 'D', 'R', 'A', 'H', 'M' }, new char[] { 'T', 'A', 'U', 'Z', 'I' }, new char[] { 'R', 'S', 'R', 'P', 'D' }, new char[] { 'F', 'O', 'G', 'T', 'Y' }, new char[] { 'E', 'A', 'S', 'Y', 'X' } };
        var S = "EASY";

        var resultStart = -1;
        var resultEnd = -1;
        LookHorizontal(G, S, ref resultStart, ref resultEnd);

    }

    public static void LookHorizontal(char[][] G, string S, ref int resultStart, ref int resultEnd)
    {
        //A better solution rather than to look through rows would be to just send a string to "search" and the outer function constructs a string based on rows, columns, diagonals
        for(int i = 0; i < G.Length; i++)
        {
            //Grid indexes
            int Gl = 0;
            int Gr = G[i].Length - 1;

            //Search term indexes
            int Sl = 0;
            int Sr = G[i].Length - 1;

            bool matchFound = false;
            int currentResultStart = -1;
            int currentResultEnd = -1;
            //Check leftmost for first/last letter
            //CHeck rightmost for first/last letter
            //If match OR length between letters is great enough, continue

            while (Gr - Gl >= S.Length || matchFound)
            {
                //A better method would be to make these four individual *while* statements that check and stop checking if matchFond = false
                //Check forward string from left to right
                if (G[i][Gl] == S[Sl])
                {
                    //Check if found start of the word at start of G
                    //move backwards and set MatchFound = trrue
                    matchFound = true;
                    Gl++;
                    Sl++;

                }

                //Check forward string from right to left
                if (G[i][Gl] == S[Sr])
                {
                    //Check if found end of the word at start of G
                    //decrement Sr

                }

                //Check backwards string from left to right
                if (G[i][Gr] == S[Sl])
                {
                    //Check if found start of the word at end of G
                    //


                }

                List<int> listOfNumbers = new List<int>() { 1, 2, 3, 4, 5 };

                //Check backwards string from right to left
                if (G[i][Gr] == S[Sr])
                {
                    //Check if found end of the word at end of G

                }

            }
        }
    }
}

//Found answer (Brute Force Approach)
//How It Works
//Iterates through each cell in the grid.
//If a cell matches the first character of SS, it checks all eight directions.
//If the word is found in any direction, it prints the starting coordinates.
//If no match is found, it prints "Word not found.".
class GridSearch
{
    static int[] rowDirs = { -1, -1, -1, 0, 0, 1, 1, 1 };
    static int[] colDirs = { -1, 0, 1, -1, 1, -1, 0, 1 };

    static bool SearchFrom(char[,] grid, int row, int col, string word)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int len = word.Length;

        for (int dir = 0; dir < 8; dir++)
        {
            int r = row, c = col, k;

            for (k = 0; k < len; k++)
            {
                if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r, c] != word[k])
                    break;

                r += rowDirs[dir];
                c += colDirs[dir];
            }

            if (k == len)
                return true;
        }
        return false;
    }

    static void FindStringInGrid(char[,] grid, string word)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        bool found = false;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i, j] == word[0] && SearchFrom(grid, i, j, word))
                {
                    Console.WriteLine($"Word found at ({i}, {j})");
                    found = true;
                }
            }
        }

        if (!found)
            Console.WriteLine("Word not found.");
    }

    static void WordSearchMain2()
    {
        char[,] grid = {
            { 'G', 'E', 'E', 'K', 'S' },
            { 'F', 'O', 'R', 'Q', 'U' },
            { 'A', 'B', 'C', 'D', 'E' },
            { 'G', 'E', 'E', 'K', 'S' },
            { 'F', 'O', 'R', 'Q', 'U' }
        };

        string word = "GEEK";
        FindStringInGrid(grid, word);
    }
}










// // Your last MySQL code is saved below:
// // -- https://drive.google.com/file/d/17s0AKsdIvVHc0yMRTc4-KR6NAD_2wCHo
// // -- 1. Get the titles of all the books ("Book") that were checked out ("Checked Out") 
// // --  this year by Alice Johnson.
// // -- 2. Get the list of items that are currently checked out, to whom, and since when.

// // -- Use these to browse around
// // -- SHOW TABLES;
// // -- SELECT column_name, data_type FROM information_schema.columns WHERE table_name = 'material_state_history';

// // -- SELECT * 
// // -- FROM material m
// // -- INNER JOIN material_state_history msh ON m.material_id = msh.material_id
// // -- INNER JOIN material_type mt ON mt.material_type_id = m.material_type_id
// // -- INNER JOIN patron p ON p.patron_id = msh.patron_id
// // -- INNER JOIN material_state ms ON ms.material_state_id = m.material_state_id
// // -- WHERE mt.material_type_name = 'Book'
// // -- AND ms.material_state_name = 'Checked Out'
// // -- AND YEAR(msh.date)
// // -- AND p.first_name = "Alice" AND p.last_name = "Johnson"
// // -- Needs to be checked out and then not checked back in

// // SELECT m.name, p.first_name, p.last_name, msh.date
// // FROM material m
// // INNER JOIN material_state_history msh ON m.material_id = msh.material_id AND m.material_state_id = msh.material_state_id
// // INNER JOIN patron p ON p.patron_id = msh.patron_id
// // INNER JOIN material_state ms ON ms.material_state_id = m.material_state_id
// // AND ms.material_state_name = 'Checked Out'