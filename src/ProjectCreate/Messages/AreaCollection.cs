using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public class AreaCollection : ItemCollection<Area>
    {
        public AreaCollection(Item parent) : base(parent)
        {
        }

        /// <summary>
        ///     Adds a new Area with the specified name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Area AddArea(string name)
        {
            Area area = new Area(name);
            Add(area);
            return area;
        }
    }


}