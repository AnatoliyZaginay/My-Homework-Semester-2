using System;
using System.IO;

namespace Task_2
{
    /// <summary>
    /// Static class for working with a graph and a file.
    /// </summary>
    public static class GraphInFile
    {
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

        /// <summary>
        /// Returns adjacency matrices for distances and connections in the graph.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public static (int[,], bool[,]) ReadFromFile(string path)
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

        /// <summary>
        /// Writes the graph to a file as adjacency lists.
        /// </summary>
        /// <param name="graph">Specified graph.</param>
        /// <param name="path">Path to the file.</param>
        public static void WriteToFile(Graph graph, string path)
        {
            using var file = new StreamWriter(path);

            for (int i = 0; i < graph.CountOfVertices; ++i)
            {
                string line = "";

                for (int j = i + 1; j < graph.CountOfVertices; ++j)
                {
                    if (graph.MatrixOfConnections[i, j])
                    {
                        line += $" {j + 1} ({graph.MatrixOfLengths[i, j]}),";
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