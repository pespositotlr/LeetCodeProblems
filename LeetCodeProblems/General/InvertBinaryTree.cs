using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    //Source: https://stackoverflow.com/questions/9460255/reverse-a-binary-tree-left-to-right
    class InvertBinaryTree
    {
        public static void InvertTree(TreeNode root)
        {
            TreeNode temp = root.right;
            root.right = root.left;
            root.left = temp;

            if (root.left != null)
            {
                InvertTree(root.left);
            }

            if (root.right != null)
            {
                InvertTree(root.right);
            }
        }

        // helper method
        private static void InvertTree2(TreeNode root)
        {
            InvertTreeNode(root);
        }

        private static void InvertTreeNode(TreeNode node)
        {
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;

            if (node.left != null)
                InvertTreeNode(node.left);

            if (node.right != null)
                InvertTreeNode(node.right);
        }

        // helper method for traverse
        private static void traverseTree(TreeNode root)
        {
            Queue<int> leftChildren = new Queue<int>();
            Queue<int> rightChildren = new Queue<int>();

            TraverseTreeNode(root, leftChildren, rightChildren);

            Console.WriteLine("Tree;\n*****");

            Console.WriteLine("%3d\n", root.val);

            int count = 0;
            int div = 0;
            while (!(leftChildren.Count == 0 && rightChildren.Count == 0))
            {
                Console.Write("%3d\t%3d\t", leftChildren.Peek(), rightChildren.Peek());
                count += 2;
                div++;
                if ((double)count == (Math.Pow(2, div)))
                {
                    Console.WriteLine();
                    count = 0;
                }
            }

            Console.ReadLine();
        }

        private static void TraverseTreeNode(TreeNode node, Queue<int> leftChildren, Queue<int> rightChildren)
        {
            if (node.left != null)
                leftChildren.Enqueue(node.left.val);

            if (node.right != null)
                rightChildren.Enqueue(node.right.val);

            if (node.left != null)
            {
                TraverseTreeNode(node.left, leftChildren, rightChildren);
            }

            if (node.right != null)
            {
                TraverseTreeNode(node.right, leftChildren, rightChildren);
            }
        }


        public static void ReverseTreeMain()
        {

            // root node
            TreeNode root = new TreeNode(6);

            // children of root
            root.left = new TreeNode(3);
            root.right = new TreeNode(4);

            // grand left children of root
            root.left.left = new TreeNode(7);
            root.left.right = new TreeNode(3);

            // grand right childrend of root
            root.right.left = new TreeNode(8);
            root.right.right = new TreeNode(1);

            Console.WriteLine("Before invert");
            traverseTree(root);

            InvertTree(root);

            Console.WriteLine("\nAfter invert");
            traverseTree(root);
        }
    }
}
