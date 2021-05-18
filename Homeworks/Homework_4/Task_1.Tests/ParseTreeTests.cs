using NUnit.Framework;
using System.Collections.Generic;

namespace Task_1.Tests
{
    [TestFixture]
    public class ParseTreeTests
    {
        [Test]
        public void ParseTreeShouldThrowExceptionIfExpressionIsIncorrect()
        {
            ParseTree tree = null;
            Assert.Throws<System.ArgumentException>(() => tree = new ParseTree("( ! 1 2 )"));
        }

        [TestCaseSource(nameof(Expressions))]
        public void CalculateShouldWorkCorrectly(string expression, int expectedResult)
        {
            var tree = new ParseTree(expression);
            Assert.AreEqual(expectedResult, tree.Calculate());
        }

        [Test]
        public void CalculateShouldThrowExceptionInCaseOfDivisionByZero()
        {
            var tree = new ParseTree("( / 1 0 )");
            Assert.Throws<System.DivideByZeroException>(() => tree.Calculate());
        }

        [TestCaseSource(nameof(Expressions))]
        public void PrintShouldWorkCorrectly(string expression, int expectedResult)
        {
            var tree = new ParseTree(expression);
            Assert.AreEqual(expression, tree.Print());
        }

        private static IEnumerable<object[]> Expressions()
        {
            yield return new object[] { "( - 150 ( * 25 ( + 7 ( / -32 16 ) ) ) )", 25 };
            yield return new object[] { "( * ( / 4 2 ) ( + ( - -3 -9 ) 8 ) )", 28 };
        }
    }
}