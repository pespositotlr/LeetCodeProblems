using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
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

    /// <summary>
    /// https://leetcode.com/problems/same-tree/
    /// </summary>
    internal class SameTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            //Check if root node is equal.
            //Then check if one left subtree is equal to the other's left subtree, same with right
            //This is a recursive depth first search.

            //Base cases
            //If both are null, these nodes are equal and no more recurring needs to be done
            if (p == null && q == null)
                return true;

            //We know they're not BOTH null, so if one is null and one is not null
            //or these specific nodes are not equal
            //return false
            if ((p == null || q == null) || (p.val != q.val))
                return false;

            //At this point if we haven't returned false, the roots are equal but they have leaves
            //So now want to recur, doing the same for the left and right trees
            bool isLeftEqual = IsSameTree(p.left, q.left);
            bool isRightEqual = IsSameTree(p.right, q.right);

            //If both subtrees are true, the whole result is true. If not, returns false.
            return isLeftEqual && isRightEqual;
        }
    }
}
