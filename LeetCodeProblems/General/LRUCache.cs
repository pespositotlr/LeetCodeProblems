using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /**
    * @see <a href="https://leetcode.com/problems/lru-cache/">LRU Cache</a>
    * 
    * Julia, work on C# version
    * The key to this is a *dummy head* with value of 0 points to the "next" which is a real value
    * and the last item on the list is a *dummy tail*  with value of 0 that the last item in the cache points to.
    * When you're at capacity, you remove the one pointing to the dummy tail.
    * If you do a "get" remove it and add it to the top so it's more recent.
    * To do a remove, make the one pointing to it point to the next one and the one after it point to its previous one.
    */

    public class LRUCache
    {
        class ListNode
        {
            public int key, val;
            public ListNode prev, next;

            public ListNode(int k, int v)
            {
                key = k;
                val = v;
                prev = null;
                next = null;
            }
        }

        private int capacity, size;
        private ListNode dummyTail, dummyHead;
        // private Map<Integer, ListNode> map;   Java code 
        private Dictionary<int, ListNode> map;

        public bool argumentOk = true;

        public LRUCache(int capacity)
        {
            if (capacity <= 0)
            {
                //throw new IllegalArgumentException("Positive capacity required.");
                argumentOk = false;
                return;
            }

            this.capacity = capacity;
            size = 0;
            dummyTail = new ListNode(0, 0);
            dummyHead = new ListNode(0, 0);
            dummyHead.prev = dummyTail;
            dummyTail.next = dummyHead;
            map = new Dictionary<int, ListNode>();
        }

        public int get(int key)
        {
            if (!map.ContainsKey(key))
            {
                return -1;
            }

            ListNode target = map[key];
            remove(target);
            addToTop(target);
            return target.val;
        }

        public void set(int key, int value)
        {
            if (map.ContainsKey(key))
            { // update old value of the key
                ListNode target = map[key];
                target.val = value;
                remove(target);
                addToTop(target);
            }
            else
            { // insert new key value pair, need to check current size
                if (size == capacity)
                {
                    map.Remove(dummyTail.next.key);
                    remove(dummyTail.next);
                    --size;
                }

                ListNode newNode = new ListNode(key, value);
                map.Add(key, newNode);
                addToTop(newNode);
                ++size;
            }
        }

        // Head---\New node here/---Head.Prev
        private void addToTop(ListNode target)
        {
            target.next = dummyHead;
            target.prev = dummyHead.prev;
            dummyHead.prev.next = target;
            dummyHead.prev = target;
        }

        // Next---^Removed node^---Prev
        // \____old noes now linked___/ 
        private void remove(ListNode target)
        {
            target.next.prev = target.prev;
            target.prev.next = target.next;
        }

    }
}
