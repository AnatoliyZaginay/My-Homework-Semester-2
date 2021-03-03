using NUnit.Framework;
using System.Collections.Generic;

namespace Task_2.Tests
{
    [TestFixture]
    public class StackTests
    {
        [TestCaseSource(nameof(StackTypes))]
        public void EmptyStackIsEmptyShouldBeTrue(IStack stack)
            => Assert.IsTrue(stack.Empty);

        [TestCaseSource(nameof(StackTypes))]
        public void StackShouldNotBeEmptyAfterPush(IStack stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.Empty);
        }

        [TestCaseSource(nameof(StackTypes))]
        public void PopShouldReturnPushedValue(IStack stack)
        {
            stack.Push(10);
            Assert.AreEqual(10, stack.Pop());
        }

        [TestCaseSource(nameof(StackTypes))]
        public void PopShouldReturnAllPushedValues(IStack stack)
        {
            stack.Push(5);
            stack.Push(10);
            Assert.AreEqual((10, 5), (stack.Pop(), stack.Pop()));
        }

        [TestCaseSource(nameof(StackTypes))]
        public void PopShouldThrowExceptionIfStackIsEmpty(IStack stack)
            => Assert.Throws<System.NullReferenceException>(() => stack.Pop());

        private static IEnumerable<IStack> StackTypes()
        {
            yield return new ArrayStack();
            yield return new ListStack();
        }
    }
}