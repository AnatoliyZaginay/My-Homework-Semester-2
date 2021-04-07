using NUnit.Framework;

namespace Task_2.Tests
{
    [TestFixture]
    public class UniqueListTests
    {
        private UniqueList list;

        [SetUp]
        public void Setup()
        {
            list = new UniqueList();
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
        }

        [Test]
        public void AddShouldThrowExceptionIfListAlreadyContainsValue()
            => Assert.Throws<ElementAlreadyExistsException>(() => list.Add(1, 1));

        [Test]
        public void ChangeValueShouldThrowExceptionIfListAlreadyContainsValue()
            => Assert.Throws<ElementAlreadyExistsException>(() => list.ChangeValue(1, 1));
    }
}
