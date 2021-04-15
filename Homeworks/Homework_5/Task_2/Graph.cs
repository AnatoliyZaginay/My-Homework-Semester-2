using System;
using System.Collections.Generic;
using System.IO;

namespace Task_2
{
    public class Graph
    {
        public int[,] MatrixOfLengths { get; }

        public bool[,] MatrixOfConnections { get; }

        public int CountOfVertexes { get; }

        public Graph(int[,] matrixOfLengths, bool[,] matrixOfConnections)
        {
            if (matrixOfConnections == null || matrixOfLengths == null || matrixOfConnections.Length != matrixOfLengths.Length ||
                matrixOfConnections.GetLength(0) != matrixOfConnections.GetLength(1) || matrixOfLengths.GetLength(0) != matrixOfLengths.GetLength(1))
            {
                throw new ArgumentException();
            }
            MatrixOfLengths = matrixOfLengths;
            MatrixOfConnections = matrixOfConnections;
            CountOfVertexes = matrixOfLengths.GetLength(0);
        }

        public Graph(string path)
        {
            (int[,] matrixOfLengths, bool[,] matrixOfConnections) = ReadGraphFromFile(path);

            if (matrixOfConnections == null || matrixOfLengths == null)
            {
                throw new ArgumentException();
            }

            MatrixOfLengths = matrixOfLengths;
            MatrixOfConnections = matrixOfConnections;
            CountOfVertexes = matrixOfLengths.GetLength(0);
        }

        private static int[][] GetGraphInfo(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException();
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
                        throw new ArgumentException();
                    }
                }
            }

            return graphInfo;
        }

        private static int GetCountOfVertexes(int[][] graphInfo)
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
                throw new ArgumentException();
            }

            return maximumNumber;
        }
        private static (int[,], bool[,]) ReadGraphFromFile(string path)
        {
            var graphInfo = GetGraphInfo(path);
            var countOfVertexes = GetCountOfVertexes(graphInfo);
            var matrixOfLengths = new int[countOfVertexes, countOfVertexes];
            var matrixOfConnections = new bool[countOfVertexes, countOfVertexes];

            for (int i = 0; i < countOfVertexes; ++i)
            {
                matrixOfConnections[i, i] = true;
            }

            for (int i = 0; i < graphInfo.GetLength(0); ++i)
            {
                for (int j = 1; j < graphInfo[i].Length - 1; j += 2)
                {
                    if (graphInfo[i][0] <= 0 || graphInfo[i][0] > countOfVertexes ||
                        graphInfo[i][j] <= 0 || graphInfo[i][j] > countOfVertexes)
                    {
                        throw new ArgumentException();
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

        public void WriteGraphToFile(string path)
        {
            using var file = new StreamWriter(path);
            
            for (int i = 0; i < CountOfVertexes; ++i)
            {
                string line = "";

                for (int j = i + 1; j < CountOfVertexes; ++j)
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
