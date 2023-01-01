using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    class SortedSetExample
    {
        //From here https://stackoverflow.com/a/28109255
        public static void Create()
        {
            // Created sorted set of strings.
            var set = new SortedSet<string>();

            // Add three elements.
            set.Add("net");
            set.Add("net");  // Duplicate elements are ignored.
            set.Add("dot");
            set.Add("rehan");

            // Remove an element.
            set.Remove("rehan");

            // Print elements in set.
            foreach (var value in set)
            {
                Console.WriteLine(value);
            }

            // Output is in alphabetical order:
            // dot
            // net

        }

    }
}
