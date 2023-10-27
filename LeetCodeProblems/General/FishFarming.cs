using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    internal class FishFarming
    {

        /*

        Each fish: 7 days -> new baby fish
        Baby --2 days--> Adult Fish

        Given initial fish, how many fish we will have after N days? 

        0-based index: 0-6  

        Initial state: 3,4,3,1,2
        After  1 day:  2,3,2,0,1
        After  2 days: 1,2,1,6,0,8
        After  3 days: 0,1,0,5,6,7,8
        After  4 days: 6,0,6,4,5,6,7,8,8 //9
        After  5 days: 5,6,5,3,4,5,6,7,7,8
        After  6 days: 4,5,4,2,3,4,5,6,6,7
        After  7 days: 3,4,3,1,2,3,4,5,5,6
        After  8 days: 2,3,2,0,1,2,3,4,4,5
        After  9 days: 1,2,1,6,0,1,2,3,3,4,8
        After 10 days: 0,1,0,5,6,0,1,2,2,3,7,8
        After 11 days: 6,0,6,4,5,6,0,1,1,2,6,7,8,8,8
        After 12 days: 5,6,5,3,4,5,6,0,0,1,5,6,7,7,7,8,8
        After 13 days: 4,5,4,2,3,4,5,6,6,0,4,5,6,6,6,7,7,8,8
        After 14 days: 3,4,3,1,2,3,4,5,5,6,3,4,5,5,5,6,6,7,7,8
        After 15 days: 2,3,2,0,1,2,3,4,4,5,2,3,4,4,4,5,5,6,6,7
        After 16 days: 1,2,1,6,0,1,2,3,3,4,1,2,3,3,3,4,4,5,5,6,8
        After 17 days: 0,1,0,5,6,0,1,2,2,3,0,1,2,2,2,3,3,4,4,5,7,8
        After 18 days: 6,0,6,4,5,6,0,1,1,2,6,0,1,1,1,2,2,3,3,4,6,7,8,8,8,8    //26


        A better solution might to be have a dictionary of days 1-6 and how many fishes are in that bucket
        Then double that amount for that key every time modulous 6 = 0;
        And hold the 8-7 days in a separate structure until they get down to 6, then add them to the dictionary.     
        Maybe make a second list called babyFishes and when created they start at 2. When that goes down to 0 then remove them from the baby fish list and add them to the adult buckets for whatever current day modulus 6 is.
        The final result would be the count of all the buckets plus the baby fish.
        */
        static int sumFishes(List<int> fishes, int days)
        {

            if (days == 0)
                return fishes.Count();

            for (int i = 1; i <= days; i++)
            {
                //Start of day
                int currentFishCount = fishes.Count;

                //Check each fish 
                for (int j = 0; j < currentFishCount; j++)
                {
                    if (fishes[j] > 0)
                        fishes[j]--;
                    else
                    {
                        if (fishes[j] == 0)
                            fishes.Add(8);

                        fishes[j] = 6;
                    }
                }
            }

            return fishes.Count();
        }

        //There's an issue in this somewhere but this is close to the correct solutin
        static int sumFishes2(List<int> fishes, int days)
        {

            if (days == 0)
                return fishes.Count();

            int daysToAdulthood = 2;
            int daysForAdultToGiveBirth = 7;
            Dictionary<int,int> fishDictionary = new Dictionary<int,int>();
            List<int> babyFish = new List<int>();

            //Add the original list of fish to the dictionary, one for each day
            foreach(int fish in fishes)
            {
                if (fishDictionary.ContainsKey(7 - fish))
                    fishDictionary[7 - fish]++;
                else
                    fishDictionary.Add(7 - fish, 1); //Use 7- to get the positive days rather than the countdowns
            }


            for (int i = 1; i <= days; i++)
            {
                for (int k = 0; k < babyFish.Count; k++)
                    babyFish[k]++; //The babies age up one day

                //Generation born on this day doubles
                if (fishDictionary.ContainsKey((i % daysForAdultToGiveBirth)))
                {
                    int fishToBeBorn = fishDictionary[i % daysForAdultToGiveBirth];

                    //Add the baby fish and give them a value of 2 before they reach adulthood
                    for (int j = 0; j < fishToBeBorn; j++)
                        babyFish.Add(0);
                }

                //Grow baby fish into adults
                for (int f = 0; f < babyFish.Count; f++)
                {
                    if (babyFish[f] >= daysToAdulthood)
                    {
                        //No longer a baby. All grown up.
                        babyFish.RemoveAt(f);
                        f--; //Move the index back because one was removed.

                        //Add to adult bucket for that day
                        if (fishDictionary.ContainsKey(i % daysForAdultToGiveBirth))
                            fishDictionary[i % daysForAdultToGiveBirth]++; 
                        else
                            fishDictionary.Add(i % daysForAdultToGiveBirth, 1);
                    }
                }

            }

            //Calculate the total fish we have
            int totalCount = babyFish.Count;

            for (int j = 0; j < daysForAdultToGiveBirth; j++)
            {
                if(fishDictionary.ContainsKey(j))
                    totalCount += fishDictionary[j];
            }

            return totalCount;
        }

        public static void FishMain(String[] args)
        {
            List<int> val1 = new List<int>() { 3, 4, 3, 1, 2 };
            int val2 = 18;
            int sum = sumFishes2(val1, val2);

            Console.WriteLine(sum);
        }
    }

}
