using System;
using System.Collections.Generic;

/*
Given two strings, find the number of common characters between them.
Example:
For s1 = "aabcc" and s2 = "adcaa", the output should be
CommonCharacterCount(s1, s2) = 3.

The strings have 3 common characters - 2 "a"s and 1 "c".
*/
namespace LeetCodeProblems.General
{
    public class FindNumberOfCommonCharacters
    {
        public static int CommonCharacterCount(string s1, string s2)
        {

            int resultCount = 0;
            //Holds the indexes in s2 where a match already occurred so you know not to re-check
            HashSet<int> characterIndexHashset = new HashSet<int>(); 

            //Go through all of s1.
            //If you hit a value in s2, don't resuse the same s2 char
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (characterIndexHashset.Contains(j)) //Skip this j index, already found
                        continue; //Go to next j

                    if (s1[i] == s2[j])
                    {
                        characterIndexHashset.Add(j);
                        resultCount++;
                    }
                }
            }

            return resultCount;

        }
        public static int CommonCharacterCount2(string s1, string s2)
        {
            //Two dictionaries. Take the min of the two dictionaries.
            int resultCount = 0;
            Dictionary<char, int> s1Dictionary = new Dictionary<char, int>();
            Dictionary<char, int> s2Dictionary = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1Dictionary.ContainsKey(s1[i])) //Increment letter count
                    s1Dictionary[s1[i]]++;
                else
                    s1Dictionary.Add(s1[i], 1); //Add 1
            }

            for (int j = 0; j < s2.Length;j++)
            {
                if (s2Dictionary.ContainsKey(s1[j]))
                    s2Dictionary[s2[j]]++;
                else
                    s2Dictionary.Add(s2[j], 1);
            }

            //Loop through both dictionaries and add the min of each letter that matches to your total
            foreach(var kvp in s1Dictionary)
            {
                if (s2Dictionary.ContainsKey(kvp.Key))
                    resultCount += Math.Min(kvp.Value, s2Dictionary[kvp.Key]);
            }

            return resultCount;

        }
        public static void FindNumberOfCommonCharactersMain()
        {
            Console.WriteLine(CommonCharacterCount("aabaccdddddddaaaaa", "adcaa"));
        }


        //Faster version where you only create one dictionary but then only increment common count if > 0 and decrease the counter every time a match is found.
        //This only loops through each string once.
        static int CountCommonOccurrences(string str1, string str2)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int commonCount = 0;

            // Count occurrences of each character in str1
            foreach (char c in str1)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            // Count common occurrences from str2
            foreach (char c in str2)
            {
                if (charCount.ContainsKey(c) && charCount[c] > 0)
                {
                    commonCount++;
                    charCount[c]--; // Decrease count to prevent overcounting
                }
            }

            return commonCount;
        }

        static void CountCommonOccurrencesMain()
        {
            Console.Write("Enter first string: ");
            string str1 = Console.ReadLine();

            Console.Write("Enter second string: ");
            string str2 = Console.ReadLine();

            int result = CountCommonOccurrences(str1, str2);
            Console.WriteLine($"Number of common occurrences: {result}");
        }

    }
}