using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    partial class Area : Item
    {
        public Area() : this("Area 1")
        {
        }

        public Area(string name)
        {
            this.name = name;
            Area1 = new AreaCollection(this);
            WorkCentre = new WorkCentreCollection(this);
        }

        public override string Name { get { return name; } }

        public override List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            items.AddRange(Area1);
            items.AddRange(WorkCentre);
            return items;
        }
    }
}