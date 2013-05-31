using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Messages
{
    public partial class Hierarchy : IItem
    {
        public Hierarchy()
        {
            Enterprise = new Enterprise();
        }

        public string Name { get { return ""; }}

        public string FullName { get { return Name; } }

        public List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            if (Enterprise != null)
            {
                items.Add(Enterprise);
            }
            return items;
        }
    }


}