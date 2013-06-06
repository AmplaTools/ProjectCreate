using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public partial class Hierarchy : Item
    {
        public Hierarchy()
        {
            Enterprise = new Enterprise();
        }

        public override List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            if (Enterprise != null)
            {
                items.Add(Enterprise);
            }
            return items;
        }

        public override string Name
        {
            get { return null; }
        }
    }


}