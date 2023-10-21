using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.
    /// </summary>
    internal class MergeTwoSortedLists
    {
        public class ListNode
        {
              public int val;
              public ListNode next;
              public ListNode(int val = 0, ListNode next = null)
              {
                    this.val = val;
                    this.next = next;
              }
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
            ListNode dummy = new ListNode();
            ListNode tail = dummy; //Start with a dummy value to avoid null issues

            while (list1 != null && list2 != null)
            {
                if(list1.val < list2.val) //Append whichever value is greater and then move forward on that linked list
                {
                    tail.next = list1;
                    list1 = list1.next; 
                } else
                {
                    tail.next = list2;
                    list1 = list2.next;
                }
                tail = tail.next; //Shift the tail (result values) forward
            }

            //If we get to the end of one list but the other still has values, append all remaining values of that list
            if (list1 != null)
                tail.next = list1;
            else if (list2 != null)
                tail.next = list2;

            return dummy.next;
        }
    }
}
