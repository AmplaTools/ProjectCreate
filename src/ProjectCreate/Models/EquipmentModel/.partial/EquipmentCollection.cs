using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Models.EquipmentModel
{
    public partial class EquipmentCollection
    {
        public EquipmentCollection(Item parent) : base(parent)
        {
        }

        /// <summary>
        /// Adds an equipment item with the specified name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Equipment AddEquipment(string name)
        {
            Equipment equipment = new Equipment(name);
            Add(equipment);
            return equipment;
        }
    }
}