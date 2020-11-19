using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{

    //Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
    //For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
    //Example:
    //Given the sorted array: [-10,-3,0,5,9],
    //One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:
    //      0
    //     / \
    //   -3   9
    //   /   /
    // -10  5

    //Definition for a binary tree node.
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

    public class ConvertSortedArrayToBinarySearchTree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return this.SortedArrayToBSTRecursion(nums, 0, nums.Length - 1);

        }

        /*        
        * Solution: do it manually would be like this. 
        * find the mid and set it as root, divide it into two parts, 
        * from the left part, find the mid and set it as root.left; from right part, 
        * find the mid and set it as root.right. It is recursion.
        */
        private TreeNode SortedArrayToBSTRecursion(int[] nums, int lowIndex, int highIndex)
        {
            if (lowIndex > highIndex)
            {
                return null;
            }

            var midIndex = (highIndex - lowIndex) / 2 + lowIndex;

            var newRoot = new TreeNode(nums[midIndex])
            {
                left = this.SortedArrayToBSTRecursion(nums, lowIndex, midIndex - 1),
                right = this.SortedArrayToBSTRecursion(nums, midIndex + 1, highIndex)
            };

            return newRoot;
        }
        public void DisplayTree(TreeNode root)
        {
            if (root == null) return;

            DisplayTree(root.left);
            System.Console.WriteLine(root.val + " ");
            DisplayTree(root.right);
        }
    }
}
