using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://dev.to/wirefuture/exploring-the-internals-of-dictionary-in-c-1i5p
    /// A dictionary in C# uses an array of buckets to store entries. 
    /// Each bucket can hold multiple entries in case of collisions. 
    /// Let's explore how keys are converted to indices, how collisions are handled, and how entries are stored in buckets.
    /// </summary>
    public class DictionaryInternals
    {

    }
    public class HashingExample
    {
        public static void MainHashing(string[] args)
        {
            string key = "exampleKey";
            int hashCode = key.GetHashCode();
            Console.WriteLine($"Hash Code for '{key}': {hashCode}");
        }
    }
    public class BucketExample
    {
        private const int BucketCount = 16;

        public static void MainBucketExample(string[] args)
        {
            string key = "exampleKey";
            int hashCode = key.GetHashCode();
            int bucketIndex = hashCode % BucketCount;
            Console.WriteLine($"Bucket Index for '{key}': {bucketIndex}");
        }
    }

    /// <summary>
    /// Collisions occur when multiple keys produce the same bucket index. 
    /// C# dictionaries handle collisions using linked lists within each bucket. 
    /// When a collision occurs, the new entry is added to the linked list at the corresponding bucket index.
    /// 
    /// In this example, when a collision occurs (i.e., key1 is added twice), both entries are stored in the same bucket's linked list.
    /// </summary>
    public class CollisionExample
    {
        private const int BucketCount = 16;
        private static List<KeyValuePair<string, int>>[] buckets;

        public static void CollusionExampleMain(string[] args)
        {
            buckets = new List<KeyValuePair<string, int>>[BucketCount];
            AddToDictionary("key1", 1);
            AddToDictionary("key2", 2);
            AddToDictionary("key1", 3); // Collision

            PrintBuckets();
        }

        private static void AddToDictionary(string key, int value)
        {
            int hashCode = key.GetHashCode();
            int bucketIndex = hashCode % BucketCount;

            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new List<KeyValuePair<string, int>>();
            }

            buckets[bucketIndex].Add(new KeyValuePair<string, int>(key, value));
        }

        private static void PrintBuckets()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.WriteLine($"Bucket {i}:");
                if (buckets[i] != null)
                {
                    foreach (var kvp in buckets[i])
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Managing buckets effectively is crucial for the performance of a dictionary. The number of buckets can dynamically grow as the dictionary size increases to maintain efficient lookups.
    /// Resizing Buckets
    /// When the number of entries exceeds a certain threshold, the dictionary resizes its buckets array to reduce the load factor.
    /// This involves rehashing all existing keys and redistributing them into the new buckets array.
    /// </summary>
    public class ResizingExample
    {
        private const int InitialBucketCount = 4;
        private List<KeyValuePair<string, int>>[] buckets;
        private int count;
        private int bucketCount;
        public ResizingExample()
        {
            bucketCount = InitialBucketCount;
            buckets = new List<KeyValuePair<string, int>>[bucketCount];
            count = 0;
        }

        public void Add(string key, int value)
        {
            if (count >= bucketCount * 0.75)
            {
                ResizeBuckets();
            }

            int hashCode = key.GetHashCode();
            int bucketIndex = hashCode % bucketCount;

            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new List<KeyValuePair<string, int>>();
            }

            buckets[bucketIndex].Add(new KeyValuePair<string, int>(key, value));
            count++;
        }

        private void ResizeBuckets()
        {
            bucketCount *= 2;
            var newBuckets = new List<KeyValuePair<string, int>>[bucketCount];

            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var kvp in bucket)
                    {
                        int newBucketIndex = kvp.Key.GetHashCode() % bucketCount;
                        if (newBuckets[newBucketIndex] == null)
                        {
                            newBuckets[newBucketIndex] = new List<KeyValuePair<string, int>>();
                        }
                        newBuckets[newBucketIndex].Add(kvp);
                    }
                }
            }

            buckets = newBuckets;
        }

        public void PrintBuckets()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.WriteLine($"Bucket {i}:");
                if (buckets[i] != null)
                {
                    foreach (var kvp in buckets[i])
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
        }
    }

}
