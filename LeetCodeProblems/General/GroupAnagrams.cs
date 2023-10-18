using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class GroupAnagrams
    {
        public static bool TestGroupAnagrams()
        {
            string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = GroupAnagramsClass.GroupAnagrams(strs);
            List<IList<string>> expected = new List<IList<string>>();
            expected.Add(new List<string> { "eat", "tea", "ate" });
            expected.Add(new List<string> { "tan", "nat" });
            expected.Add(new List<string> { "bat" });
            for (int i = 0; i < result.Count; i++)
            {
                return expected[i].ToList().SequenceEqual(result[i].ToList());
            }

            return false;
        }

        private class GroupAnagramsClass
        {
            public static IList<IList<string>> GroupAnagrams(string[] strs)
            {
                Dictionary<char[], List<string>> dict = new Dictionary<char[], List<string>>(new CharComparer());
                foreach (var str in strs)
                {
                    var key = str.ToCharArray(); //Get a character array of each input string
                    Array.Sort(key); //Sort them alphabetically so eat/tea both become aet
                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = new List<string>(); //Add an empty list if it doesn't contain that key
                    }
                    dict[key].Add(str); //Add that string to the internal list in the dictionary for that sorted char array
                }

                List<IList<string>> res = new List<IList<string>>(dict.Values.ToList());
                return res;
            }
        }

        //Alternative is to create a 26-index inner-array

        public class CharComparer : IEqualityComparer<char[]>
        {
            public bool Equals(char[] x, char[] y)
            {
                if (x == null || y == null)
                {
                    return false;
                }

                if (x.Length != y.Length)
                {
                    return false;
                }

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] != y[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            public int GetHashCode(char[] obj)
            {
                return 0;
            }
        }
    }
}
