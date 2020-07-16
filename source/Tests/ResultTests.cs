using NUnit.Framework;
using Octopus.Data;

namespace Tests
{
    [TestFixture]
    public class ResultTests
    {
        [Test]
        public void CheckFailureWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(true);
            if (result is FailureResult fail)
            {
                Assert.AreEqual("Some failure reason", fail.ErrorString);
            }
        }

        [Test]
        public void CheckFailureWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(true);
            if (result is Result<TestObjectBeingReturned> success)
            {
                Assert.Fail("This result wasn't a success case!");
            }
        }

        [Test]
        public void CheckSuccessWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(false);
            if (result is Result<TestObjectBeingReturned> success)
            {
                Assert.AreEqual("Some Name", success.Value.Name);
            }
        }

        [Test]
        public void CheckSuccessWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(false);
            if (result is FailureResult fail)
            {
                Assert.Fail("This result wasn't a failure case!");
            }
        }


        [Test]
        public void CheckSuccessWithNullableType()
        {
            var result = new TestClassWithResultMethod().DoSomething(false);
            if (result is Result<TestObjectBeingReturned?> success)
            {
                Assert.AreEqual("Some Name", success.Value?.Name);
            }
        }

        class TestClassWithResultMethod
        {
            public IResult<TestObjectBeingReturned> DoSomething(bool fail)
            {
                if (fail)
                    return Result<TestObjectBeingReturned>.Failed("Some failure reason");
                return Result<TestObjectBeingReturned>.Success(new TestObjectBeingReturned("Some Name"));
            }
        }

        class TestObjectBeingReturned
        {
            public TestObjectBeingReturned(string name)
            {
                Name = name;
            }

            public string Name { get; }
        }
    }
}