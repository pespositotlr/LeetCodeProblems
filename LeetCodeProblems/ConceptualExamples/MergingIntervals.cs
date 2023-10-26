using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.ConceptualExamples
{
    // https://leetcode.com/problems/merge-intervals/
    // Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, 
    // and return an array of the non-overlapping intervals that cover all the intervals in the input.
    // Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
    // Output: [[1,6],[8,10],[15,18]]
    // Explanation: Since intervals[1, 3] and[2, 6] overlaps, merge them into[1, 6].
    class MergingIntervals
    {
        // An interval has start time and end time 
        public struct Interval
        {
            public int start { get; set; }
            public int end { get; set; }
        };

        // Compares two intervals according to their staring time. 
        // This is needed for sorting the intervals using library 
        // function std::sort(). See http://goo.gl/iGspV 
        public bool compareInterval(Interval i1, Interval i2)
        {
            return (i1.start < i2.start);
        }

        // The main function that takes a set of intervals, merges 
        // overlapping intervals and prints the result 
        public static void mergeIntervals(Interval[] arr)
        {
            int arrayLength = arr.Length;
            // Test if the given set has at least one interval 
            if (arrayLength <= 0)
                return;

            // Create an empty stack of intervals 
            Stack<Interval> intervalStack = new Stack<Interval>();

            // sort the intervals in increasing order of start time 
            var sortedIntervals = arr.OrderBy(x => x.start).ToList();

            // push the first interval to stack 
            intervalStack.Push(sortedIntervals[0]);

            // Start from the next interval and merge if necessary 
            for (int i = 1; i < arrayLength; i++)
            {
                // get interval from stack top 
                Interval top = intervalStack.Peek();

                // if current interval is not overlapping with stack top, push it to the stack 
                if (top.end < sortedIntervals[i].start)
                    intervalStack.Push(sortedIntervals[i]);

                // Otherwise update the ending time of top if ending of current interval is more 
                else if (top.end < sortedIntervals[i].end)
                {
                    top.end = sortedIntervals[i].end;
                    intervalStack.Pop();
                    intervalStack.Push(top);
                }
            }

            // Print contents of stack 
            Console.WriteLine("The Merged Intervals are: ");
            while (intervalStack.Count > 0)
            {
                Interval t = intervalStack.Peek();
                Console.WriteLine("[" + t.start + "," + t.end + "] ");
                intervalStack.Pop();
            }
            return;
        }

        // Driver program 
        public static int MergingIntervals_Main()
        {
            Interval[] arr = { new Interval { start = 6, end = 8 },
                new Interval { start = 1, end = 2 },
                new Interval { start = 2, end = 3 },
                new Interval { start = 4, end = 7 } 
            };

            mergeIntervals(arr);
            return 0;
        }

        public static int[][] Merge(int[][] intervals)
        {
            int arrayLength = intervals.Length;
            // Test if the given set has at least one interval 
            if (arrayLength <= 0)
                return null;

            var sortedIntervals = intervals.OrderBy(x => x[0]).ToList();
            Stack<int[]> intervalStack = new Stack<int[]>();
            intervalStack.Push(sortedIntervals[0]);

            // Start from the next interval and merge if necessary 
            for (int i = 1; i < arrayLength; i++)
            {
                // get interval from stack top 
                int[] top = intervalStack.Peek();

                // if current interval is not overlapping with stack top, push it to the stack 
                if (top[1] < sortedIntervals[i][0])
                    intervalStack.Push(sortedIntervals[i]);

                // Otherwise update the ending time of top if ending of current interval is more 
                else if (top[1] < sortedIntervals[i][1])
                {
                    top[1] = sortedIntervals[i][1];
                    intervalStack.Pop();
                    intervalStack.Push(top);
                }
            }

            int[][] result = new int[intervalStack.Count][];
            int j = 0;
            while (intervalStack.Count > 0)
            {
                int[] t = intervalStack.Pop();
                result[j] = new int[] { t[0], t[1] };
                j++;
            }

            return result;
        }

        public static int[][] Merge2(int[][] intervals)
        {
            var arrayLength = intervals.Length;
            if (arrayLength <= 0)
                return null;

            var sortedIntervals = intervals.OrderBy(x => x[0]).ToList();
            int[][] result = new int[][] { sortedIntervals[0].ToArray() }; //Start with the 0th item in the result set

            for (int i = 1; i < arrayLength; i++)
            {
                int start = sortedIntervals[i][0];
                int end = sortedIntervals[i][1];
                int lastEnd = result[result.Length - 1][1];

                if(start <= lastEnd) //Values are overlapping so merge
                    result[result.Length - 1][1] = Math.Max(lastEnd, end);
                //else
                    //result.Concat(new int[] { start, end } ); //If not, leave it in the result as-is
            }
            //This way doesn't work in C# because you can't concat to an array so you'd need ot turn it into a list and back
            return result;
        }

    }
}
