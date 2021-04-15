using System;
using System.Collections.Generic;
using System.IO;

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
            (int[,] matrixOfLengths, bool[,] matrixOfConnections) = ReadFromFile(path);

            if (matrixOfConnections == null || matrixOfLengths == null)
            {
                throw new ArgumentException("Graph matrix is empty");
            }

            MatrixOfLengths = matrixOfLengths;
            MatrixOfConnections = matrixOfConnections;
            CountOfVertices = matrixOfLengths.GetLength(0);
        }

        private static int[][] GetGraphInfo(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("File not exists");
            }
            var lines = File.ReadAllLines(path);

            char[] separationSymbols = { ' ', ':', ',', '(', ')' };
            var arraysOfNumbers = new string[lines.Length][];
            var graphInfo = new int[lines.Length][];

            for (int i = 0; i < lines.Length; ++i)
            {
                arraysOfNumbers[i] = lines[i].Split(separationSymbols, StringSplitOptions.RemoveEmptyEntries);
                graphInfo[i] = new int[arraysOfNumbers[i].Length];

                for (int j = 0; j < arraysOfNumbers[i].Length; ++j)
                {
                    if (int.TryParse(arraysOfNumbers[i][j], out int value))
                    {
                        graphInfo[i][j] = value;
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect input data type");
                    }
                }
            }

            return graphInfo;
        }

        private static int GetCountOfVertices(int[][] graphInfo)
        {
            int maximumNumber = 0;
            for (int i = 0; i < graphInfo.GetLength(0); ++i)
            {
                if (graphInfo[i][0] > maximumNumber)
                {
                    maximumNumber = graphInfo[i][0];
                }
                for (int j = 1; j < graphInfo[i].Length; j += 2)
                {
                    if (graphInfo[i][j] > maximumNumber)
                    {
                        maximumNumber = graphInfo[i][j];
                    }
                }
            }

            if (maximumNumber == 0)
            {
                throw new ArgumentException("Incorrect vertex number");
            }

            return maximumNumber;
        }
        private static (int[,], bool[,]) ReadFromFile(string path)
        {
            var graphInfo = GetGraphInfo(path);
            var countOfVertices = GetCountOfVertices(graphInfo);
            var matrixOfLengths = new int[countOfVertices, countOfVertices];
            var matrixOfConnections = new bool[countOfVertices, countOfVertices];

            for (int i = 0; i < countOfVertices; ++i)
            {
                matrixOfConnections[i, i] = true;
            }

            for (int i = 0; i < graphInfo.GetLength(0); ++i)
            {
                for (int j = 1; j < graphInfo[i].Length - 1; j += 2)
                {
                    if (graphInfo[i][0] <= 0 || graphInfo[i][0] > countOfVertices ||
                        graphInfo[i][j] <= 0 || graphInfo[i][j] > countOfVertices)
                    {
                        throw new ArgumentException("Incorrect vertex number");
                    }

                    matrixOfConnections[graphInfo[i][0] - 1, graphInfo[i][j] - 1] = true;
                    matrixOfConnections[graphInfo[i][j] - 1, graphInfo[i][0] - 1] = true;
                    matrixOfLengths[graphInfo[i][0] - 1, graphInfo[i][j] - 1] = graphInfo[i][j + 1];
                    matrixOfLengths[graphInfo[i][j] - 1, graphInfo[i][0] - 1] = graphInfo[i][j + 1];
                }
            }

            return (matrixOfLengths, matrixOfConnections);
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

            for (int i = 0; i < CountOfVertices; ++i)
            {
                if (!visited[i])
                {
                    return false;
                }
            }
            return true;
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

            var edges = new List<Edge>();
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
                        edges.Add(newEdge);
                    }
                }

                Edge maxEdge = null;
                foreach (var edge in edges)
                {
                    if ((!visited[edge.FirstVertex] || !visited[edge.SecondVertex]) && (maxEdge == null || edge.Weight > maxEdge.Weight))
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

        /// <summary>
        /// Writes the graph to a file as adjacency lists.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public void WriteToFile(string path)
        {
            using var file = new StreamWriter(path);
            
            for (int i = 0; i < CountOfVertices; ++i)
            {
                string line = "";

                for (int j = i + 1; j < CountOfVertices; ++j)
                {
                    if (MatrixOfConnections[i, j])
                    {
                        line += $" {j + 1} ({MatrixOfLengths[i, j]}),";
                    }
                }

                if (line != "")
                {
                    line = line.Remove(line.Length - 1);
                    line = $"{i + 1}:" + line;
                    file.WriteLine(line);
                }
            }
        }
    }
}