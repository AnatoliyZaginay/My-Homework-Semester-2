using NUnit.Framework;
using System.IO;

namespace Task_2.Tests
{
    [TestFixture]
    public class RoutersTests
    {
        [Test]
        public void ConnectedGraphTest()
        {
            Routers.MakeOptimalNetwork("../../../ConnectedGraph.txt", "../../../ConnectedGraphResult.txt");
            Assert.IsTrue(FileComparator.FilesAreEqual("../../../Expected.txt", "../../../ConnectedGraphResult.txt"));
        }

        [Test]
        public void NotConnectedGraphTest()
            => Assert.Throws<GraphIsNotConnectedException>(() => Routers.MakeOptimalNetwork("../../../NotConnectedGraph.txt", "../../../NotConnectedGraphResult.txt"));
    }
}