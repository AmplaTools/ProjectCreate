using System.Collections.Generic;
using System.Collections.ObjectModel;
using AmplaTools.ProjectCreate.Framework;

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

        public override string Name { get { return name; } }

        public override List<IItem> GetItems()
        {
            return new List<IItem>(Site);
        }
    }
}