using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Messages
{
    public partial class Site : IItem
    {
         public Site()
         {
             name = "Site 1";
             Area = new List<Area>();
         }

         public string Name { get { return name; } }

         public string FullName { get { return Name; } }

         public List<IItem> GetItems()
         {
             return new List<IItem>(Area);
         }
    }
}