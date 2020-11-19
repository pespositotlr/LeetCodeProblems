using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace LeetCodeProblems.General
{

    class StartupOwnerInvestors
    {

        /*
         * Complete the 'countMeetings' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY firstDay
         *  2. INTEGER_ARRAY lastDay
         *
         *  A start-up owner is looking to meet new investors to get some funds for his company. 
         *  each investor has a tight schedule that the owner has to respect. 
         *  given the schedules of the days investors are available, determine how many meetings the owner can schedule. 
         *  note that the owner can only have one meeting per day.the schedules consists of two integer arrays, firstday and lastday. 
         *  each element in the array firstday represents the first day an investor is available, and each element in lastday represents 
         *  the last day an investor is available, both inclusive.        
         *  
         *  
         *  
         *  
         *  Sample input data:

            f = [1,2,1,2,2,1]
            l = [3,2,1,3,3,4]

            # expected output = 4

            f = [1,2,1,2,2]
            l = [3,2,1,3,3]

            # expected output = 3

            f = [1,2,1,2,2]
            l = [3,2,1,3,3]

            # expected output = 3

            f = [1,10,11]
            l = [11,10,11]

            # expected output = 3

            f = [1,1,2]
            l = [1,2,2]

            # expected output = 2
         */

        public static int countMeetings(List<int> firstDay, List<int> lastDay)
        {

            List<Investor> investors = new List<Investor>();

            for (int i = 0; i < firstDay.Count; i++)
            {
                Investor newInvestor = new Investor(i, firstDay[i], lastDay[i]);
                investors.Add(newInvestor);
            }

            investors = investors.OrderBy(x => x.FirstDay).ThenByDescending(x => x.DaysAvailable).ToList();

            Dictionary<int, int> schedule = new Dictionary<int, int>();

            //Iterate over intervals from the first start date to last start date:

            //Keep track of the set of investors who are still available up to that date
            //among those investors, always choose the investor with the earliest end date to meet(all other options are suboptimal because investors are all else equal)
            //remove the chosen investors from the set; update the set if any investors are no longer available, add new investors who just become available on that date

            foreach (Investor investor in investors)
            {
                int startDay = investor.FirstDay;
                int endDay = investor.LastDay;
                while (startDay <= endDay)
                {
                    if (!schedule.ContainsKey(startDay))
                    {
                        schedule.Add(startDay, investor.Id);
                    }

                    startDay++;
                }

            }

            // int maxMeetings = 0;

            // foreach(KeyValuePair<int, int> entry in schedule)
            // {

            // }      

            return schedule.Count;

        }

    }

    class Investor
    {
        public int Id;
        public int FirstDay;
        public int LastDay;
        public int DaysAvailable;

        public Investor(int id, int firstDay, int lastDay)
        {
            this.Id = id;
            this.FirstDay = firstDay;
            this.LastDay = lastDay;
            this.DaysAvailable = lastDay - firstDay;
        }
    }

    class StartupOwnerInvestors2
    {
        public static void StartupOwnerInvestors2Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int firstDayCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> firstDay = new List<int>();

            for (int i = 0; i < firstDayCount; i++)
            {
                int firstDayItem = Convert.ToInt32(Console.ReadLine().Trim());
                firstDay.Add(firstDayItem);
            }

            int lastDayCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> lastDay = new List<int>();

            for (int i = 0; i < lastDayCount; i++)
            {
                int lastDayItem = Convert.ToInt32(Console.ReadLine().Trim());
                lastDay.Add(lastDayItem);
            }

            int result = StartupOwnerInvestors.countMeetings(firstDay, lastDay);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }

        //https://github.com/hgoel7/Meetup-Schedule
        public static int countMeetings(List<int> firstDay, List<int> lastDay)
        {
            int length = 0;

            length = firstDay.Count();

            Dictionary<int, int> dictData = new Dictionary<int, int>();

            for (int i = 0; i < length; i++)
            {
                int currFirstDay = firstDay.ElementAt(i);
                int currLastDay = lastDay.ElementAt(i);
                bool saved = false;
                while (!saved)
                {
                    if (!dictData.ContainsKey(currFirstDay))
                    {
                        dictData.Add(currFirstDay, currLastDay);
                        saved = true;
                    }
                    else if (currFirstDay < currLastDay)
                    {
                        currFirstDay++;
                        continue;
                    }
                    else
                    {
                        int lDay = dictData[currFirstDay];
                        if (lDay == currFirstDay)
                        {
                            saved = true;
                        }
                        else
                        {
                            dictData[currFirstDay] = currLastDay;
                            currLastDay = lDay;
                            continue;
                        }
                    }
                }
            }
            return dictData.Count;
        }
    }

}
