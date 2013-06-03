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

}