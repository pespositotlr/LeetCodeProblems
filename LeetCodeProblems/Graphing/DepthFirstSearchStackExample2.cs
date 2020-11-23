using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Graphing
{
    // https://www.geeksforgeeks.org/iterative-depth-first-traversal/
    //  Approach: Depth-first search is an algorithm for traversing or searching tree or graph data structures.The algorithm starts at the root node 
    // (selecting some arbitrary node as the root node in the case of a graph) and explores as far as possible along each branch before backtracking.
    // So the basic idea is to start from the root or any arbitrary node and mark the node and move to the adjacent unmarked node and continue this loop until     
    // there is no unmarked adjacent node. Then backtrack and check for other unmarked nodes and traverse them. Finally print the nodes in the path.
    //  The only difference between iterative DFS and recursive DFS is that the recursive stack is replaced by a stack of nodes.
    //  Algorithm:
    //   Created a stack of nodes and visited array.
    //   Insert the root in the stack.
    //   Run a loop till the stack is not empty.
    //   Pop the element from the stack and print the element.
    //   For every adjacent and unvsisted node of current node, mark the node and insert it in the stack.
    //   Implementation of Iterative DFS: This is similar to BFS, the only difference is queue is replaced by stack.

    class DepthFirstSearchStackExample2
    {
        
    // An Iterative C# program to do DFS traversal from 
    // a given source vertex. DFS(int s) traverses vertices 
    // reachable from s. 
    // (Verticy is another name for Node)
    class GFG
        {
            // This class represents a directed graph using adjacency 
            // list representation 
            public class Graph
            {
                public int numberofVerticies; // Number of Vertices 

                public LinkedList<int>[] adjacencyLists; // adjacency lists 

                // Constructor 
                public Graph(int verticiesCount)
                {
                    this.numberofVerticies = verticiesCount;
                    adjacencyLists = new LinkedList<int>[verticiesCount];

                    for (int i = 0; i < adjacencyLists.Length; i++)
                        adjacencyLists[i] = new LinkedList<int>();

                }

                // To add an edge to graph 
                public void addEdge(int startingNode, int endingNode)
                {
                    adjacencyLists[startingNode].AddLast(endingNode); // Add target to a node's list
                }

                // prints all not yet visited vertices reachable from s 
                public void DepthFirstSearchFrom(int sourceNode)
                {
                    // Initially mark all vertices as not visited 
                    Boolean[] visited = new Boolean[numberofVerticies];

                    // Create a stack for DFS 
                    Stack<int> stack = new Stack<int>();

                    // Push the current source node 
                    stack.Push(sourceNode);

                    while (stack.Count > 0)
                    {
                        // Pop a vertex from stack and print it 
                        sourceNode = stack.Peek();
                        stack.Pop();

                        // Stack may contain same vertex twice. So 
                        // we need to print the popped item only 
                        // if it is not visited. 
                        if (visited[sourceNode] == false)
                        {
                            Console.Write(sourceNode + " ");
                            visited[sourceNode] = true;
                        }

                        // Get all adjacent vertices of the popped vertex s 
                        // If a adjacent has not been visited, then push it 
                        // to the stack. 
                        foreach (int verticies in adjacencyLists[sourceNode])
                        {
                            if (!visited[verticies])
                                stack.Push(verticies);
                        }

                    }
                }
            }

            // Driver code 
            public static void MainDFS2(String[] args)
            {
                // Total 5 vertices in graph 
                Graph g = new Graph(5);

                g.addEdge(1, 0);
                g.addEdge(0, 2);
                g.addEdge(2, 1);
                g.addEdge(0, 3);
                g.addEdge(1, 4);

                //      1----4
                //    /   \
                //   0-----2
                //    \
                //     3

                Console.Write("Following is the Depth First Traversal\n");
                g.DepthFirstSearchFrom(0);

                // Output:
                // Following is Depth First Traversal
                // 0 3 2 1 4

                // Complexity Analysis:
                // Time complexity: O(V + E), where V is the number of vertices and E is the number of edges in the graph.
                // Space Complexity: O(V).Since an extra visited array is needed of size V.
            }
        }

        // This code is contributed by Arnasb Kundu 

    }
}
