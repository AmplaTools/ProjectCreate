using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Framework
{
    public abstract class Item : IItem
    {
        private Item parentItem;

        public abstract List<IItem> GetItems();

        public abstract string Name { get; }

        public string FullName
        {
            get
            {
                if (parentItem == null)
                {
                    return Name;
                }
                return parentItem.FullName + "." + Name;
            }
        }

        Item IItem.GetParent()
        {
            return parentItem;
        }

        void IItem.SetParent(Item parent)
        {
            parentItem = parent;
        }
    }
}