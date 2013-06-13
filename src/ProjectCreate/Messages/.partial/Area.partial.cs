using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;

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

        public override void AddItem(Item item)
        {
            ArgumentCheck.IsNotNull(item);

            Area area = item as Area;
            WorkCentre wc = item as WorkCentre;
            if (area == null && wc == null)
            {
                string message = string.Format("Unable to add {0} to Area.", item);
                throw new ArgumentException(message);
            }
            if (area != null)
            {
                Area1.Add(area);
            }

            if (wc != null)
            {
                WorkCentre.Add(wc);
            }
        }
        
        public override List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            items.AddRange(Area1);
            items.AddRange(WorkCentre);
            return items;
        }
    }
}