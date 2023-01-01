using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.General
{

    public class NodeSRBT
    {
        public int value { get; set; }
        public NodeSRBT left { get; set; }
        public NodeSRBT right { get; set; }
    }

    class SearchRandomBinaryTree
    {
        static void findNode(NodeSRBT root, int val1, int val2)
        {

            var foundValue = -1;
            var currentNode = root;

            while (foundValue == -1)
            {
                if (currentNode.value == val1)
                {
                    foundValue = val1;
                    break;
                }
                if (currentNode.value == val2)
                {
                    foundValue = val2;
                    break;
                }

                if (currentNode.value > val1 && currentNode.value > val2)
                {
                    currentNode = currentNode.left;
                    continue;
                }
                if (currentNode.value < val1 && currentNode.value < val2)
                {
                    currentNode = currentNode.right;
                    continue;
                }
                foundValue = currentNode.value;

            }
        }

        public static bool valExist(NodeSRBT root, int val)
        {
            var currentNode = root;

            if (currentNode.value == val)
            {
                return true;
            }

            return search(currentNode, val);

        }


        public static bool search(NodeSRBT currentNode, int val)
        {
            if (currentNode.value == val)
            {
                return true;
            }

            if (currentNode.left != null)
            {
                currentNode = currentNode.left;
            }
            else if (currentNode.right != null)
            {
                currentNode = currentNode.right;
            }
            else
            {
                return false;
            }

            return search(currentNode, val);
        }


        /// <summary>
        /// Recursive call taht checks if value is anywhere in the tree
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool searchTree(NodeSRBT currentNode, int val)
        {
            

            if (currentNode != null)
            {
                if (currentNode.value == val)
                {
                    return true;
                }
                
                var leftReturnVal = searchTree(currentNode.left, val);

                if (leftReturnVal)
                    return true;

                var rightReturnVal = searchTree(currentNode.right, val);

                if (rightReturnVal)
                    return true;

            }

            return false;
        }


        //      [9]
        //    /    \
        //   [6]      [18]
        // /   \      / \
        // [A4] [B8] [11] [19]

    }
}
