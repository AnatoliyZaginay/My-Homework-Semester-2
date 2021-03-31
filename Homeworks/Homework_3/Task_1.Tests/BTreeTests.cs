using NUnit.Framework;
using System.Collections.Generic;

namespace Task_1.Tests
{
    [TestFixture]
    public class Tests
    {
        private BTree tree = new BTree(2);

        private string[] array = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

        [SetUp]
        public void Setup()
        {
            foreach (string symbol in array)
            {
                tree.Insert(symbol, symbol);
            }
        }

        [Test]
        public void TreeShouldContainInsertedKeys()
        {
            foreach (string symbol in array)
            {
                Assert.IsTrue(tree.Contains(symbol));
            }
        }

        [Test]
        public void GetValueShouldReturnCorrectValues()
        {
            foreach (string symbol in array)
            {
                Assert.AreEqual(tree.GetValue(symbol), symbol);
            }
            Assert.Throws<System.ArgumentException>(() => tree.GetValue("invalidKey"));
        }

        [Test]
        public void ValueShouldBeChangedAfterChangingValue()
        {
            tree.ChangeValue("d", "root");
            tree.ChangeValue("f", "internalNode");
            tree.ChangeValue("i", "leaf");
            Assert.AreEqual(tree.GetValue("d"), "root");
            Assert.AreEqual(tree.GetValue("f"), "internalNode");
            Assert.AreEqual(tree.GetValue("i"), "leaf");

            Assert.Throws<System.ArgumentException>(() => tree.ChangeValue("invalidKey", "invalidValue"));
        }

        [Test]
        public void InsertingExistingKeyShouldChangeValue()
        {
            tree.Insert("d", "root");
            tree.Insert("b", "internalNode");
            tree.Insert("a", "leaf");
            Assert.AreEqual(tree.GetValue("d"), "root");
            Assert.AreEqual(tree.GetValue("b"), "internalNode");
            Assert.AreEqual(tree.GetValue("a"), "leaf");
        }

        [TestCaseSource(nameof(TestDataForDeletion))]
        public void TreeShouldNotContainKeyAfterDeletion(string key)
        {
            tree.Delete(key);
            foreach (string symbol in array)
            {
                if (symbol == key)
                {
                    Assert.IsFalse(tree.Contains(symbol));
                    continue;
                }
                Assert.IsTrue(tree.Contains(symbol));
            }
        }

        [Test]
        public void DeleteShouldThrowExceptionIfKeyIsNotConatinedInTree()
            => Assert.Throws<System.ArgumentException>(() => tree.Delete("invalidKey"));

        [Test]
        public void DeletingEntireTreeTest()
        {
            foreach (string symbol in array)
            {
                Assert.IsTrue(tree.Contains(symbol));
                tree.Delete(symbol);
                Assert.IsFalse(tree.Contains(symbol));
            }

            Assert.Throws<System.InvalidOperationException>(() => tree.Delete("invalidKey"));
        }

        private static IEnumerable<string> TestDataForDeletion()
        {
            yield return "a";
            yield return "b";
            yield return "c";
            yield return "d";
            yield return "e";
            yield return "f";
            yield return "g";
            yield return "h";
            yield return "i";
            yield return "j";
        }
    }
}