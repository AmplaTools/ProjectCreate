using System;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Models.EquipmentModel
{
    [TestFixture]
    public class EquipmentUnitTests : TestFixture
    {
        [Test]
        public void EquipmentItem()
        {
            Equipment item = new Equipment();
            Assert.That(item.name, Is.EqualTo("Equipment"));
            Assert.That(item.id, Is.Null);
            Assert.That(item.Items, Is.Empty);
        }

        [Test]
        public void ItemCollection()
        {
            Equipment item = new Equipment();
            Assert.That(item.Items, Is.InstanceOf<ItemCollection<Equipment>>());
        }

        [Test]
        public void FullName()
        {
            Equipment site = new Equipment {name = "Site A"};
            Equipment item = new Equipment {name = "Area 1"};

            Assert.That(site.FullName, Is.EqualTo("Site A"));
            Assert.That(item.FullName, Is.EqualTo("Area 1"));
            site.Items.Add(item);
            Assert.That(site.FullName, Is.EqualTo("Site A"));
            Assert.That(item.FullName, Is.EqualTo("Site A.Area 1"));
        }

        [Test]
        public void AddItemEnterprise()
        {
            Equipment item = new Equipment("Item 1");
            Assert.Throws<ArgumentException>(() => item.AddItem(new Enterprise("My Enterprise")));
        }

        [Test]
        public void AddItemNull()
        {
            Equipment item = new Equipment("Item 1");
            Assert.Throws<ArgumentNullException>(() => item.AddItem(null));
        }

        [Test]
        public void AddItemSite()
        {
            Equipment item = new Equipment("Equipment 1");
            Assert.Throws<ArgumentException>(() => item.AddItem(new Site("Site 2")));
        }

        [Test]
        public void AddItemEquipmentItem()
        {
            Equipment item = new Equipment("Item 1");
            item.AddItem(new Equipment("Item 1a"));

            Assert.That(item.Items.Count, Is.EqualTo(1));
            Assert.That(item.Items[0].Name, Is.EqualTo("Item 1a"));

            item.AddItem(new Equipment("Item 1b"));

            Assert.That(item.Items.Count, Is.EqualTo(2));
            Assert.That(item.Items[1].Name, Is.EqualTo("Item 1b"));
        }

        [Test]
        public void AddItemWorkCentre()
        {
            Equipment item = new Equipment("Item 1");
            item.AddItem(new Equipment("Work Centre 1"));

            Assert.That(item.Items.Count, Is.EqualTo(1));
            Assert.That(item.Items[0].Name, Is.EqualTo("Work Centre 1"));

            item.AddItem(new Equipment("Work Centre 2"));

            Assert.That(item.Items.Count, Is.EqualTo(2));
            Assert.That(item.Items[1].Name, Is.EqualTo("Work Centre 2"));
        }

        [Test]
        public void TestToString()
        {
            Equipment item = new Equipment("My item");
            Assert.That(item.ToString(), Is.EqualTo("Equipment 'My item'"));

            item.Items.AddEquipment("Equipment 1");
            Assert.That(item.ToString(), Is.EqualTo("Equipment 'My item'"));

            item.Items.AddEquipment("Work Centre 1");
            Assert.That(item.ToString(), Is.EqualTo("Equipment 'My item'"));
        }

        [Test]
        public void DefaultB2MMLType()
        {
            Equipment equipmentType = new Equipment();
            Assert.That(equipmentType.b2mmlType, Is.EqualTo(B2MMLType.Other));
        }
    }
}