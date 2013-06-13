using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;

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

        public override void AddItem(Item item)
        {
            ArgumentCheck.IsNotNull(item);

            string message = string.Format("Unable to add {0} to WorkCentre.", item);
            throw new ArgumentException(message);
        }


        public override string Name
        {
            get { return name; }
        }
    }
}