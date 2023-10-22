using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{
    internal class SubtreeOfAnotherTree
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
        /// Given a root and subroot, return true if there is a subrtree of root with the 
        /// same strucutre and node values of the subroot.
        /// https://leetcode.com/problems/subtree-of-another-tree/
        /// This is like SameTree but with another step where you start with the root 
        /// of the first tree and then go down its stems.
        /// O(s * t) (The size of both trees)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="subRoot"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            //Assume null is always a subtree of any tree
            if (subRoot == null)
                return true;

            //If the main tree is null and the subroot is not null, this is always false
            if (root == null)
                return false;

            //If the subtree is the root, then this is true
            if (IsSameTree(root, subRoot)) 
                return true;

            bool isLeftASubtree = IsSubtree(root.left, subRoot);
            bool isRightASubtree = IsSubtree(root.right, subRoot);

            //If either is a subtree, then return true. If neither, return false.
            ////The recursion will return true if ANY subtree lower-level subtree is true.
            return (isLeftASubtree || isRightASubtree);
        }
        
        //Use the IsSameTree as a helper function
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
