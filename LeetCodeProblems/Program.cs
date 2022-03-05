using DynamicObjectParser.Tests;
using LeetCodeProblems.General;
using LeetCodeProblems.Graphing;
using LeetCodeProblems.Trees;
using LeetCodeProblems.ConceptualExamples;
using System;
using System.Collections.Generic;
using static LeetCodeProblems.BreadthFirtstSearch;
using static LeetCodeProblems.DepthFirstSearch;
using static LeetCodeProblems.General.CodeExamples;

namespace LeetCodeProblems
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //int[] inputArray = { 1, 2, 3 };
            //var result = FindAllSubsetsOfNumbers1.Subsets(inputArray);
            //FindAllSubsetsOfNumbers1.Print(result);

            //var result2 = FindAllSubsetsOfNumbers2.Subsets(inputArray);

            //LinkedList list = new LinkedList();
            //list.AddNode(new LinkedList.Node(85));
            //list.AddNode(new LinkedList.Node(15));
            //list.AddNode(new LinkedList.Node(4));
            //list.AddNode(new LinkedList.Node(20));

            //// List before reversal 
            //Console.WriteLine("Given linked list:");
            //list.PrintList();

            //// Reverse the list 
            //list.ReverseList();

            //// List after reversal 
            //Console.WriteLine("Reversed linked list:");
            //list.PrintList();

            //   15
            //  10 20
            // 8 12 16 25
            //BinaryTree.PrintCorners();

            //string board = "WRRBBW";
            //string hand = "RB";
            //int output = 0;
            //Console.WriteLine("board = " + board + ", hand = " + hand);
            //output = ZumaGame.FindMinStep(board, hand);
            //Console.WriteLine("Result: " + output);

            //board = "WWRRBBWW";
            //hand = "WRBRW";
            //Console.WriteLine("board = " + board + ", hand = " + hand);
            //output = ZumaGame.FindMinStep(board, hand);
            //Console.WriteLine("Result: " + output);

            //board = "G";
            //hand = "GGGGG";
            //Console.WriteLine("board = " + board + ", hand = " + hand);
            //output = ZumaGame.FindMinStep(board, hand);
            //Console.WriteLine("Result: " + output);

            //board = "RBYYBBRRB";
            //hand = "YRBGB";
            //Console.WriteLine("board = " + board + ", hand = " + hand);
            //output = ZumaGame.FindMinStep(board, hand);
            //Console.WriteLine("Result: " + output);

            //board = "RRWWRRBBRR";
            //hand = "WB";
            //Console.WriteLine("board = " + board + ", hand = " + hand);
            //output = ZumaGame.FindMinStep(board, hand);
            //Console.WriteLine("Result: " + output);


            //string input = "[288 votes so far. Categories: {\"Everything Else\" (47 votes), C# (61 votes), C++ (39 votes), Database (44 votes), Mobile (45 votes), Web Dev (52 votes)}]";
            //Console.WriteLine("Input: " + input);
            //Console.WriteLine(CheckBalancedBrackets.IsBalanced(input));
            //input = "[{}()<sometext>[[{{}}]]]";
            //Console.WriteLine("Input: " + input);
            //Console.WriteLine(CheckBalancedBrackets.IsBalanced(input));
            //input = "<Root><First>Test</First<</Root>";
            //Console.WriteLine("Input: " + input);
            //Console.WriteLine(CheckBalancedBrackets.IsBalanced(input));


            //int[][] costs = { new int[] { 10, 20 }, new int[] { 30, 200 }, new int[] { 400, 50 }, new int[] { 30, 20 } };
            //Console.WriteLine("Input: costs = [[10,20],[30,200],[400,50],[30,20]]");
            //Console.WriteLine(TwoCityScheduling.TwoCitySchedCost(costs));

            //int[][] costs2 = { new int[] { 259, 770 }, new int[] { 448, 54 }, new int[] { 926, 667 }, new int[] { 184, 139 }, new int[] { 840, 118 }, new int[] { 577, 469 } };
            //Console.WriteLine("Input: costs = [[259,770],[448,54],[926,667],[184,139],[840,118],[577,469]]");
            //Console.WriteLine(TwoCityScheduling.TwoCitySchedCost(costs2));

            //int[][] costs3 = { new int[] { 515, 563 }, new int[] { 451, 713 }, new int[] { 537, 709 }, new int[] { 343, 819 }, new int[] { 855, 779 }, new int[] { 457, 60 }, new int[] { 650, 359 }, new int[] { 631, 42 } };
            //Console.WriteLine("Input: costs = [[515,563],[451,713],[537,709],[343,819],[855,779],[457,60],[650,359],[631,42]]");
            //Console.WriteLine(TwoCityScheduling.TwoCitySchedCost(costs3));


            //LRUCache cache = new LRUCache(4);

            //int[][] keyValuePair = new int[5][]{
            //     new int[2]{1,1},
            //     new int[2]{2,1},
            //     new int[2]{3,1},
            //     new int[2]{4,1},
            //     new int[2]{5,1}
            //};

            //for (int i = 0; i < 4; i++)
            //    cache.set(keyValuePair[i][0], keyValuePair[i][1]);

            //int value = cache.get(1);  // key 1 is in LRU, so the value is 1; and also 1 is visited, so remove key 1, and add key 1 to to the top. 

            //cache.set(keyValuePair[4][0], keyValuePair[4][1]); // WOuld, remove key 1, but since key 1 as moved to top; key 2 is now oldest an is the one removed. 

            //int value2 = cache.get(1);  // return 1
            //int value3 = cache.get(2);  // return -1
            //int value4 = cache.get(3);

            //ConvertSortedArrayToBinarySearchTree convertTree = new ConvertSortedArrayToBinarySearchTree();

            //var tree = convertTree.SortedArrayToBST(new int[] { -10, 0, 10, 20, 30, 40, 50, 60 });
            //convertTree.DisplayTree(tree);


            //UndergroundSystem undergroundSystem = new UndergroundSystem(); 
            //undergroundSystem.CheckIn(45, "Leyton", 3);
            //undergroundSystem.CheckIn(32, "Paradise", 8);
            //undergroundSystem.CheckIn(27, "Leyton", 10);
            //undergroundSystem.CheckOut(45, "Waterloo", 15);
            //undergroundSystem.CheckOut(27, "Waterloo", 20);
            //undergroundSystem.CheckOut(32, "Cambridge", 22);
            //Console.WriteLine(undergroundSystem.GetAverageTime("Paradise", "Cambridge"));       // return 14.00000. There was only one travel from "Paradise" (at time 8) to "Cambridge" (at time 22)
            //Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Waterloo"));          // return 11.00000. There were two travels from "Leyton" to "Waterloo", a customer with id=45 from time=3 to time=15 and a customer with id=27 from time=10 to time=20. So the average time is ( (15-3) + (20-10) ) / 2 = 11.00000
            //undergroundSystem.CheckIn(10, "Leyton", 24);
            //Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Waterloo"));          // return 11.00000
            //undergroundSystem.CheckOut(10, "Waterloo", 38);
            //Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Waterloo"));          // return 12.00000


            //UndergroundSystem undergroundSystem2 = new UndergroundSystem();
            //undergroundSystem2.CheckIn(10, "Leyton", 3);
            //undergroundSystem2.CheckOut(10, "Paradise", 8);
            //Console.WriteLine(undergroundSystem2.GetAverageTime("Leyton", "Paradise")); // return 5.00000
            //undergroundSystem2.CheckIn(5, "Leyton", 10);
            //undergroundSystem2.CheckOut(5, "Paradise", 16);
            //Console.WriteLine(undergroundSystem2.GetAverageTime("Leyton", "Paradise")); // return 5.50000
            //undergroundSystem2.CheckIn(2, "Leyton", 21);
            //undergroundSystem2.CheckOut(2, "Paradise", 30);
            //Console.WriteLine(undergroundSystem2.GetAverageTime("Leyton", "Paradise")); // return 6.66667


            //NodeWithChildren node1 = new NodeWithChildren(1);
            //NodeWithChildren node2 = new NodeWithChildren(2);
            //NodeWithChildren node3 = new NodeWithChildren(3);
            //NodeWithChildren node4 = new NodeWithChildren(4);
            //NodeWithChildren node5 = new NodeWithChildren(5);
            //NodeWithChildren node6 = new NodeWithChildren(6);
            //NodeWithChildren node7 = new NodeWithChildren(7);
            //NodeWithChildren node8 = new NodeWithChildren(8);
            //NodeWithChildren node9 = new NodeWithChildren(9);
            //NodeWithChildren node10 = new NodeWithChildren(10);
            //NodeWithChildren node11 = new NodeWithChildren(11);
            //NodeWithChildren node12 = new NodeWithChildren(12);

            //node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;
            //node5.next = node6;
            //node6.next = null;

            //node1.prev = null;
            //node2.prev = node1;
            //node3.prev = node2;
            //node4.prev = node3;
            //node5.prev = node4;
            //node6.prev = node5;

            //node3.child = node7;
            //node7.next = node8;
            //node8.next = node9;
            //node9.next = node10;
            //node10.next = null;

            //node7.prev = null;
            //node8.prev = node7;
            //node9.prev = node8;
            //node10.prev = node9;

            //node8.child = node11;
            //node11.next = node12;
            //node12.next = null;

            //node11.prev = null;
            //node12.prev = node11;

            //var resultHead = FlattenMultilevelDoublyLinkedList.Flatten(node1);
            //FlattenMultilevelDoublyLinkedList.PrintFlatList(resultHead);

            //int[] arr = { 9, 4, 9, 6, 7, 4 };
            //int n = arr.Length;
            //Console.Write(NonRepeatingElement.FirstNonRepeating(arr, n));

            //int[] arr = { 0,1,0,2,1,0,1,3,2,1,2,1 };
            //TrappingRainWater trw = new TrappingRainWater();
            //Console.WriteLine(trw.Trap(arr));
            //Console.WriteLine(trw.Trap2(arr));


            //BusyTimeSolution sol = new BusyTimeSolution();

            //sol.AddEvent(100, 300, "Some Event");
            //sol.AddEvent(115, 145, "Some Event");
            //sol.AddEvent(145, 215, "Some Event");
            //sol.AddEvent(200, 400, "Some Event");
            //sol.AddEvent(215, 230, "Some Event");
            //sol.AddEvent(215, 415, "Some Event");
            //sol.AddEvent(600, 700, "Some Event");
            //sol.AddEvent(500, 600, "Some Event");
            //sol.AddEvent(500, 600, "Some Event");

            //sol.GetBusyTimes();

            //var items = new List<BusyTimeSolution.Interval>();
            //items.Add(new BusyTimeSolution.Interval { Start = new DateTime(2020, 9, 8, 1, 0, 0), End = new DateTime(2020, 9, 8, 3, 0, 0) });
            //items.Add(new BusyTimeSolution.Interval { Start = new DateTime(2020, 9, 8, 1, 15, 0), End = new DateTime(2020, 9, 8, 1, 45, 0) });
            //items.Add(new BusyTimeSolution.Interval { Start = new DateTime(2020, 9, 8, 2, 0, 0), End = new DateTime(2020, 9, 8, 4, 0, 0) });
            //items.Add(new BusyTimeSolution.Interval { Start = new DateTime(2020, 9, 8, 2, 15, 0), End = new DateTime(2020, 9, 8, 2, 30, 0) });
            //items.Add(new BusyTimeSolution.Interval { Start = new DateTime(2020, 9, 8, 2, 15, 0), End = new DateTime(2020, 9, 8, 4, 30, 0) });
            //items.Add(new BusyTimeSolution.Interval { Start = new DateTime(2020, 9, 8, 6, 0, 0), End = new DateTime(2020, 9, 8, 7, 0, 0) });
            //items.Add(new BusyTimeSolution.Interval { Start = new DateTime(2020, 9, 8, 5, 0, 0), End = new DateTime(2020, 9, 8, 6, 0, 0) });
            //BusyTimeSolution.MergeAndList(items);

            //foreach(var item in items)
            //{
            //    Console.WriteLine(item.Start + " - " + item.End);
            //}

            //Palindrome.IsPalindrome("test");
            //Palindrome.IsPalindrome("racecar");

            //Palindrome.IsPalindrome2("test");
            //Palindrome.IsPalindrome2("racecar");

            //var gapw = new AllPossibleWords();
            //gapw.GetAllPossibleWords(new char[3] { '2', '3', '2' });

            //Permutations.GetPermutations("abc");

            //var inputString = "UserName: admin;\nPassword:\"\"super % ^&*333password;\nDNSName: SomeName;\n\nTimeToLive: 4;\nClusterSize: 2;\nPortNumber: 2222;\n\nIsEnabled: true;\nEnsureTransaction: false;\nPersistentStorage: false;";

            //Parser parser = new Parser();
            //var output = parser.Parse(inputString);

            //if (output.UserName == "admin")
            //    Console.WriteLine("Passed");

            //var output = CalculateLossRate.Calculate(10, 2);

            //if (output == 5)
            //    Console.WriteLine("True");

            //var output2 = DiceCalculator.Calculate("2*1d6+2d3");

            //if (output2 == 11)
            //    Console.WriteLine("True");

            //Console.WriteLine(MaximumPossibleValue.Solution(268));
            //Console.WriteLine(MaximumPossibleValue.Solution(670));
            //Console.WriteLine(MaximumPossibleValue.Solution(0));
            //Console.WriteLine(MaximumPossibleValue.Solution(-999));
            //Console.WriteLine(MaximumPossibleValue.Solution(-111));


            //Console.WriteLine(DataValidationClass.DataValidation(Console.ReadLine()));

            //int[] a = { 1, 2, 4, 5, 6 };
            //int miss = GetMissingNumber.GetMissingNumber1(a, 5);
            //Console.Write(miss);


            //BreadthFirstAlgorithm b = new BreadthFirstAlgorithm();
            //Employee root = b.BuildEmployeeGraph();
            //Console.WriteLine("Traverse Graph\n------");
            //b.Traverse(root);

            //Console.WriteLine("\nSearch in Graph\n------");
            //Employee e = b.Search(root, "Eva");
            //Console.WriteLine(e == null ? "Employee not found" : e.name);
            //e = b.Search(root, "Brian");
            //Console.WriteLine(e == null ? "Employee not found" : e.name);
            //e = b.Search(root, "Soni");
            //Console.WriteLine(e == null ? "Employee not found" : e.name);


            //DepthFirstAlgorithm dfa = new DepthFirstAlgorithm();
            //Employee rootDfa = dfa.BuildEmployeeGraph();
            //Console.WriteLine("Traverse Graph\n------");
            //dfa.Traverse(rootDfa);

            //Console.WriteLine("\nSearch in Graph\n------");
            //Employee empDfa = dfa.Search(rootDfa, "Eva");
            //Console.WriteLine(empDfa == null ? "Employee not found" : empDfa.name);
            //empDfa = dfa.Search(rootDfa, "Brian");
            //Console.WriteLine(empDfa == null ? "Employee not found" : empDfa.name);
            //empDfa = dfa.Search(rootDfa, "Soni");
            //Console.WriteLine(empDfa == null ? "Employee not found" : empDfa.name);


            //int[] value = { 10, 50, 70 };
            //int[] weight = { 10, 20, 30 };
            //int capacity = 40;
            //int itemsCount = 3;

            //int result = KnapsackAlgorithm.KnapSack(capacity, weight, value, itemsCount);
            //Console.WriteLine(result);

            //var wm = new WordMachine();
            //var result = wm.solution("1 POP POP POP");
            //Console.WriteLine(result);

            //var dfsEx = new DepthFirstSearchStackExample();
            //DepthFirstSearchStackExample.MainDFS(new string[0]);

            //var output = DigitsManipulation.digitsManipulations(1010);

            //var output = BinaryPatternMatching.binaryPatternMatching("010", "amazing");
            //var output2 = BinaryPatternMatching.binaryPatternMatching("00", "aaaaaaaaaa");

            //var result = SmallestNumber.solution(new int[] { -100, -1, 2, 3 });
            //var result2 = SmallestNumber.solution(new int[] { 100, -1, 2, 300 });
            //var result3 = SmallestNumber.solution(new int[] { 100, -1, 2, -300 });

            //var addressSelect = new AddressSelect();
            //addressSelect.Solution();

            //GetAllParentheses.MainGetAllParentheses(3);

            //StartupOwnerInvestors2.StartupOwnerInvestors2Main(new string[0]);

            //BinarySearchTree.BinarySearchTree_Main();

            //DiceRollSimulatorMemoization.DiceRollSimulatorMemoization_Main();

            //FibbonacciChecks.FibbonacciChecks_Main();

            //MergingIntervals.MergingIntervals_Main();

            //await AsyncBreakfast.AsyncBreakfast_TasksWithAwait2_Main();

            //ConvertString.GetConvertedString("(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)");

            //baseClass obj = new derivedClass();
            //obj.print1();
            //obj.print2();
            //obj.print3();

            //Console.WriteLine((int)days.sunday);
            //Console.WriteLine((int)days.monday);
            //Console.WriteLine((int)days.tuesday);

            //EventExample.EventExample_Main();

            //int[] array = new int[] { 1, 3, 5, 9, 100, 101, 102 };
            //Console.WriteLine(CodeExamples.BinarySearchIterative(array, 102));
            //Console.WriteLine(CodeExamples.BinarySearchIterative(array, 2));
            //Console.WriteLine(CodeExamples.BinarySearchRecursive(array, 102));
            //Console.WriteLine(CodeExamples.BinarySearchRecursive(array, 2));

            //int[] array = new int[] { 1 };
            //Console.WriteLine(CodeExamples.BinarySearchIterative(array, 1));

            //CodeExamples.ArgumentOutOfRangeExceptionExample(array, -1);
            //CodeExamples.ArgumentOutOfRangeExceptionExample(array, 99);

            //CodeExamples.CustomLogExceptionExample();
            //CodeExamples.ExampleInputProgram();

            //Elephant2 el2 = new Elephant2();
            //Console.WriteLine(el2.Color());
            //Console.WriteLine(el2.TrunkLength());

            //Animal2 al2 = Animal2.MakeAnimal("Elephant");

            //Elephant2 el2 = al2 as Elephant2;

            //if (el2 != null)
            //    el2.TrunkLength();

            //Elephant2 el2a = (Elephant2)al2;
            //el2a.TrunkLength();

            CateringExercise cateringExercise = new CateringExercise();
            await cateringExercise.CateringExercise_Main();

        }

    }
}
