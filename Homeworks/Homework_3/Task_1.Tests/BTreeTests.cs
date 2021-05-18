using NUnit.Framework;
using System.Collections.Generic;

namespace Task_1.Tests
{
    [TestFixture]
    public class Tests
    {
        private BTree tree;

        private static string[] symbols = "a b c d e f g h i j k l m n o p q r s t u v w x y z".Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

        private void InitializeTree(BTree tree)
        {
            foreach (var symbol in symbols)
            {
                tree.Insert(symbol, symbol);
            }
        }

        [TestCaseSource(nameof(TreeDegrees))]
        public void TreeShouldContainInsertedKeys(int degree)
        {
            tree = new(degree);
            InitializeTree(tree);

            foreach (var symbol in symbols)
            {
                Assert.IsTrue(tree.Contains(symbol));
            }
        }

        [TestCaseSource(nameof(TreeDegrees))]
        public void GetValueShouldReturnCorrectValues(int degree)
        {
            tree = new(degree);
            InitializeTree(tree);

            foreach (string symbol in symbols)
            {
                Assert.AreEqual(symbol, tree.GetValue(symbol));
            }
            Assert.Throws<System.ArgumentException>(() => tree.GetValue("invalidKey"));
        }

        [TestCaseSource(nameof(TreeDegrees))]
        public void ValueShouldBeChangedAfterChangingValue(int degree)
        {
            tree = new(degree);
            InitializeTree(tree);

            tree.ChangeValue("o", "o2");
            tree.ChangeValue("d", "d2");
            tree.ChangeValue("h", "h2");
            tree.ChangeValue("i", "i2");
            Assert.AreEqual("o2", tree.GetValue("o"));
            Assert.AreEqual("d2", tree.GetValue("d"));
            Assert.AreEqual("h2", tree.GetValue("h"));
            Assert.AreEqual("i2", tree.GetValue("i"));

            Assert.Throws<System.ArgumentException>(() => tree.ChangeValue("invalidKey", "invalidValue"));
        }

        [TestCaseSource(nameof(TreeDegrees))]
        public void InsertingExistingKeyShouldChangeValue(int degree)
        {
            tree = new(degree);
            InitializeTree(tree);

            tree.ChangeValue("o", "o2");
            tree.ChangeValue("d", "d2");
            tree.ChangeValue("h", "h2");
            tree.ChangeValue("i", "i2");
            Assert.AreEqual("o2", tree.GetValue("o"));
            Assert.AreEqual("d2", tree.GetValue("d"));
            Assert.AreEqual("h2", tree.GetValue("h"));
            Assert.AreEqual("i2", tree.GetValue("i"));
        }

        [TestCaseSource(nameof(TestDataForDeletion))]
        public void TreeShouldNotContainKeyAfterDeletion(int degree, string key)
        {
            tree = new(degree);
            InitializeTree(tree);

            tree.Delete(key);
            foreach (string symbol in symbols)
            {
                if (symbol == key)
                {
                    Assert.IsFalse(tree.Contains(symbol));
                    continue;
                }
                Assert.IsTrue(tree.Contains(symbol));
            }
        }

        [TestCaseSource(nameof(TreeDegrees))]
        public void DeleteShouldThrowExceptionIfKeyIsNotConatinedInTree(int degree)
        {
            tree = new(degree);
            InitializeTree(tree);

            Assert.Throws<System.ArgumentException>(() => tree.Delete("invalidKey"));
        }

        [TestCaseSource(nameof(TreeDegrees))]
        public void DeletingEntireTreeTest(int degree)
        {
            tree = new(degree);
            InitializeTree(tree);

            foreach (string symbol in symbols)
            {
                Assert.IsTrue(tree.Contains(symbol));
                tree.Delete(symbol);
                Assert.IsFalse(tree.Contains(symbol));
            }

            Assert.Throws<System.InvalidOperationException>(() => tree.Delete("invalidKey"));
        }

        private static IEnumerable<int> TreeDegrees()
        {
            for (int i = 2; i < 15; ++i)
            {
                yield return i;
            }
        }

        private static IEnumerable<object[]> TestDataForDeletion()
        {
            for (int i = 2; i< 15; ++i)
            {
                foreach (var symbol in symbols)
                {
                    yield return new object[] { i, symbol };
                }
            }
        }
    }
}