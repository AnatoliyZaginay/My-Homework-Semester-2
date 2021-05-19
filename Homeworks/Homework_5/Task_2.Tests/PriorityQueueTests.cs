using NUnit.Framework;

namespace Task_2.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        private PriorityQueue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new();
        }

        [Test]
        public void EmptyPriorityQueueShouldThrowExceptionWhenDequeued()
            => Assert.Throws<QueueIsEmptyException>(() => queue.Dequeue());

        [Test]
        public void EqueueAndDequeueShouldWorkCorrectly()
        {
            queue.Enqueue(4, 4);
            queue.Enqueue(5, 5);
            queue.Enqueue(2, 1);
            queue.Enqueue(3, 3);
            queue.Enqueue(1, 1);

            for (int i = 5; i > 0; i--)
            {
                Assert.AreEqual(i, queue.Dequeue());
            }
        }
    }
}