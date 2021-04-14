using System;
using System.Collections.Generic;

namespace Task_2
{
    public class Graph
    {
        public int[,] MatrixOfLengths { get; }

        public bool[,] MatrixOfConnections { get; }

        public int CountOfVertexes { get; }

        public Graph(int[,] matrixOfLengths, bool[,] matrixOfConnetions)
        {
            if (matrixOfConnetions == null || matrixOfLengths == null || matrixOfConnetions.Length != matrixOfLengths.Length ||
                matrixOfConnetions.GetLength(0) != matrixOfConnetions.GetLength(1) || matrixOfLengths.GetLength(0) != matrixOfLengths.GetLength(1))
            {
                throw new ArgumentException();
            }
            MatrixOfLengths = matrixOfLengths;
            MatrixOfConnections = matrixOfConnetions;
            CountOfVertexes = matrixOfLengths.GetLength(0);
        }

        private void DFS(int numberOfVertex, bool[] visited)
        {
            for (int i = 0; i < CountOfVertexes; ++i)
            {
                if (MatrixOfConnections[numberOfVertex, i] && !visited[i])
                {
                    visited[i] = true;
                    DFS(i, visited);
                }
            }
        }

        public bool IsConnected()
        {
            var visited = new bool[CountOfVertexes];
            DFS(0, visited);

            for (int i = 0; i < CountOfVertexes; ++i)
            {
                if (!visited[i])
                {
                    return false;
                }
            }
            return true;
        }

        private class Edge
        {
            public int FirstVertex { get; set; }

            public int SecondVertex { get; set; }

            public int Weight { get; set; }

            public Edge(int weight, int firstVertex, int secondVertex)
            {
                Weight = weight;
                FirstVertex = firstVertex;
                SecondVertex = secondVertex;
            }
        }

        public Graph GetSpanningTree()
        {
            var newLengths = new int[CountOfVertexes, CountOfVertexes];
            var newConnections = new bool[CountOfVertexes, CountOfVertexes];

            var edges = new List<Edge>();
            var visited = new bool[CountOfVertexes];

            int currentVertex = 0;
            for (int i = 0; i < CountOfVertexes - 1; ++i)
            {
                visited[currentVertex] = true;
                newConnections[currentVertex, currentVertex] = true;

                for (int j = 0; j < CountOfVertexes; ++j)
                {
                    if (!visited[j] && MatrixOfConnections[currentVertex, j])
                    {
                        var newEdge = new Edge(MatrixOfLengths[currentVertex, j], Math.Min(currentVertex, j), Math.Max(currentVertex, j));
                        edges.Add(newEdge);
                    }
                }

                Edge maxEdge = null;
                foreach (var edge in edges)
                {
                    if ((!visited[edge.FirstVertex] || !visited[edge.SecondVertex]) && (maxEdge == null ||edge.Weight < maxEdge.Weight))
                    {
                        maxEdge = edge;
                    }
                }

                if (maxEdge != null)
                {
                    edges.Remove(maxEdge);

                    newLengths[maxEdge.FirstVertex, maxEdge.SecondVertex] = maxEdge.Weight;
                    newLengths[maxEdge.SecondVertex, maxEdge.FirstVertex] = maxEdge.Weight;

                    newConnections[maxEdge.FirstVertex, maxEdge.SecondVertex] = true;
                    newConnections[maxEdge.SecondVertex, maxEdge.FirstVertex] = true;

                    currentVertex = visited[maxEdge.FirstVertex] ? maxEdge.SecondVertex : maxEdge.FirstVertex;
                }
            }

            return new Graph(newLengths, newConnections);
        }
    }
}
