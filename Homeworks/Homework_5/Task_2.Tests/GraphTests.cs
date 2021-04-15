using NUnit.Framework;

namespace Task_2.Tests
{
    [TestFixture]
    public class GraphTests
    {
        private int[,] expectedGraphLengths =
        {
            { 0, 5, 7, 0, 0 },
            { 5, 0, 0, 8, 0 },
            { 7, 0, 0, 9, 10 },
            { 0, 8, 9, 0, 0 },
            { 0, 0, 10, 0, 0 }
        };

        private bool[,] expectedGraphConnections =
        {
            { true, true, true, false, false },
            { true, true, false, true, false },
            { true, false, true, true, true },
            { false, true, true, true, false },
            { false, false, true, false, true }
        };

        private int[,] expectedSpanningTreeLengths =
        {
            { 0, 0, 7, 0, 0 },
            { 0, 0, 0, 8, 0 },
            { 7, 0, 0, 9, 10 },
            { 0, 8, 9, 0, 0 },
            { 0, 0, 10, 0, 0 }
        };

        private bool[,] expectedSpanningTreeConnections =
        {
            { true, false, true, false, false },
            { false, true, false, true, false },
            { true, false, true, true, true },
            { false, true, true, true, false },
            { false, false, true, false, true }
        };

        private Graph graph = new Graph("../../../Graph.txt");

        private Graph notConnectedGraph = new Graph("../../../NotConnectedGraph.txt");

        [Test]
        public void ReadGraphShouldWorkCorrectly()
        {
            Assert.AreEqual(expectedGraphConnections, graph.MatrixOfConnections);
            Assert.AreEqual(expectedGraphLengths, graph.MatrixOfLengths);
        }

        [Test]
        public void WriteGraphShouldWorkCorrectly()
        {
            graph.WriteToFile("../../../WriteGraphResult.txt");
            Assert.IsTrue(FileComparator.FilesAreEqual("../../../Graph.txt", "../../../WriteGraphResult.txt"));
        }

        [Test]
        public void IsConnectedTest()
        {
            Assert.IsTrue(graph.IsConnected());
            Assert.IsFalse(notConnectedGraph.IsConnected());
        }

        [Test]
        public void MakeMaximumSpanningTreeTest()
        {
            var spanningTree = graph.MakeMaximumSpanningTree();
            Assert.AreEqual(expectedSpanningTreeConnections, spanningTree.MatrixOfConnections);
            Assert.AreEqual(expectedSpanningTreeLengths, spanningTree.MatrixOfLengths);
        }
    }
}