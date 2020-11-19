using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    // https://programmingwithmosh.com/net/csharp-collections/
    /*
     * A HashSet represents a set of unique items, just like a mathematical set (e.g. { 1, 2, 3 }). 
     * A set cannot contain duplicates and the order of items is not relevant. So, both { 1, 2, 3 } and { 3, 2, 1 } are equal.
     * Use a HashSet when you need super fast lookups against a unique list of items. For example, you might be processing a list of orders, 
     * and for each order, you need to quickly check the supplier code from a list of valid supplier codes.
     * A HashSet, similar to a Dictionary, is a hash-based collection, so look ups are very fast with O(1). 
     * But unlike a dictionary, it doesn’t store key/value pairs; it only stores values. 
     * So, every objects should be unique and this is determined by the value returned from the GetHashCode method. 
     * So, if you’re going to store custom types in a set, you need to override GetHashCode and Equals methods in your type.
     */
    class HashSetExample
    {
        public void HashSetExampleMain()
        {
            // Initialize the set using object initialization syntax 
            var hashSet = new HashSet<int>() { 1, 2, 3 };

            // Add an object to the set
            hashSet.Add(4);

            // Remove an object 
            hashSet.Remove(3);

            // Remove all objects 
            hashSet.Clear();

            // Check to see if the set contains an object 
            var contains = hashSet.Contains(1);

            // Return the number of objects in the set 
            var count = hashSet.Count;

            // HashSet provides many mathematical set operations:

            var another = new HashSet<int>() { 7, 6, 5, 4 };
            // Modify the set to include only the objects present in the set and the other set
            hashSet.IntersectWith(another);

            // Remove all objects in "another" set from "hashSet" 
            hashSet.ExceptWith(another);

            // Modify the set to include all objects included in itself, in "another" set, or both
            hashSet.UnionWith(another);

            var isSupersetOf = hashSet.IsSupersetOf(another);
            var isSubsetOf = hashSet.IsSubsetOf(another);
            var equals = hashSet.SetEquals(another);
            
        }

    }
}
