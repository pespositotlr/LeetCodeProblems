using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Trees
{
    //Source: https://www.c-sharpcorner.com/article/working-with-red-black-trees-in-c-sharp/

    //Every node is colored either red or black.
    //Every NIL node is black.
    //If a node is red, then both of its children are black.
    //Every path from a node to a descendant leaf contains the same number of black nodes.

    // It can be shown that a tree that implements the four red-black tree properties has a height that is always less than 2 * log2(n+1), 
    // where n is the total number of nodes in the tree.For this reason, red-black trees ensure that all operations can be performed within an asymptotic running time of log2 n.
    class RedBlackTreeExample
    {
        public RedBlackTreeNode Search(RedBlackTreeNode node, Object key)
        {
            if (node == null) return null;
            else
            {
                int result = String.Compare(key.ToString(), node.data.ToString());
                if (result < 0) return Search(node.left, key);
                else if (result > 0) return Search(node.right, key);
                else return node;
            }
        }
        public enum Color
        {
            Red = 0, Black = 1
        }
        
        public enum Direction
        {
            Left,
            Right
        }
        public class RedBlackTreeNode
        {
            public IComparable data;
            public RedBlackTreeNode left;
            public RedBlackTreeNode right;
            public Color color = Color.Black;
            public RedBlackTreeNode(IComparable data) : this(data, null, null) { }
            public RedBlackTreeNode(IComparable data, RedBlackTreeNode left, RedBlackTreeNode right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }
        }

        public class RedBlackTree
        {
            protected RedBlackTreeNode root;
            protected RedBlackTreeNode freshNode;
            protected RedBlackTreeNode currentNode;

            //RedBlackTree only 
            private Color Black = Color.Black;
            private Color Red = Color.Red;
            private RedBlackTreeNode parentNode;
            private RedBlackTreeNode grandParentNode;
            private RedBlackTreeNode tempNode;
            protected RedBlackTree()
            {
                freshNode = new RedBlackTreeNode(null);
                freshNode.left = freshNode.right = freshNode;
                root = new RedBlackTreeNode(null);
            }
            protected int Compare(IComparable item, RedBlackTreeNode node)
            {
                if (node != root) return item.CompareTo(node.data);
                else return 1;
            }
            public IComparable Search(IComparable data)
            {
                freshNode.data = data;
                currentNode = root.right;
                while (true)
                {
                    if (Compare(data, currentNode) < 0) currentNode = currentNode.left;
                    else if (Compare(data, currentNode) > 0) currentNode = currentNode.right;
                    else if (currentNode != freshNode) return currentNode.data;
                    else return null;
                }
            }
            protected void Display()
            {
                this.Display(root.right);
            }
            protected void Display(RedBlackTreeNode temp)
            {
                if (temp != freshNode)
                {
                    Display(temp.left);
                    Console.WriteLine(temp.data);
                    Display(temp.right);
                }
            }

#region "RedBlackTree only"

            public void Insert(IComparable item)
            {
                currentNode = parentNode = grandParentNode = root;
                freshNode.data = item;
                int returnedValue = 0;
                while (Compare(item, currentNode) != 0)
                {
                    tempNode = grandParentNode;
                    grandParentNode = parentNode;
                    parentNode = currentNode;
                    returnedValue = Compare(item, currentNode);
                    if (returnedValue < 0) currentNode = currentNode.left;
                    else currentNode = currentNode.right;
                    if (currentNode.left.color == Color.Red && currentNode.right.color == Color.Red) ReArrange(item);
                }
                if (currentNode == freshNode)
                {
                    currentNode = new RedBlackTreeNode(item, freshNode, freshNode);
                    if (Compare(item, parentNode) < 0) parentNode.left = currentNode;
                    else parentNode.right = currentNode;
                    ReArrange(item);
                }
            }


            private void ReArrange(IComparable item)
            {
                currentNode.color = Red;
                currentNode.left.color = Color.Black;
                currentNode.right.color = Color.Black;
                if (parentNode.color == Color.Red)
                {
                    grandParentNode.color = Color.Red;
                    bool compareWithGrandParentNode = (Compare(item, grandParentNode) < 0);
                    bool compareWithParentNode = (Compare(item, parentNode) < 0);
                    if (compareWithGrandParentNode != compareWithParentNode) parentNode = Rotate(item, grandParentNode);
                    currentNode = Rotate(item, tempNode);
                    currentNode.color = Black;
                }
                root.right.color = Color.Black;
            }
            private RedBlackTreeNode Rotate(IComparable item, RedBlackTreeNode parentNode)
            {
                int value;
                if (Compare(item, parentNode) < 0)
                {
                    value = Compare(item, parentNode.left);
                    if (value < 0) parentNode.left = this.Rotate(parentNode.left, Direction.Left);
                    else parentNode.left = this.Rotate(parentNode.left, Direction.Right);
                    return parentNode.left;
                }
                else
                {
                    value = Compare(item, parentNode.right);
                    if (value < 0) parentNode.right = this.Rotate(parentNode.right, Direction.Left);
                    else parentNode.right = this.Rotate(parentNode.right, Direction.Right);
                    return parentNode.right;
                }
            }
            private RedBlackTreeNode Rotate(RedBlackTreeNode node, Direction direction)
            {
                RedBlackTreeNode tempNode;
                if (direction == Direction.Left)
                {
                    tempNode = node.left;
                    node.left = tempNode.right;
                    tempNode.right = node;
                    return tempNode;
                }
                else
                {
                    tempNode = node.right;
                    node.right = tempNode.left;
                    tempNode.left = node;
                    return tempNode;
                }
            }

            #endregion

            public static void MainReBlackTree1()
            {
                RedBlackTree redBlackTree = new RedBlackTree();
                Random random = new Random();
                for (int i = 0; i < 1000000; i++)
                {
                    redBlackTree.Insert(random.Next(1, 1000000));
                    random.Next();
                }
                redBlackTree.Insert(1000001);
                DateTime startTime = DateTime.Now;
                int p = (int)redBlackTree.Search(1000001);
                DateTime endTime = DateTime.Now;
                TimeSpan TimeElapsed = (TimeSpan)(endTime - startTime);
                Console.WriteLine("The number " + p + " has been found in " + TimeElapsed.Milliseconds.ToString() + " milliseconds.");
                Console.Read();
                Console.Read();
            }

        }

    }
}
