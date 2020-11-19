using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems
{
    // First you need to define all the variables and function names.
    // So I'm going to assume the intial set of data and the API function name.
    // 2 = ABC (I'm gonna check a phone to make sure I have this right)
    // 3 = DEF
    // 4 = GHI
    // 5 = JKL
    // 6 = MNO
    // 7 = PQRS
    // 8 = TUV
    // 9 = WXYZ
    // We need to get all possible words from the input string and the input string has to be interpreted from being 0 to 4 letters
    class AllPossibleWords
    {
        Dictionary<char, List<char>> lettersMapping = new Dictionary<char, List<char>> {
        { '0', new List<char>{ } },
        { '1', new List<char>{ } },
        { '2', new List<char>{'A','B','C'} },
        { '3', new List<char>{'D','E','F'} },
        { '4', new List<char>{'G','H','I'} },
        { '5', new List<char>{'J','K','L'} },
        { '6', new List<char>{'M','N','O'} },
        { '7', new List<char>{'P','Q','R','S' } },
        { '8', new List<char>{'T','U','V' } },
        { '9', new List<char>{'W','X','Y','Z' } }
        };
        
        //Create a function that takes an array as a parameter
        public void GetAllPossibleWords(char[] arrayKeypadNumbers)
        {
            if (arrayKeypadNumbers.Length == 0)
            {
                return;
            }

            var existingCombinations = new List<string>();
            var realWordCombinations = new List<string>();

            //Loop through all the numbers
            for (var i = 0; i < arrayKeypadNumbers.Length; i++)
            {
                var letters = new List<char>();
                //Combinations are held in the combination holder before added to the master list
                var combinationHolder = new List<string>();

                //If the input value doesn't exist, go to next item in input.
                if (!lettersMapping.ContainsKey(arrayKeypadNumbers[i]))
                {
                    continue;
                }

                //Get the letters for that input number (i.e. ['A','B','C'] )
                var inputNumber = arrayKeypadNumbers[i];
                letters = lettersMapping[inputNumber];
                
                //You need to create an array of all "combinations" of letters from your input to try in the final API
                //Runs for as many letters as there are as a result of the input numbers
                //So here letters is ['A','B','C'] or ['D','E','F'] etc.
                foreach(var letterToAdd in letters)
                {
                    var wordToAdd = "";
                    if (!existingCombinations.Any())
                    {
                        //Add initial items if list is empty
                        wordToAdd = letterToAdd.ToString();
                        combinationHolder.Add(wordToAdd);

                    } else
                    {
                        //Loop through all existing combinations (Start at 0)
                        foreach (var combination in existingCombinations)
                        {
                            //Combination holder holds the letters until it gets all of them added
                            //Each combination gets one letter added to it as you loop through the input set
                            wordToAdd = combination + letterToAdd.ToString();
                            combinationHolder.Add(wordToAdd);
                        }
                    }
                }

                //combinations holds all existing combinations for however many letters were added so far
                //So 'ad', 'bd', 'cd', etc.
                foreach (var combination in combinationHolder)
                {
                    //Avoid re-adding existing combinations which can happen if you have duplicate numbers
                    if (!existingCombinations.Contains(combination))
                    {
                        if (IsRealWord(combination))
                            existingCombinations.Add(combination);
                    }
                }                

            }

            //Create a new array only holding the real words.
            foreach (var combination in existingCombinations)
            {
                Console.WriteLine(combination);
            }

        }

        //Dummy function representing checking a dictionary
        public bool IsRealWord(string word)
        {
            return true;
        }
    }
}
