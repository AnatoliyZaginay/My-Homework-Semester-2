﻿using System;
using System.Linq;

namespace Task_2
{
    /// <summary>
    /// Undirected graph class.
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// An adjacency matrix containing the lengths between the vertices.
        /// </summary>
        public int[,] MatrixOfLengths { get; }

        /// <summary>
        /// An adjacency matrix containing boolean values that indicate whether the vertices are connected.
        /// </summary>
        public bool[,] MatrixOfConnections { get; }

        /// <summary>
        /// Count of vertices in graph.
        /// </summary>
        public int CountOfVertices { get; }

        /// <summary>
        /// Creates a new graph by adjaceny matrices.
        /// </summary>
        /// <param name="matrixOfLengths">Matrix of lengths.</param>
        /// <param name="matrixOfConnections">Matrix of connections.</param>
        public Graph(int[,] matrixOfLengths, bool[,] matrixOfConnections)
        {
            if (matrixOfConnections == null || matrixOfLengths == null || matrixOfConnections.Length != matrixOfLengths.Length ||
                matrixOfConnections.GetLength(0) != matrixOfConnections.GetLength(1) || matrixOfLengths.GetLength(0) != matrixOfLengths.GetLength(1))
            {
                throw new ArgumentException("Graph matrix is incorrect");
            }
            MatrixOfLengths = matrixOfLengths;
            MatrixOfConnections = matrixOfConnections;
            CountOfVertices = matrixOfLengths.GetLength(0);
        }

        /// <summary>
        /// Creates a new graph by the file containing adjacency lists.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public Graph(string path)
        {
            (int[,] matrixOfLengths, bool[,] matrixOfConnections) = GraphInFile.ReadFromFile(path);

            if (matrixOfConnections == null || matrixOfLengths == null)
            {
                throw new ArgumentException("Graph matrix is empty");
            }

            MatrixOfLengths = matrixOfLengths;
            MatrixOfConnections = matrixOfConnections;
            CountOfVertices = matrixOfLengths.GetLength(0);
        }

        private void DFS(int numberOfVertex, bool[] visited)
        {
            for (int i = 0; i < CountOfVertices; ++i)
            {
                if (MatrixOfConnections[numberOfVertex, i] && !visited[i])
                {
                    visited[i] = true;
                    DFS(i, visited);
                }
            }
        }

        /// <summary>
        /// Checks if the graph is connected.
        /// </summary>
        public bool IsConnected()
        {
            var visited = new bool[CountOfVertices];
            DFS(0, visited);

            return visited.All(x => x);
        }

        /// <summary>
        /// Graph edge class, that helps in the algorithm of making a maximum spanning tree.
        /// </summary>
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

        /// <summary>
        /// Makes maximum spanning tree.
        /// </summary>
        public Graph MakeMaximumSpanningTree()
        {
            var newLengths = new int[CountOfVertices, CountOfVertices];
            var newConnections = new bool[CountOfVertices, CountOfVertices];

            var edges = new PriorityQueue<Edge>();
            var visited = new bool[CountOfVertices];

            for (int i = 0; i < CountOfVertices; ++i)
            {
                newConnections[i, i] = true;
            }

            int currentVertex = 0;
            for (int i = 0; i < CountOfVertices - 1; ++i)
            {
                visited[currentVertex] = true;

                for (int j = 0; j < CountOfVertices; ++j)
                {
                    if (!visited[j] && MatrixOfConnections[currentVertex, j])
                    {
                        var newEdge = new Edge(MatrixOfLengths[currentVertex, j], Math.Min(currentVertex, j), Math.Max(currentVertex, j));
                        edges.Enqueue(newEdge, newEdge.Weight);
                    }
                }

                Edge maxEdge = null;
                while (maxEdge == null)
                {
                    try
                    {
                        var firstEdgeInQueue = edges.Dequeue();
                        if (!visited[firstEdgeInQueue.FirstVertex] || !visited[firstEdgeInQueue.SecondVertex])
                        {
                            maxEdge = firstEdgeInQueue;
                        }
                    }
                    catch (QueueIsEmptyException)
                    {
                        break;
                    }
                }

                if (maxEdge != null)
                {
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