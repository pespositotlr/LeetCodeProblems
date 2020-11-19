using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class ZumaGame
    {
        //Remove groups of 3 of the same letter
        private static string Clamp(string str)
        {
            int i = 0;
            int j = 0;
            while (i != str.Length)
            {
                if (j == str.Length || str[i] != str[j])
                {
                    int length = j - i;

                    if (length >= 3)
                    {
                        str = str.Remove(i, length);
                        i = 0;
                        j = 0;
                    }
                    else
                    {
                        i = j;
                    }
                }

                j++;
            }

            return str;
        }

        public static int FindMinStep(string board, string hand)
        {
            Queue<(string, string)> boardsAndHands = new Queue<(string, string)>();
            HashSet<(string, string)> visited = new HashSet<(string, string)>();
            boardsAndHands.Enqueue((board, hand));
            visited.Add((board, hand));
            int result = 0;

            while (boardsAndHands.Count != 0)
            {
                int count = boardsAndHands.Count;

                for (int i = 0; i < count; i++)
                {
                    //Use this board+hand and try further moves based from it
                    var current = boardsAndHands.Dequeue();

                    //If the board is empty, then the solution has been found, return result
                    if (current.Item1 == string.Empty)
                    {
                        return result;
                    }

                    //Try each ball from hand in every position (If there's any balls left in the hand of this board+hand)
                    for (int j = 0; j < current.Item2.Length; j++)
                    {
                        var ballFromHand = current.Item2[j];
                        var remainingHandBalls = current.Item2.Remove(j, 1);

                        for (int k = 0; k < current.Item1.Length; k++)
                        {
                            //Add the ball to the board at the given position (k) and Clamp (Remove 3-in-a-rows)
                            var newBoard = current.Item1.Insert(k, ballFromHand.ToString());
                            newBoard = Clamp(newBoard);

                            var node = (newBoard, remainingHandBalls);
                            //Add a possible board+hand and mark as visited
                            if (visited.Add(node))
                            {
                                boardsAndHands.Enqueue(node);
                            }
                        }
                    }
                }

                //Every possible single move from the hand has been tried and game isn't solved, increment result
                result++;
            }

            //If we got here, no result was found
            return -1;
        }
    }
}
