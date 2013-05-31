using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Messages
{
    partial class Enterprise : IItem
    {
        public Enterprise()
        {
            name = "Enterprise";
            Site = new List<Site>();
        }

        public string Name { get { return name; } }

        public string FullName { get { return Name; } }

        public List<IItem> GetItems()
        {
            return new List<IItem>(Site);
        }
    }
}