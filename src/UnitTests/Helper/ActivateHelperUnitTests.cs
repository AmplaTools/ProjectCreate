using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Helper
{
    [TestFixture]
    public class ActivateHelperUnitTests : TestFixture
    {
        [Test]
        public void ActivateT()
        {
            Assert.That(ActivateHelper.Activate<int>(), Is.TypeOf<int>());
            Assert.That(ActivateHelper.Activate<TestClass1>(), Is.TypeOf<TestClass1>());
        }

        [Test]
        public void ActivateType()
        {
            Assert.That(ActivateHelper.Activate(typeof(int)), Is.TypeOf<int>());
            Assert.That(ActivateHelper.Activate(typeof(TestClass1)), Is.TypeOf<TestClass1>());
        }

        [Test]
        public void ActivateNull()
        {
            Assert.Throws<ArgumentNullException>(()=>ActivateHelper.Activate(null));
        }


        [Test]
        public void ActivateNoDefaultConstuctor()
        {
            Assert.Throws<MissingMethodException>(() => ActivateHelper.Activate(typeof(TestClass2)));
        }

        public class TestClass1
        {
        }

        public class TestClass2
        {
            public TestClass2(string message)
            {
                Message = message;
            }

            protected string Message { get; private set; }
        }
    }
}