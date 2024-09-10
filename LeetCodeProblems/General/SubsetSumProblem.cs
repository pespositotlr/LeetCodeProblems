using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://www.geeksforgeeks.org/subset-sum-problem/
    /// Given a set[] of non-negative integers and a value sum, the task is to print the subset of the given set whose sum is equal to the given sum.
    /// Input: set[] = {1,2,1}, sum = 3
    /// Output: [1,2],[2,1]
    /// Explanation: There are subsets[1, 2],[2,1] with sum 3.

    /// Input: set[] = {3, 34, 4, 12, 5, 2}, sum = 30
    /// Output: []
    /// Explanation: There is no subset that add up to 30.
    /// This is a backtracking problem
    /// Subset sum can also be thought of as a special case of the 0–1 Knapsack problem. For each item, there are two possibilities:
    /// Include the current element in the subset and recur for the remaining elements with the remaining Sum.
    /// Exclude the current element from the subset and recur for the remaining elements.
    /// Finally, if Sum becomes 0 then print the elements of current subset.
    /// The recursion’s base case would be when no items are left, or the sum becomes negative, then simply return.
    /// Visual guide: https://media.geeksforgeeks.org/wp-content/uploads/20230717175725/subset_Sum_Final.webp
    /// You're essentially doing a tree structure full traversal where you do:
    /// exclude arr[0], include arr[0], 
    /// then include/exclude arr[1] on each of those, etc.
    /// </summary>
    public class SubsetSumProblem
    {
        // Print all subsets if there is at least one subset of
        // set[] with a sum equal to the given sum
        static bool printSubsetsFlag = false;

        static void PrintSubsetSum(int i, int lengthOfSet, int[] set, int targetSum, List<int> subset)
        {
            // If targetSum is zero, then there exists a subset.
            if (targetSum == 0)
            {
                // Prints the valid subset
                printSubsetsFlag = true;
                Console.Write("[ ");
                foreach (var item in subset)
                {
                    Console.Write(item + " ");
                }
                Console.Write("]");
                return; //Return rather than go further down the tree
            }

            if (i == lengthOfSet)
            {
                // Return if we have reached the end of the array
                return;
            }

            // Recurr but without considering the current (i-th) element
            PrintSubsetSum(i + 1, lengthOfSet, set, targetSum, subset);

            // Consider the current element if it is less than or equal to targetSum
            if (set[i] <= targetSum)
            {
                // Push the current (i-th) element into the subset
                subset.Add(set[i]);

                // Recursive call to consider the current element, target sum is smaller
                PrintSubsetSum(i + 1, lengthOfSet, set, targetSum - set[i], subset);

                // Remove the last element to restore the subset's original configuration
                subset.RemoveAt(subset.Count - 1);
            }
        }

        // Driver code
        public static void SubsetSumProblemMain()
        {
            // Test case 1
            int[] set = { 1, 2, 1 };
            int sum = 3;
            int lengthOfSet = set.Length;
            List<int> subset = new List<int>();
            Console.WriteLine("Output 1:");
            PrintSubsetSum(0, lengthOfSet, set, sum, subset);
            Console.WriteLine();
            printSubsetsFlag = false;

            // Test case 2
            int[] set2 = { 3, 34, 4, 12, 5, 2 };
            int sum2 = 30;
            int lengthOfSet2 = set2.Length;
            List<int> subset2 = new List<int>();
            Console.WriteLine("Output 2:");
            PrintSubsetSum(0, lengthOfSet2, set2, sum2, subset2);
            if (!printSubsetsFlag)
            {
                Console.WriteLine("There is no such subset.");
            }
        }
    }
}
