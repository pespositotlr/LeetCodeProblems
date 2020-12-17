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
    }
}
