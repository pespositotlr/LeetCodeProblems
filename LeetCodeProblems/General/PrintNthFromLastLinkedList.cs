using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    class PrintNthFromLastLinkedList
    {
        public LinkedListNode head; // head of the list  

        /* Linked List node */
        public class LinkedListNode
        {
            public int data;
            public LinkedListNode next;
            public LinkedListNode(int d)
            {
                data = d;
                next = null;
            }
        }

        /* Function to get the nth node from the last of a linked list */
        void PrintNthFromLast(int n)
        {
            int lengthOfLinkedList = 0;
            LinkedListNode temp = head;

            // 1) count the number of nodes in Linked List  
            while (temp != null)
            {
                temp = temp.next;
                lengthOfLinkedList++;
            }

            // check if value of n is not more than length of the linked list  
            if (lengthOfLinkedList < n)
                return;

            temp = head;

            // 2) get the (len-n+1)th node from the beginning  
            for (int i = 1; i < (lengthOfLinkedList - n) + 1; i++)
                temp = temp.next;

            Console.WriteLine(temp.data);
        }

        /* Inserts a new Node at front of the list. */
        public void Push(int new_data)
        {
            /* 1 & 2: Allocate the Node & Put in the data*/
            LinkedListNode newNode = new LinkedListNode(new_data);

            /* 3. Make next of new Node as head */
            newNode.next = head;

            /* 4. Move the head to point to new Node */
            head = newNode;
        }

        /*Driver code */
        public static void PrintNthFromLastLinkedList_Main()
        {
            PrintNthFromLastLinkedList llist = new PrintNthFromLastLinkedList();
            llist.Push(20);
            llist.Push(4);
            llist.Push(15);
            llist.Push(35);

            llist.PrintNthFromLast(4);
        }
    }
}
