using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public partial class WorkCentre : Item
    {

        public WorkCentre() : this("WorkCentre 1")
        {
        }

        public WorkCentre(string name)
        {
            this.name = name;
        }

        public override List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            return items;
        }

        public override string Name
        {
            get { return name; }
        }
    }
}