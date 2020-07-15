using System;
using NUnit.Framework;
using Octopus.Data.Model;

namespace Tests
{
    [TestFixture]
    public class SensitiveStringTests
    {
        [Test]
        public void ComparingSensitiveStringPointersAreEqualWorks()
        {
            var a = "Test Value".ToSensitiveString();
            var b = "Test Value".ToSensitiveString();

            Assert.IsTrue(a == b);
        }

        [Test]
        public void ComparingSensitiveStringPointersAreNotEqualWorks()
        {
            var a = "Test Value".ToSensitiveString();
            var b = "Test Value2".ToSensitiveString();

            Assert.IsTrue(a != b);
        }

        [Test]
        public void ComparingSensitiveStringsToEqualOperatorStringWorks()
        {
            var a = "Test Value".ToSensitiveString();

            Assert.IsTrue(a == "Test Value");
        }

        [Test]
        public void ComparingSensitiveStringsToEqualMethodStringWorks()
        {
            var a = "Test Value".ToSensitiveString();

            Assert.IsTrue(a.Equals("Test Value"));
        }

        [Test]
        public void ComparingSensitiveStringsToNotEqualStringWorks()
        {
            var a = "Test Value".ToSensitiveString();

            Assert.IsTrue(a != "Test Value2");
        }

        [Test]
        public void ComparingSensitiveStringsToNullWorks()
        {
            var a = "Test Value".ToSensitiveString();

            Assert.IsFalse(a == null);
        }

        [Test]
        public void ComparingNullSensitiveStringsToNullWorks()
        {
            SensitiveString? a = null;

            Assert.IsTrue(a == null);
        }
    }
}