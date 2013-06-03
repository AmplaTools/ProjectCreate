using System.Collections.Generic;
using System.Linq;

namespace AmplaTools.ProjectCreate.Messages
{
    public static class ItemExtender
    {
        public static int GetCount(this IItem item)
        {
            return (item is Hierarchy ? 0 : 1) + item.GetItems().Sum(child => child.GetCount());
        }

        public static List<IItem> GetDescendants(this IItem parent)
        {
            List<IItem> descendants = new List<IItem>();
            List<IItem> children = parent.GetItems();
            descendants.AddRange(children);
            foreach (IItem child in children)
            {
                descendants.AddRange(child.GetDescendants());
            }
            return descendants;
        }
    }
}