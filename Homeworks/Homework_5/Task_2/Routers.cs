﻿using System;

namespace Task_2
{
    /// <summary>
    /// Static class for working with network graph of routers connections.
    /// </summary>
    public static class Routers
    {
        /// <summary>
        /// Creates the most optimal network structure for a given network.
        /// </summary>
        /// <param name="inputFilePath">Path to the input file (given network).</param>
        /// <param name="outputFilePath">Path to the output file (optimal network).</param>
        public static void MakeOptimalNetwork(string inputFilePath, string outputFilePath)
        {
            var network = new Graph(inputFilePath);

            if (!network.IsConnected())
            {
                throw new GraphIsNotConnectedException("Network is not connected");
            }

            var optimalNetwork = network.MakeMaximumSpanningTree();
            GraphInFile.WriteToFile(optimalNetwork, outputFilePath);
        }
    }
}