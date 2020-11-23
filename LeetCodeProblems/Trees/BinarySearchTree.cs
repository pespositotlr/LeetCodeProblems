using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Trees
{
    // http://csharpexamples.com/c-binary-search-tree-implementation/
    //    PreOrder Traversal: (Basically the top-down, left-to-right traversal)
    //    Visit the root
    //    Traverse the left subtree
    //    Traverse the right subtree

    //    InOrder Traversal: (This should result in getting a correctly-ordered list)
    //    Traverse the left subtree
    //    Visit the root
    //    Traverse the right subtree

    //    PostOrder Traversal: (Basically the bottom-up, left-to-right traversal)
    //    Traverse the left subtree
    //    Traverse the right subtree
    //    Visit the root

    // The in-order/inorder successor is the leftmost node of the right subtree.
    class BTSNode
    {
        public BTSNode LeftNode { get; set; }
        public BTSNode RightNode { get; set; }
        public int Data { get; set; }
    }

    class BinarySearchTree
    {
        public BTSNode Root { get; set; }

        public static void BinarySearchTree_Main()
        {
            BinarySearchTree binaryTree = new BinarySearchTree();

            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);

            // 1
            /// \
            //	  2
            //	   \
            //      7
            //     /  \
            //	  3    10
	        //     \   /
            //      5 8

            BTSNode node = binaryTree.Find(5);
            int depth = binaryTree.GetTreeDepth();

            Console.WriteLine("PreOrder Traversal:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:");
            binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:");
            binaryTree.TraversePostOrder(binaryTree.Root);
            Console.WriteLine();

            binaryTree.Remove(7);
            binaryTree.Remove(8);

            // 1
            /// \
            //	  2
            //	   \
            //      8
            //     /  \
            //	  3   10
            //     \  
            //      5

            // 1
            /// \
            //	  2
            //	   \
            //      10
            //     /  
            //	  3   
            //     \  
            //      5

            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.ReadLine();
        }

        public bool Add(int value)
        {
            BTSNode before = null, after = this.Root;

            //Get the direct parent node for this value
            while (after != null)
            {
                before = after; 
                if (value < after.Data) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value > after.Data) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Same value already exists in the tree
                    return false;
                }
            }

            BTSNode newNode = new BTSNode();
            newNode.Data = value;

            if (this.Root == null) //Tree is empty
                this.Root = newNode;
            else
            {
                //Set value based on "before" we found above
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public BTSNode Find(int value)
        {
            //This method is recursive, so start with the root node
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private BTSNode Remove(BTSNode parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) 
                parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);
            // If value is = to parent's value, then this (parent) is the node to be deleted  
            else
            {
                // We need to "shift up" all the children to remove this node.

                // Node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // Node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        // Get the value of the left-most child node of this subtree.
        private int MinValue(BTSNode node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        // Recursively search through the tree
        private BTSNode Find(int value, BTSNode parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(BTSNode parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(BTSNode parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(BTSNode parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(BTSNode parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }
    }
}
