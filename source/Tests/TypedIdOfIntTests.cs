using NUnit.Framework;
using Octopus.Data.Model;

namespace Tests
{
    [TestFixture]
    public class TypedIdOfIntTests
    {
        [Test]
        public void CanCompareUserIdToString()
        {
            var obj = new TestObject(new TestId(10));
            Assert.IsTrue(obj.Id == 10);
        }

        [Test]
        public void CanCompareUserIdToAnotherUserId()
        {
            var obj = new TestObject(new TestId(10));
            Assert.IsTrue(obj.Id == new TestId(10));
        }

        class TestId : TypedId<int>
        {
            public TestId(int value) : base(value)
            {
            }
        }

        class TestObject : IId<TestId>
        {
            public TestObject(TestId id)
            {
                Id = id;
            }

            public TestId Id { get; }
        }

    }
}