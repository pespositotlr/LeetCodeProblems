using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.General
{
    /// <summary>
    /// https://leetcode.com/problems/binary-tree-maximum-path-sum/description/
    /// This is an LC Hard
    /// The path sum is the sum of all the nodes values in that path.
    ///                 1
    ///                /  \
    ///               2    3
    /// All three are in one "path" even though you go up then down. So 1+2+3 = 6.
    /// If you had a negative value you would want to avoid it. So you need ot know all the "paths". 
    /// 1. 2. 3. 1-2. 1-3. and 1-2-3. In case some were negative.
    /// But you can't go in "two directions at once". Or "split".
    /// You can only "split" once at most. 
    ///                 1
    ///                /  \
    ///               2    3
    ///                   / \
    ///                   4  5
    ///  So you couldn't get both 4 and 5 in this situation. So going all the way to the root is 2+1+3+5 = 11.
    ///  But if you "split" at the 3 instead it's 4+3+5 = 12 which is larger.
    ///  Because of this the lower trees are subproblems and it's a DFS. Results in O(n)
    ///  A leaf with no subchildren has a "max path" of itself.
    ///  You want to compute if you "are not allowed to split" and "if you are allowed to split" and take the max
    ///                 1 (1+2+8=11 with split, 1+8=9 without split)
    ///                /  \
    ///            2 (2)    3 (3+4+5=12 with split. 3+5=8 without split)
    ///                   /     \
    ///                  4 (4)   5 (5)
    ///  Because you have the totals stored it's O(n)
    ///  Remember values can be negative so you may not want to go to the children and not include either.
    ///  So Max(leftVal, rightVal, 0) in case both are negative in which case you don't want either.
    /// </summary>
    public class BinaryTreeMaximumPathSumClass
    {
        List<int> res = new List<int>();

        public int BinaryTreeMaximumPathSum(TreeNode root)
        {
            res.Add(root.val);
            dfs(root);

            //An alternative to using a global variable is to return a Tuple, one with split and one without split
            return res[0];
        }

        //Return max path sum without split
        public int dfs(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftMax = dfs(root.left); //This is the value of the left subtree WITHOUT a split
            var rightMax = dfs(root.right); //This is the value of the right subtree WITHOUT a split
            leftMax = Math.Max(leftMax, 0); //Use 0 if value is negative
            rightMax = Math.Max(rightMax, 0); //Use 0 if value is negative

            //Compute max path sum WITH split and hold it in your local result.
            //In this case you're adding together the whole left tree and the whole right tree and your "split point" is this node.
            //Don't update if current res is already larger.
            res[0] = Math.Max(res[0], (root.val + leftMax + rightMax));

            //Return value is what we give WITHOUT splitting
            //You choose the max of either left OR right because if you chose both it would mean you're splitting.
            return (root.val + Math.Max(leftMax, rightMax));
        }
    }
}
