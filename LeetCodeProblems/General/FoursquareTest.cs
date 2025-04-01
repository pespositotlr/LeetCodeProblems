
using System;
using System.Collections.Generic;

// 1. Given a list of numbers, write a function that returns its sum.
// 2. Given a tree of numbers, write a function that returns its sum.
// 3. abstract sum to arbitrary operation
// 4. what if need to implement "median" (stat) algorithms

namespace LeetCodeProblems.General
{
    class FoursquareTest
    {
        static void FoursquareTest_Main(string[] args)
        {
            // System.Console.WriteLine("Hello, World!");
            // List<int> listOfNumbers = new List<int>(){ 1, 2, 3, 4, 5};
            // var sum = GetSumOfList(listOfNumbers);
            // System.Console.WriteLine(sum);

            //Create a list
            //order
            //Take middle-number based on length / 2

            TreeNode_FoursquareTest root = new TreeNode_FoursquareTest();
            root.value = 1;

            TreeNode_FoursquareTest child1 = new TreeNode_FoursquareTest();
            child1.value = 20;

            TreeNode_FoursquareTest child2 = new TreeNode_FoursquareTest();
            child2.value = 3;

            TreeNode_FoursquareTest child3 = new TreeNode_FoursquareTest();
            child3.value = 4;

            TreeNode_FoursquareTest child4 = new TreeNode_FoursquareTest();
            child4.value = 10;

            child1.children.Add(child3);
            root.children.Add(child2);
            root.children.Add(child1);
            child1.children.Add(child4);

            //        root
            //   child1 child2
            // child3
            var runningTotal = 0;
            Algorithm algoMult = new Multiply();
            Algorithm algoAdd = new Addition();

            GetSumOfTree(root, algoMult, ref runningTotal);
            System.Console.WriteLine(runningTotal);

            var runningTotal2 = 0;
            GetSumOfTree(root, algoAdd, ref runningTotal2);
            System.Console.WriteLine(runningTotal2);

        }

        public static int GetSumOfList(List<int> listOfNumbers)
        {
            var sum = 0;
            for (int i = 0; i < listOfNumbers.Count; i++)
                sum += listOfNumbers[i];

            return sum;
        }

        public static void GetSumOfTree_Add(TreeNode_FoursquareTest root, Algorithm algo, ref int runningTotal)
        {
            runningTotal += root.value;

            //Recursive
            foreach (var child in root.children)
                GetSumOfTree(child, algo, ref runningTotal);

            return;
        }
        public static void GetSumOfTree(TreeNode_FoursquareTest root, Algorithm algo, ref int runningTotal)
        {
            algo.PerformOperation(root.value, ref runningTotal);

            //Recursive
            foreach (var child in root.children)
                GetSumOfTree(child, algo, ref runningTotal);

            return;
        }

        //Could have also done it iteratively. I mentioned htis in the interview but didn't do it.
        public static int GetTreeSumIterative(TreeNode_FoursquareTest root)
        {
            if (root == null) return 0; // Edge case: Empty tree

            int sum = 0;
            Queue<TreeNode_FoursquareTest> queue = new Queue<TreeNode_FoursquareTest>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode_FoursquareTest current = queue.Dequeue();
                sum += current.value;

                foreach (var child in current.children)
                {
                    queue.Enqueue(child); // Add children to the queue
                }
            }

            return sum;
        }
    }

    public interface Algorithm
    {
        void PerformOperation(int value, ref int runningTotal);
    }


    public class Multiply : Algorithm
    {
        public void PerformOperation(int value, ref int runningTotal)
        {
            runningTotal = runningTotal * value;
        }
    }


    public class Divide : Algorithm
    {
        public void PerformOperation(int value, ref int runningTotal)
        {
            runningTotal /= value;
        }
    }

    public class Addition : Algorithm
    {
        public void PerformOperation(int value, ref int runningTotal)
        {
            runningTotal += value;
        }
    }

    public class TreeNode_FoursquareTest
    {
        public int value { get; set; }
        public List<TreeNode_FoursquareTest> children = new List<TreeNode_FoursquareTest>();
    }


}