using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// https://leetcode.com/problems/combination-sum/
    /// You can't do a brute-force decision tree because you can end up with duplicates
    /// So you need to use a backtracking DFS where you include one path where you use the number 
    /// and one where you *don't* use the number.
    /// [2,3,6] Target = 7
    ///                  -
    ///            /            \
    ///        [2]                 [ ]
    ///     /        \            /    \
    ///   [2, 2]     [2]        [3]    [ ] 
    ///   /    \         / \          /   \
    /// [2,2,2] [2,2]   [2,3]  [2]   [6]  [ ]
    ///  /      /    \  X      /  \       /   \
    /// X    [2,2,3]  [2,2]   X    X    [7]   []
    ///                /   \
    ///                X   X
    /// Height of the tree will be Target and we're making 2 decisions for each level so the itme is O(2^t)
    internal class CombinationSum
    {
        int[] _candidates;
        IList<IList<int>> result;
        int _target;
        public IList<IList<int>> GetCombinationSum(int[] candidates, int target)
        {
            _candidates = candidates;
            _target = target;
            result = new List<IList<int>>();
            dfs(0, new List<int>(), 0); //Start at index 0 of nums and move forward
            return result;
        }

        private void dfs(int i, List<int> current, int total)
        {
            //Base case where we succeed
            if (total == _target)
            {
                result.Add(new List<int>(current));
                return;
            }

            //Base case where no numbers further down this tree can be correct
            if (i >= _candidates.Length || total > _target)
                return;

            //Decision to include _candidates[i] (Left side of the example tree)
            //Remember we can keep using the same candidate
            current.Add(_candidates[i]);
            dfs(i, current, total + _candidates[i]);

            //Decision NOT to include _candidates[i] (Right side of the example tree)
            current.RemoveAt(current.Count - 1); //This is a "pop" removing the one that was just added.
            dfs(i + 1, current, total); //Total stays the same here because we DID NOT add the number
        }
    }
}
