using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;

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

        public override List<IItem> GetItems()
        {
            return new List<IItem>(Area);
        }
    }
}