using NUnit.Framework;

namespace Task_2.Tests
{
    [TestFixture]
    public class GraphInFileTests
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

        private Graph graph = new Graph("../../../Graph.txt");

        [Test]
        public void ReadFromFileShouldWorkCorrectly()
        {
            (int[,] matrixOfLengths, bool[,] matrixOfConnections) = GraphInFile.ReadFromFile("../../../Graph.txt");
            Assert.AreEqual(expectedGraphConnections, matrixOfConnections);
            Assert.AreEqual(expectedGraphLengths, matrixOfLengths);
        }

        [Test]
        public void WriteGraphShouldWorkCorrectly()
        {
            GraphInFile.WriteToFile(graph, "../../../WriteGraphResult.txt");
            Assert.IsTrue(FileComparator.FilesAreEqual("../../../Graph.txt", "../../../WriteGraphResult.txt"));
        }
    }
}