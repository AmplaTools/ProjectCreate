﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Validation
{
    [TestFixture]
    public class NameIsUniqueValidationUnitTests : ValidationTestFixture<NameIsUniqueValidation>
    {
        protected override NameIsUniqueValidation Create(ValidationMessages messages)
        {
            return new NameIsUniqueValidation(messages);
        }

        [Test]
        public void ValidateNullItem()
        {
            Assert.Throws<ArgumentNullException>(() => Validation.Validate(null));
        }

        [Test]
        public void ValidateWithNoChildren()
        {
            Enterprise enterprise = new Enterprise();

            Assert.That(Validation.Validate(enterprise), Is.True);
            Assert.That(Messages, Is.Empty);
        }

        [Test]
        public void ValidateWithOneChild()
        {
            Enterprise enterprise = new Enterprise
                {
                    name = "Enterprise",
                };

            enterprise.Site.Add(new Site() {name="Area 1"});

            Assert.That(Validation.Validate(enterprise), Is.True);
            Assert.That(Messages, Is.Empty);
        }

        [Test]
        public void ValidateWithMultipleChildren()
        {
            Enterprise enterprise = new Enterprise
                {
                    name = "Enterprise",
                };

            enterprise.Site.Add(new Site("Site A"));
            enterprise.Site.Add(new Site("Site B"));
            enterprise.Site.Add(new Site("Site C"));

            Assert.That(Validation.Validate(enterprise), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[0]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[1]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[2]), Is.True);
            Assert.That(Messages, Is.Empty);
        }

        [Test]
        public void ValidateWithDuplicateChildren()
        {
            Enterprise enterprise = new Enterprise
                {
                    name = "Enterprise",
                };

            enterprise.Site.Add(new Site("Site A"));
            enterprise.Site.Add(new Site("Site B"));
            enterprise.Site.Add(new Site("Site A"));

            Assert.That(enterprise.GetCount(), Is.EqualTo(4));

            Assert.That(Validation.Validate(enterprise), Is.False);
            Assert.That(Messages.Count, Is.EqualTo(1));
            Assert.That(Messages[0].Message, Is.StringContaining("Site A"));

            Assert.That(Validation.Validate(enterprise.Site[0]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[1]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[2]), Is.True);
            Assert.That(Messages.Count, Is.EqualTo(1));
        }

        [Test]
        public void ValidateWithDuplicateCousins()
        {
            Enterprise enterprise = new Enterprise
                {
                    name = "Enterprise",
                };

            enterprise.Site.Add(new Site("Site A"));
            enterprise.Site.Add(new Site("Site B"));
            enterprise.Site.Add(new Site("Site C"));

            enterprise.Site[0].Area.Add(new Area("Area"));
            enterprise.Site[2].Area.Add(new Area("Area"));

            Assert.That(enterprise.GetCount(), Is.EqualTo(6));

            Assert.That(Validation.Validate(enterprise), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[0]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[0].Area[0]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[1]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[2]), Is.True);
            Assert.That(Validation.Validate(enterprise.Site[2].Area[0]), Is.True);
            Assert.That(Messages, Is.Empty);
        }
    }
}