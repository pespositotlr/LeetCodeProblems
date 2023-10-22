using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/diameter-of-binary-tree/
    /// Finding the longest "path" in the tree
    /// </summary>
    internal class DiameterOfBinaryTree
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

        int resultDiameter;

        /// <summary>
        /// Find the diameter, which is the longest path between any two nodes.
        /// You're recusively looking through each node to find the longest diameter that runs through that node
        ///       1
        ///      / \
        ///     2
        ///    / \
        ///   3   4
        ///  /     \
        /// 5       6
        /// This example tree would have a max diameter of 4, running from the 5 up 
        /// Height = 1 + Max(leftHeight, rightHeight)
        /// Diameter = leftHeight + rightHeight + 2 (to account for null edges)
        /// This is O(n) because it only traverses each node once.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetDiameterOfBinaryTree(TreeNode root)
        {
            resultDiameter = 0; //Result is stored outside the recursive loop
            dfs(root);
            return resultDiameter;
        }

        private int dfs(TreeNode root)
        {
            if (root == null)
                return -1; //Return a diameter of -1 for a null node

            //Find heights
            var leftHeight = dfs(root.left);
            var rightHeight = dfs(root.right);

            //Calculate diameter
            //The +2 here is to account for the -1 in the null nodes
            resultDiameter = Math.Max(resultDiameter, 2 + leftHeight + rightHeight); 

            return 1 + Math.Max(leftHeight, rightHeight); //The value returned here is the height
        }
    }
}
