using NUnit.Framework;
using System.Collections.Generic;

namespace Task_2.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCaseSource(nameof(CalculatorType))]
        public void SumTest(Calculator calculator)
            => Assert.AreEqual(14, calculator.Calculate("11 3 +"));

        [TestCaseSource(nameof(CalculatorType))]
        public void SubtractionTest(Calculator calculator)
            => Assert.AreEqual(12, calculator.Calculate("15 3 -"));

        [TestCaseSource(nameof(CalculatorType))]
        public void MultiplicationTest(Calculator calculator)
            => Assert.AreEqual(33, calculator.Calculate("11 3 *"));

        [TestCaseSource(nameof(CalculatorType))]
        public void DivisionTest(Calculator calculator)
            => Assert.AreEqual(5, calculator.Calculate("60 12 /"));

        [TestCaseSource(nameof(CalculatorType))]
        public void ComplexExpressionTest(Calculator calculator)
            => Assert.AreEqual(2, calculator.Calculate("8 2 + 6 * 12 / 3 -"));

        [TestCaseSource(nameof(CalculatorType))]
        public void DivisionByZeroTest(Calculator calculator)
            => Assert.Throws<System.DivideByZeroException>(() => calculator.Calculate("10 0 /"));

        [TestCaseSource(nameof(CalculatorType))]
        public void NotEnoughNumbersTest(Calculator calculator)
            => Assert.Throws<System.NullReferenceException>(() => calculator.Calculate("5 +"));

        [TestCaseSource(nameof(CalculatorType))]
        public void NotEnoughOperationsTest(Calculator calculator)
            => Assert.Throws<System.ArithmeticException>(() => calculator.Calculate("10 3 4 +"));

        [TestCaseSource(nameof(CalculatorType))]
        public void WrongSymbolTest(Calculator calculator)
            => Assert.Throws<System.ArgumentException>(() => calculator.Calculate("10 A +"));

        private static IEnumerable<Calculator> CalculatorType()
        {
            yield return new Calculator(new ArrayStack());
            yield return new Calculator(new ListStack());
        }
    }
}