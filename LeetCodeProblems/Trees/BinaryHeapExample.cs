using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Trees
{
    //https://en.wikipedia.org/wiki/Heap_(data_structure)
    //https://www.c-sharpcorner.com/article/binary-heap-in-c-sharp/ 
    //Binary heap is a Binary tree with some special properties.

    //Heap Properties are:

    //Min Heap : parent node value is less than child node value
    //Max Heap : Parent node value is greater than child node value.

    //    Practical Usage of Heap
    //    Prims algorithm
    //    Heap sort
    //    Priority Queue

    //    Implementation of Heap
    //    We can implement the Binary heap in two ways,
    //    Array based implementation
    //    Linked list based implementation : Asits implementation takes O(n) time, we will not be using it in this article.
    class BinaryHeapExample
    {
        int[] heapArray;
        int sizeOfTree;
        // Create a constructor  
        public BinaryHeapExample(int size)
        {
            //We are adding size+1, because array index 0 will be blank.  
            int[] arr = new int[size + 1];
            this.sizeOfTree = 0;
            Console.WriteLine("Empty heap has been created Successfully");
        }

        public int PeekOfHeap()
        {
            if (sizeOfTree == 0)
                return 0;
            else
                return heapArray[1];
        }

        public int SizeOfHeap()
        {
            Console.WriteLine("The size of the heap is:" + sizeOfTree);
            return sizeOfTree;
        }

        public void InsertElementInHeap(int value)
        {

            if (sizeOfTree < 0)
            {
                Console.WriteLine("Tree is empty");
            }
            else {
                //Insertion of value inside the array happens at the last index of the  array
                heapArray[sizeOfTree + 1] = value;
                sizeOfTree++;
                HeapifyBottomToTop(sizeOfTree);
                Console.WriteLine("Inserted " + value + " successfully in Heap !");
                levelOrder();
            }
        }

        public void HeapifyBottomToTop(int index)
        {
            int parent = index / 2;
            // We are at root of the tree. Hence no more Heapifying is required.  
            if (index <= 1)
            {
                return;
            }
            // If Current value is smaller than its parent, then we need to swap  
            if (heapArray[index] < heapArray[parent])
            {
                int tmp = heapArray[index];
                heapArray[index] = heapArray[parent];
                heapArray[parent] = tmp;
            }
            HeapifyBottomToTop(parent);
        }

        public void levelOrder()
        {
            Console.WriteLine("Printing all the elements of this Heap...");// Printing from 1 because 0th cell is dummy  
            for (int i = 1; i <= sizeOfTree; i++)
            {
                Console.WriteLine(heapArray[i] + " ");
            }
            Console.WriteLine("\n");
        }

        //Extract Head of Heap  
        public int extractHeadOfHeap()
        {
            if (sizeOfTree == 0)
            {
                Console.WriteLine("Heap is empty !");
                return -1;
            }
            else
            {
                Console.WriteLine("Head of the Heap is: " + heapArray[1]);
                Console.WriteLine("Extracting it now...");
                int extractedValue = heapArray[1];
                heapArray[1] = heapArray[sizeOfTree]; //Replacing with last element of the array  
                sizeOfTree--;
                HeapifyTopToBottom(1);
                Console.WriteLine("Successfully extracted value from Heap.");
                levelOrder();
                return extractedValue;
            }
        }

        public void HeapifyTopToBottom(int index)
        {
            int left = index * 2;
            int right = (index * 2) + 1;
            int smallestChild = 0;

            if (sizeOfTree < left)
            { //If there is no child of this node, then nothing to do. Just return.  
                return;
            }
            else if (sizeOfTree == left)
            { //If there is only left child of this node, then do a comparison and return.  
                if (heapArray[index] > heapArray[left])
                {
                    int tmp = heapArray[index];
                    heapArray[index] = heapArray[left];
                    heapArray[left] = tmp;
                }
                return;
            }
            else
            { //If both children are there  
                if (heapArray[left] < heapArray[right])
                { //Find out the smallest child  
                    smallestChild = left;
                }
                else
                {
                    smallestChild = right;
                }
                if (heapArray[index] > heapArray[smallestChild])
                { //If Parent is greater than smallest child, then swap  
                    int tmp = heapArray[index];
                    heapArray[index] = heapArray[smallestChild];
                    heapArray[smallestChild] = tmp;
                }
            }
            HeapifyTopToBottom(smallestChild);
        }

    }
}
