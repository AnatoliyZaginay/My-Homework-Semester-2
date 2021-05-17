using NUnit.Framework;
using System;

namespace Task_1.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new();
        }

        [TestCase("1 + 1 =", "2", "+", 2, 1)]
        [TestCase("1 + 1", "1", "+", 1, 1)]
        [TestCase("1 - 1 +", "0", "+", 0, 0)]
        [TestCase("1 / 0 =", "Division by zero", "/", 0, 0)]
        [TestCase("1 2 / 3 =", "4", "/", 4, 3)]
        [TestCase("1 2 * 1 0 =", "120", "*", 120, 10)]
        [TestCase("1 2 * 1 0 = =", "1200", "*", 1200, 10)]
        [TestCase("1 2 * 1 0 = * =", "14400", "*", 14400, 120)]
        [TestCase("1 2 ± ± + 10 ± =", "2", "+", 2, -10)]
        [TestCase("5 * 5 = 0 , 5 =", "2,5", "*", 2.5, 5)]
        [TestCase("1 , 0 0 1 - 0 , 0 1 1 =", "0,99", "-", 0.99, 0.011)]
        [TestCase("1 2 3 4 ⌫", "123", null, 123, 0)]
        [TestCase("1 2 3 4 ⌫ 5 , 1 2 3 ⌫ + 1 ⌫ , 0 2 ⌫ 8 =", "1235,2", "+", 1235.2, 0.08)]
        [TestCase("1 0 0 5 ⌫ 2 , 2 0 5 - , 2 0 6 ⌫ 5 = + 5 = =", "1012", "+", 1012, 5)]
        [TestCase("1 2 , 4 * CE", "0", "*", 12.4, 0)]
        [TestCase("5 * 5 = CE 4 =", "20", "*", 20, 5)]
        [TestCase("5 * 5 = CE 4 =", "20", "*", 20, 5)]
        [TestCase("5 * 5 / C", "0", null, 0, 0)]
        public void CalculatorTest(string expression, string expectedResult, string expectedOperation, decimal expectedFirstNumber, decimal expectedSecondNumber)
        {
            var elements = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var element in elements)
            {
                calculator.AddElement(element);
            }
            Assert.AreEqual(expectedResult, calculator.CurrentValue);
            Assert.AreEqual(expectedOperation, calculator.Operation);
            Assert.AreEqual(expectedFirstNumber, calculator.FirstNumber);
            Assert.AreEqual(expectedSecondNumber, calculator.SecondNumber);
        }
    }
}