using System.Collections.Generic;


namespace AmplaTools.ProjectCreate.Messages
{
    partial class Area : IItem
    {
        public Area()
        {
            name = "Area 1";
            Area1 = new List<Area>();
            WorkCentre = new List<WorkCentre>();
        }

        public string Name { get { return name; } }

        public string FullName { get { return Name; } }

        public List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            items.AddRange(Area1);
            items.AddRange(WorkCentre);
            return items;
        }
    }
}