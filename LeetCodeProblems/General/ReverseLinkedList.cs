using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class LinkedList
    {
        Node head;

        public class Node
        {
            public int data;
            public Node next;

            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        // function to add a new node at 
        // the end of the list 
        public void AddNode(Node node)
        {
            if (head == null)
                head = node;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        // [Head  ]\[NodeA ]\[NodeB    ]
        // [Next=A]/[Next=B]/[Next=null]
        // 
        // Step 1 (current = Head): 
        // current = head
        // current (head) points to *null*
        // next = NodeA
        // prev = head
        // current = NodeA
        //
        // Step 2 (Current = NodeA):
        // current = NodeA
        // current (NodeA) points to *head*
        // next = NodeB
        // prev = NodeA
        // current = NodeB

        //End Result
        // [Head     ]/[NodeA    ]/[NodeB    ]
        // [Next=NULL]\[Next=Head]\[Next=A]
        // You've gone through each item, held onto what its old "next" was and then changed its "next" to point to the "previous" one. 
        // Then you shift forward until you have no more "nexts".

        // function to reverse the list 
        public void ReverseList()
        {
            Node prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        // function to print the list data 
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }

    // This code is contributed by Mayank Sharma 
}
