using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Messages
{
    partial class Enterprise : Item
    {
        public Enterprise(string name)
        {
            this.name = name;
            Site = new SiteCollection(this);
        }
        public Enterprise() : this("Enterprise")
        {
        }

        public override void AddItem(Item item)
        {
            ArgumentCheck.IsNotNull(item);

            Site site = item as Site;
            if (site == null)
            {
                string message = string.Format("Unable to add {0} to Enterprise.", item);
                throw new ArgumentException(message);
            }
            Site.Add(site);
        }

        public override string Name { get { return name; } }

        public override List<IItem> GetItems()
        {
            return new List<IItem>(Site);
        }

    }
}