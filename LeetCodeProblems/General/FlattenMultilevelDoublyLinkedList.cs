using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class FlattenMultilevelDoublyLinkedList
    {
        // Step1:
        // 1---2---3---4---5---6--NULL
        //         |
        //         7---8---9---10--NULL
        //             |
        //             11--12--NULL
        // Step2:
        // 1---2---3---4---5---6--NULL
        //         |
        //         7---8---11--12--9---10--NULL
        // Step3:
        // 1---2---3---7---8---11--12--9---10--4---5---6--NULL
        public static NodeWithChildren Flatten(NodeWithChildren head)
        {
            if (head == null) return head;
            NodeWithChildren tmp = head;
            while (tmp != null)
            {
                if (tmp.child != null)
                {
                    NodeWithChildren child = Flatten(tmp.child);
                    tmp.child = null;
                    NodeWithChildren next = tmp.next;
                    tmp.next = child;
                    child.prev = tmp;
                    while (child.next != null)
                    {
                        child = child.next;
                    }
                    child.next = next;
                    if (next != null)
                    {
                        next.prev = child;
                    }
                    tmp = next;
                }
                else
                {
                    tmp = tmp.next;

                }
            }
            return head;
        }

        //Step1:
        // 1---2---3---4---5---6--NULL
        //         |
        //         7---8---9---10--NULL
        //             |
        //             11--12--NULL

        //Step2:
        //1---2---3---7---8---9---10---4---5---6--NULL
        //             |
        //             11--12--NULL

        //Step3:
        //1---2---3---7---8---11--12--9---10--4---5---6--NULL
        public NodeWithChildren Flatten2(NodeWithChildren head)
        {
            if (head == null) return null;

            NodeWithChildren tmp = head;
            while (tmp != null)
            {
                if (tmp.child != null)
                {

                    NodeWithChildren child = tmp.child;
                    tmp.child = null;

                    NodeWithChildren next = tmp.next;
                    tmp.next = child;
                    child.prev = tmp;
                    while (child.next != null)
                    {
                        child = child.next;
                    }

                    if (next != null)
                    {
                        child.next = next;
                        next.prev = child;
                    }
                }
                tmp = tmp.next;
            }
            return head;
        }
        public NodeWithChildren Flatten3(NodeWithChildren head)
        {
            FlattenAndReturnTail(head);
            return head;
        }
        public NodeWithChildren FlattenAndReturnTail(NodeWithChildren head)
        {
            if (head == null) return null;
            if (head.child == null)
            {
                if (head.next == null) return head;
                return FlattenAndReturnTail(head.next);
            }
            else
            {
                NodeWithChildren child = head.child;
                head.child = null;

                NodeWithChildren next = head.next;
                NodeWithChildren childTail = Flatten(child);
                head.next = child;
                child.prev = head;
                if (next != null)
                {
                    childTail.next = next;
                    next.prev = childTail;
                    return FlattenAndReturnTail(next);
                }
                return childTail;
            }
        }

        public static void PrintFlatList(NodeWithChildren head)
        {
            if (head == null) Console.Write("Null head");
            NodeWithChildren tmp = head;
            while (tmp.next != null)
            {
                Console.Write(tmp.key + "---");
                tmp = tmp.next;
            }
            Console.Write("null");
            return;
        }
    }

    public class NodeWithChildren
    {
        public int key;
        public NodeWithChildren prev, next, child;

        public NodeWithChildren(int key)
        {
            this.key = key;
            prev = next = null;
            child = null;
        }
    }

}
