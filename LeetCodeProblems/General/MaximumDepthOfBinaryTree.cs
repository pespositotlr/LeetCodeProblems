using System;
using System.Collections.Generic;
using System.Text;
using static LeetCodeProblems.LinkedList;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// Given the root of a binary tree, return its maximum depth.
    /// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
    /// This uses a recursive DFS.
    /// </summary>
    internal class MaximumDepthOfBinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        //Recursive DFS O(n)
        //Searching down every node and taking the max traversal
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return (1 + Math.Max( MaxDepth(root.left), MaxDepth(root.right) ));
        }

        //Iterative BFS O(n)
        //Doing a level-order traversal, counting the number of levels we have
        //Add things to a queue at each level then dequeue them and then replace it with its children
        public int MaxDepthBFS(TreeNode root)
        {
            if (root == null)
                return 0;

            int level = 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while(q.Count > 0)
            {
                //Remove everything in the queue and then add the children
                for (int i = 0; i < q.Count; i++)
                {
                    TreeNode node = q.Dequeue();

                    if (node.left != null)
                        q.Enqueue(node.left); //Queue next level

                    if (node.right != null)
                        q.Enqueue(node.right); //Queue next level
                }

                level++; //Add one to the level every time you've queued the children
            }

            return level;
        }

        //Iterative DFS O(n)
        //Uses a stack. Pop the parent and add the children to the stack.
        public int MaxDepthIterativeDFS(TreeNode root)
        {         

            //Don't need the null check here because if the root node is null you just return 0;
            Stack<(TreeNode Node, int Depth)> stack = new Stack<(TreeNode Node, int Depth)>();
            stack.Push((root, 1));
            int result = 0;

            //While statement that keeps track of your current depth.
            //If node is not null, you can update the result. The result keeps track of the max depth of any subtree.
            while (stack.Count > 0 && stack.Peek().Node != null)
            {
                var stackValue = stack.Pop();
                var node = stackValue.Node;
                var depth = stackValue.Depth;

                if (node != null)
                {
                    result = Math.Max(result, depth);
                    stack.Push((node.left, depth + 1));
                    stack.Push((node.right, depth + 1));
                }
            }

            return result;
        }
    }
}
