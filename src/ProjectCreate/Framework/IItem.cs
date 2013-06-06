using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Framework
{
    public interface IItem
    {
        List<IItem> GetItems();

        string Name { get; }

        string FullName { get; }

        Item GetParent();
        void SetParent(Item parent);
    }

}