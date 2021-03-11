using NUnit.Framework;

namespace Task_1.Tests
{
    [TestFixture]
    public class TrieTests
    {
        Trie trie;

        [SetUp]
        public void Setup()
        {
            trie = new Trie();
        }

        [Test]
        public void TrieShouldContainsAllByteCodesAfterCreating()
        {
            for (int i = 0; i < 256; ++i)
            {
                Assert.IsTrue(trie.PointerContains((byte)i));
            }
            Assert.IsTrue(trie.CurrentCode == 255);
        }

        [Test]
        public void PointerCodeShouldChangeAfterMovingPointer()
        {
            Assert.IsTrue(trie.PointerCode == 0);
            trie.MovePointer(100);
            Assert.IsTrue(trie.PointerCode == 100);
        }

        [Test]
        public void CurrentCodeShouldChangeAfterAddingNewElementToTrie()
        {
            trie.MovePointer(0);
            Assert.IsTrue(trie.CurrentCode == 255);
            trie.Add(0);
            Assert.IsTrue(trie.CurrentCode == 256);
        }

        [Test]
        public void NewElementShouldBeCreatedAfterAdding()
        {
            trie.MovePointer(0);
            Assert.IsFalse(trie.PointerContains(0));
            trie.Add(0);
            Assert.IsTrue(trie.PointerCode == 0);
            Assert.IsTrue(trie.PointerContains(0));
            trie.MovePointer(0);
            Assert.IsTrue(trie.PointerCode == 256);
        }

        [Test]
        public void PointerShouldBeMovedToFirstElementWithSameByteCodeAfterAdding()
        {
            trie.MovePointer(0);
            trie.Add(100);
            Assert.IsTrue(trie.PointerCode == 100);
        }
    }
}