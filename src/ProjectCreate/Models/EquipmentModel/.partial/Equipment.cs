using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Models.EquipmentModel
{
    public partial class Equipment : Item
    {
        public Equipment() : this("Equipment")
        {
        }

        public Equipment(string name)
        {
            this.name = name;
            Items = new EquipmentCollection(this);
            b2mmlType = B2MMLType.Other;
        }

        public override List<IItem> GetItems()
        {
            return new List<IItem>(Items);
        }

        public override string Name
        {
            get { return name; }
        }

        public override void AddItem(Item item)
        {
            ArgumentCheck.IsNotNull(item);

            Equipment equipment = item as Equipment;
            if (equipment == null)
            {
                string message = string.Format("Unable to add {0} to Equipment.", item);
                throw new ArgumentException(message);
            }
            Items.Add(equipment);
        }
    }
}