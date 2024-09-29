using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///https://leetcode.com/problems/validate-binary-search-tree/
///Determine if this is a valid binary search tree or not.
///Every single node in the left subtree is less than the root and every node in the right subtree is greater than the root
///          5
///         /  \
///        3    7
///             / \
///             4  8
/// This fails because the 4 is in the right subtree.
/// Brute force would be to check every value for 5 O(n). Then do the same for 7 O(n). So this is O(n)^2
/// This is a DFS
/// Start with boundaries of -infinity and +infinity
/// Then you only check if the 3 item is -infinity and < 5
/// Then you'd do 7 < infinity and greater than 5
/// Then you'd do 8 > 7 and 8 < infinity
/// Then you'd do 4 > 5 (borrowed from parent) and 4 < 7 This fails so return false.

namespace LeetCodeProblems.General
{
    public class ValidateBinaryTree
    {
        public static bool isValidBST(TreeNode root)
        {
            return isValid(root, Int32.MinValue, Int32.MaxValue);
        }

        public static bool isValid(TreeNode node, int left, int right)
        {
            if (node == null)
                return true; //If there's no more nodes to go down and we haven't hit false, this leaf is true.

            if (node.val > right || node.val < left)
                return false; //This broke the tree. Right should be bigger than val, left should be smaller than val

            //Check all the left subtrees with this value as the "right" and the parent left as the "left"
            //And also check all the right subtrees with the parent value as "right" and this value as "left"
            return (isValid(node.left, left, node.val) && isValid(node.right, node.val, right));

        }
    }
}
