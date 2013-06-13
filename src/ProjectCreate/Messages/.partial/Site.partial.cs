using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Messages
{
    public partial class Site : Item
    {
        public Site() : this("Site 1")
        {
        }

        public Site(string name)
        {
            this.name = name;
            Area = new AreaCollection(this);
        }

        public override string Name
        {
            get { return name; }
        }

        public override void AddItem(Item item)
        {
            ArgumentCheck.IsNotNull(item);

            Area area = item as Area;
            if (area == null)
            {
                string message = string.Format("Unable to add {0} to Site.", item);
                throw new ArgumentException(message);
            }
            Area.Add(area);
        }

        public override List<IItem> GetItems()
        {
            return new List<IItem>(Area);
        }
    }
}