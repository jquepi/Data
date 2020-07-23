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
            if (result is IFailureResult fail)
            {
                Assert.AreEqual("Some failure reason", fail.ErrorString);
            }
        }

        [Test]
        public void CheckFailureWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(true);
            if (result is ISuccessResult<TestObjectBeingReturned> success)
            {
                Assert.Fail("This result wasn't a success case!");
            }
        }

        [Test]
        public void CheckSuccessWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(false);
            if (result is ISuccessResult<TestObjectBeingReturned> success)
            {
                Assert.AreEqual("Some Name", success.Value.Name);
            }
        }

        [Test]
        public void CheckSuccessWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(false);
            if (result is IFailureResult fail)
            {
                Assert.Fail("This result wasn't a failure case!");
            }
        }

        [Test]
        public void CheckSuccessWithNullableType()
        {
            var result = new TestClassWithResultMethod().DoSomething(false);
            if (result is ISuccessResult<TestObjectBeingReturned?> success)
            {
                Assert.AreEqual("Some Name", success.Value?.Name);
            }
        }

        [Test]
        public void CheckSuccessNoObjectWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(false);
            if (result is IFailureResult fail)
            {
                Assert.Fail("This result wasn't a failure case!");
            }
        }


        [Test]
        public void CheckSuccessNoObjectWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(false);
            if (result is ISuccessResult success)
                Assert.Pass("This was a success");
            else
                Assert.Fail("This should have been a success");
        }

        class TestClassWithResultMethod
        {
            public IResult<TestObjectBeingReturned> DoSomething(bool fail)
            {
                if (fail)
                    return Result<TestObjectBeingReturned>.Failed("Some failure reason");
                return Result<TestObjectBeingReturned>.Success(new TestObjectBeingReturned("Some Name"));
            }

            public IResult DoSomethingWithNoObjectToReturn(bool fail)
            {
                if (fail)
                    return Result.Failed("Some failure reason");
                return Result.Success();
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