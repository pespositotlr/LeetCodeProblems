using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Graphing
{
    //https://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core
    class DepthFirstSearchStackExample
    {
        public class Graph<T>
        {
            public Graph() { }
            public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
            {
                foreach (var vertex in vertices)
                    AddVertex(vertex);

                foreach (var edge in edges)
                    AddEdge(edge);
            }

            public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

            public void AddVertex(T vertex)
            {
                AdjacencyList[vertex] = new HashSet<T>();
            }

            public void AddEdge(Tuple<T, T> edge)
            {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
                {
                    AdjacencyList[edge.Item1].Add(edge.Item2);
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }

        public class Algorithms
        {
            public HashSet<T> DFS<T>(Graph<T> graph, T start)
            {
                var visited = new HashSet<T>();

                if (!graph.AdjacencyList.ContainsKey(start))
                    return visited;

                var stack = new Stack<T>();
                stack.Push(start);

                while (stack.Count > 0)
                {
                    var vertex = stack.Pop();

                    if (visited.Contains(vertex))
                        continue;

                    visited.Add(vertex);

                    foreach (var neighbor in graph.AdjacencyList[vertex])
                        if (!visited.Contains(neighbor))
                            stack.Push(neighbor);
                }

                return visited;
            }
        }

        public static void MainDFS(string[] args)
        {
            /*
             *       1
             *     / |
             *    2  3 
             *   /   | \
             *  4    5---6
             *  |  / |
             *  7    8
             *       |
             *       9
             *       |
             *       10
             */

            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

            Console.WriteLine(string.Join(", ", algorithms.DFS(graph, 1)));
            // 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
            
            
            //      a
            //   / |  \
            //  b  c  d
            //     |
            //     e

            var vertices2 = new[] { 'a', 'b', 'c', 'd', 'e' };
            var edges2 = new[] { Tuple.Create('a', 'b'), Tuple.Create('a', 'c'), Tuple.Create('c', 'e'), Tuple.Create('a', 'd') };
            var graph2 = new Graph<char>(vertices2, edges2);
                        
            Console.WriteLine(string.Join(", ", algorithms.DFS(graph2, 'a')));
            // a, d, c, e, b
        }

        public HashSet<T> DFS<T>(Graph<T> graph, T start, Action<T> preVisit = null)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                if (preVisit != null)
                    preVisit(vertex);

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }
    }

}