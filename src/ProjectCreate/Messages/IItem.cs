using System.Collections.Generic;
using System.Linq;

namespace AmplaTools.ProjectCreate.Messages
{
    public interface IItem
    {
        List<IItem> GetItems();

        string Name { get; }

        string FullName { get; }
    }

    public static class ItemExtender
    {
        public static int GetCount(this IItem item)
        {
           return  (item is Hierarchy ? 0 : 1) + item.GetItems().Sum(child => child.GetCount());
        }
    }
}