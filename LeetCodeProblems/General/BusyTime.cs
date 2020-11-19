using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems
{
    /*
Problem Description
Summary: Given list of events of a given day in a calendar, write an algorithm to return a list of busy view time slots. Busy view is created by the consolidating adjacent and overlapping event time slots without showing details of individual events.

Details: Each event in calendar has a start time, end time & some title. Events can start at any minute (granularity at the minute only, no seconds).

Sample inputs - Expected outputs
Input: list of following events

    (100,300, "Some Event")  // 1:00 am to 3:00 am
    (115,145, "Some Event")
    (145,215, "Some Event")
    (200,400, "Some Event")
    (215,230, "Some Event")
    (215,415, "Some Event")
    (600,700, "Some Event")
    (500,600, "Some Event")
Output: Based on above events, my busy view should show like this:

    (100,415) // Busy from 1am to 4:15 am
    (500,700) // Busy from 5am to 7:00 am

*/
    class BusyTimeSolution
    {

        private List<Event> events = new List<Event>();
        private List<BusyTime> busyTimes = new List<BusyTime>();
        private bool[] busyTimesArray = new bool[2400];

        class Event
        {
            public int startTime;
            public int endTime;
            public string eventName;
        }

        class BusyTime
        {
            public int startTime;
            public int endTime;

            public bool IsIntersecting(BusyTime otherEvent)
            {

                if (startTime >= otherEvent.startTime || endTime <= otherEvent.endTime)
                {
                    return true;
                }

                return false;
            }
            public void Combine(BusyTime otherEvent)
            {
                startTime = Math.Min(startTime, otherEvent.startTime);
                endTime = Math.Max(endTime, otherEvent.endTime);
            }
        }

        public void AddEvent(int startTime, int endTime, string eventName)
        {
            Event newEvent = new Event();
            newEvent.startTime = startTime;
            newEvent.endTime = endTime;
            newEvent.eventName = eventName;
            events.Add(newEvent);

            //Check if this intersects with an existing busyTime
            //With this method you may have to delete existing "busyTime" objects if a new busyTime supercedes old ones, 
            //you need to check if a new time intersects an old one and "extend" it, etc.
            //If you have two events that didn't intersect, and now a new event makes them intersect, you need to "delete" one of the events.
            //So like 1--2, 3--4. Then a new event 1--5, means you need to "delete" one.
            //You could "extend" both to be 1--5 and 1--5 and then delete "non-unique" ones at the end.
            //You could run into an issue with a scenario like 1--2, 3--4, then adding 1--330. 
            if (busyTimes.Any(x => newEvent.startTime < x.startTime && newEvent.endTime < x.endTime))
            {


            }

            //Array method
            for (int i = startTime; i < endTime; i++)
            {
                busyTimesArray[i] = true;
            }

        }

        public void GetBusyTimes()
        {

            var startingTime = -1;
            var endingTime = -1;

            for (int i = 0; i < busyTimesArray.Length; i++)
            {

                if (busyTimesArray[i] && startingTime == -1)
                {
                    startingTime = i;
                }

                if (!busyTimesArray[i] && startingTime != -1)
                {
                    endingTime = i;
                }

                if (endingTime != -1)
                {
                    Console.WriteLine("Busy from " + startingTime + " to " + endingTime);
                    startingTime = -1;
                    endingTime = -1;
                }

            }


        }


        public class Interval
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
        public static IEnumerable<Interval> MergeAndList(IEnumerable<Interval> intervals)
        {

            var ret = new List<Interval>(intervals);
            int lastCount = 0;
            do
            {
                lastCount = ret.Count;
                ret = ret.Aggregate(new List<Interval>(), (agg, cur) =>
                {
                    for (int i = 0; i < agg.Count; i++)
                    {
                        var a = agg[i];
                        if (a.End.AddMinutes(1) >= cur.Start)
                        {
                            agg[i] = new Interval { Start = a.Start, End = cur.End };
                            return agg;
                        }
                        else
                        {
                            agg[i] = new Interval { Start = a.Start, End = a.End };
                        }
                    }
                    agg.Add(cur);
                    return agg;
                });
            } while (ret.Count != lastCount);
            return ret;
        }
    }

    class Item
    {
        public DateTime Start;
        public DateTime End;
    }

    static class EnumerableExtensions
    {
        public static IEnumerable<Item> Combine(this IEnumerable<Item> items)
        {
            using (var enumerator = items.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    yield break;

                var previous = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    var next = enumerator.Current;

                    if (TryCombine(previous, next, out var combined))
                    {
                        previous = combined;
                        continue;
                    }

                    yield return previous;
                    previous = next;
                }
                yield return previous;
            }
        }
        private static bool TryCombine(Item item1, Item item2, out Item combinedItem)
        {
            if (item2.Start - item1.End > TimeSpan.FromHours(1))
            {
                combinedItem = default;
                return false;
            }

            combinedItem = new Item { Start = item1.Start, End = item2.End };
            return true;
        }
    }

}
