﻿using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Helper
{
    [TestFixture]
    public class ArgumentCheckUnitTests : TestFixture
    {
        [Test]
        public void IsNotNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArgumentCheck.IsNotNull(null));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull("this is a test"));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull(string.Empty));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull(1));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull(0));
        }

        [Test]
        public void IsNotNullWithParam()
        {
            Assert.Throws<ArgumentNullException>(() => ArgumentCheck.IsNotNull(null, "param"));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull("this is a test"), "param");
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull(string.Empty), "param");
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull(1), "param");
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotNull(0), "param");
        }

        [Test]
        public void IsNotEmpty()
        {
            Assert.Throws<ArgumentException>(() => ArgumentCheck.IsNotEmpty(string.Empty));
            Assert.Throws<ArgumentException>(() => ArgumentCheck.IsNotEmpty(""));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotEmpty(null));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotEmpty("this is a test"));
        }

        [Test]
        public void IsNotEmptyWithParam()
        {
            Assert.Throws<ArgumentException>(() => ArgumentCheck.IsNotEmpty(string.Empty, "param"));
            Assert.Throws<ArgumentException>(() => ArgumentCheck.IsNotEmpty("", "param"));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotEmpty(null, "param"));
            Assert.DoesNotThrow(() => ArgumentCheck.IsNotEmpty("this is a test", "param"));
        }

        [Test]
        public void IsTypeOfNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArgumentCheck.IsTypeOf<TestFixture>(null));
        }

        [Test]
        public void IsTypeOfBaseClass()
        {
            Assert.DoesNotThrow(() => ArgumentCheck.IsTypeOf<TestFixture>(typeof(ArgumentCheckUnitTests)));
        }

        [Test]
        public void IsTypeOfChildType()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => ArgumentCheck.IsTypeOf<ArgumentCheckUnitTests>(typeof(TestFixture)));
            Assert.That(ex.Message, Is.StringContaining(typeof(ArgumentCheckUnitTests).FullName));
            Assert.That(ex.Message, Is.StringContaining(typeof(TestFixture).FullName));
        }


        [Test]
        public void IsTypeOfWrongType()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => ArgumentCheck.IsTypeOf<int>(typeof(Guid)));
            Assert.That(ex.Message, Is.StringContaining(typeof(int).FullName));
            Assert.That(ex.Message, Is.StringContaining(typeof(Guid).FullName));
        }
    }
}