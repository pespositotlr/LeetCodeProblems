// C# program to print corner node  
// at each level in a binary tree 
using System;
using System.Collections.Generic;

namespace LeetCodeProblems
{
    /* A binary tree node has key, pointer to left 
    child and a pointer to right child */
    public class Node
    {
        public int key;
        public Node left, right;

        public Node(int key)
        {
            this.key = key;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        Node root;

        /* Function to print corner node at each level */
        void printCorner(Node root)
        {
            // star node is for keeping track of levels 
            Queue<Node> q = new Queue<Node>();

            // pushing root node and star node 
            q.Enqueue(root);
            // Do level order traversal of Binary Tree 
            while (q.Count != 0)
            {
                // n is the no of nodes in current Level 
                int n = q.Count;
                for (int i = 0; i < n; i++)
                {
                    Node temp = q.Peek();
                    q.Dequeue();
                    //If it is leftmost corner value or rightmost corner value then print it 
                    if (i == 0 || i == n - 1)
                        Console.Write(temp.key + " ");
                    //push the left and right children of the temp node 
                    if (temp.left != null)
                        q.Enqueue(temp.left);
                    if (temp.right != null)
                        q.Enqueue(temp.right);

                }
            }

        }

        // Driver code 
        public static void PrintCorners()
        {
            //   15
            //  10 20
            // 8 12 16 25
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(15);
            tree.root.left = new Node(10);
            tree.root.right = new Node(20);

            tree.root.left.left = new Node(8);
            tree.root.left.right = new Node(12);
            tree.root.right.left = new Node(16);
            tree.root.right.right = new Node(25);

            tree.root.left.left.left = new Node(34);
            tree.root.left.left.right = new Node(35);
            tree.root.left.right.left = new Node(36);
            tree.root.left.right.right = new Node(37);
            tree.root.right.left.left = new Node(38);
            tree.root.right.left.right = new Node(39);
            tree.root.right.right.left = new Node(40);
            tree.root.right.right.right = new Node(41);

            tree.printCorner(tree.root);
        }
    }

    // This code is contributed by Utkarsh Choubey 

}
