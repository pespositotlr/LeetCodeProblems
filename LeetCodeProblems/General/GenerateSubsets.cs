using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    public class GenerateSubsets
    {
        public static void GenerateSubsetsMain()
        {
            int[] numbers = { 1, 2, 3, 4 };
            Console.WriteLine("All Subsets:");
            Generate(numbers, 0, new List<int>());
        }

        /// <summary>
        /// https://medium.com/@nirajranasinghe/break-the-code-barriers-with-recursive-programming-and-backtracking-9b0c853da1cf
        /// This shows the concept of backtracking to generate all subsets of an array. 
        /// The GenerateSubsets function explores subsets with the current element included, making recursive calls to consider different combinations. 
        /// The base case prints the current subset, and the function backtracks by removing the last element to explore other possibilities. 
        /// The Main method demonstrates the usage by generating and printing all subsets of the array {1, 2, 3}.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="index"></param>
        /// <param name="currentSubset"></param>
        public static void Generate(int[] numbers, int index, List<int> currentSubset)
        {
            // Base case: print the current subset
            if (currentSubset.Count is not 0)
            {
                Console.WriteLine("{" + string.Join(", ", currentSubset) + "}");
            }

            // Explore subsets with the current element included
            for (int i = index; i < numbers.Length; i++)
            {
                currentSubset.Add(numbers[i]);
                Generate(numbers, i + 1, currentSubset); //Will keep recurring until it gets to the last item in numbers
                currentSubset.RemoveAt(currentSubset.Count - 1); //This step is the backtracking, removes the last item
            }
        }
    }
}
