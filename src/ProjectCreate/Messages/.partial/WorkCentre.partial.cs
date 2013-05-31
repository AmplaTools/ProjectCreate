using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Messages
{
    public partial class WorkCentre : IItem
    {

        public WorkCentre()
        {
            name = "WorkCentre";
        }

        public string Name { get { return name; } }

        public string FullName { get { return Name; } }

        public List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            return items;
        }
    }
}