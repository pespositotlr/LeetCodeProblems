using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class DiceCalculator
    {

        public static int Calculate(string input1)
        {

            double output = 0;
            string[] rollsWithPlayers = input1.Split('+');


            foreach(string rollWithPlayer in rollsWithPlayers)
            {
                double numberOfPlayers = 1;

                string roll = "";

                if (rollWithPlayer.Contains("*"))
                {
                    string[] playerRolls = rollWithPlayer.Split('*');

                    numberOfPlayers = Convert.ToInt32(playerRolls[0]);
                    roll = playerRolls[1];
                } else
                {
                    roll = rollWithPlayer;
                }                                

                string[] diceRolls = roll.Split('d');
                double diceNumber = Convert.ToInt32(diceRolls[0]);
                double diceType = Convert.ToInt32(diceRolls[1]);

                double expectedOutputForDice = GetAverageDiceRoll(diceType);

                output += numberOfPlayers * (diceNumber * expectedOutputForDice);
            }

            return Convert.ToInt32(Math.Floor(output)); ;
        }

        public static double GetAverageDiceRoll(double diceType)
        {
            double output = 0;

            for (int i = 1; i <= diceType; i++)
            {
                output += i;
            }

            return output / diceType;

        }
    }
}
