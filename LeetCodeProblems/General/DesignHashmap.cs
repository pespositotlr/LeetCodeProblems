using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/design-hashmap/
    /// </summary>
    internal class DesignHashmap
    {
        public class ListNode
        {
            public int key;
            public int val;
            public ListNode next;
            public ListNode(int key = -1, int val = -1, ListNode next = null) 
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }

        }
        //https://www.youtube.com/watch?v=cNWsgbKwwoU&t=1s
        //The key is hashed values use a modulus of the length of the hashmap
        //Collissions are avoided with "chaining" where indexes share multiple values (even if they had different keys) stored as linked lists
        //You then keep the key inside the node
        //The linked lists start with dummy nodes to function as the head and where it points changes
        //Time isn't necessarily O(1) due to the chaining but something close to that.
        //This doesn't ask for a "Resize" method which involves growing the hashmap
        public class MyHashMap
        {
            public ListNode[] map;
            const int length = 1000;
            public MyHashMap()
            {
                this.map = new ListNode[length];
                for(int i = 0; i < length; i++)
                {
                    this.map[i] = new ListNode() { key = -1, val = -1, next = null }; //Set a dummy listnode as the head
                }
            }

            public void Put(int key, int value)
            {
                int index = GetHash(key); //Get the hash value based on the index mod the size
                ListNode cur = map[index]; //Get the head of the linked list at that index

                //Loop through the linked list from the head forward until you get to the item with the matching key
                //We actually are checking NEXT every time so if we don't find the key, we end up at the end of the linked list
                while (cur.next != null)
                {
                    if (cur.next.key == key)
                    {
                        cur.next.val = value; //Here, the item already existed and the value updates
                        return;
                    }
                    cur = cur.next;
                }
                //At this point we assume the node isn't there so we add a new one and have the last item in the list point to it
                cur.next = new ListNode(key, value);
            }

            private int GetHash(int key)
            {
                return key % map.Length;
            }

            public int Get(int key)
            {
                ListNode cur = map[GetHash(key)].next; //Use .next here to avoid starting at the dummy node
                while (cur != null)
                {
                    if (cur.key == key)
                        return cur.val;

                    cur = cur.next;
                }

                return -1; //Return default value because the key wasn't found
            }

            //We're not actually deleting the memory here
            public void Remove(int key)
            {
                ListNode cur = map[GetHash(key)];
                while (cur != null && cur.next != null)
                {
                    if (cur.next.key == key) //If the NEXT item has your key
                    {
                        cur.next = cur.next.next; //Set the pointer to skip over the one with the key to remove to the next one
                        return;
                    }

                    cur = cur.next;
                }

                //If we reach the end of the loop and the key isn't there, we do nothing.
            }
        }

    }
}
