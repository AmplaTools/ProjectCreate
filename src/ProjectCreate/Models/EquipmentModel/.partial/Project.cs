using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Models.EquipmentModel
{
    public partial class Project : Item
    {
        public Project()
        {
            Items = new EquipmentCollection(this);
        }

        public override List<IItem> GetItems()
        {
            return new List<IItem>(Items);
        }

        public override string Name
        {
            get { return null; }
        }

        /// <summary>
        ///     Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException">Only one Enterprise allowed.</exception>
        public override void AddItem(Item item)
        {
            ArgumentCheck.IsNotNull(item);

            Equipment equipment = item as Equipment;
            if (equipment == null)
            {
                string message = string.Format("Unable to add {0} to Project.", item);
                throw new ArgumentException(message);
            }
            Items.Add(equipment);
        }

        /// <summary>
        ///     Creates new Hierarchy that is empty.
        /// </summary>
        /// <returns></returns>
        public static Project Empty()
        {
            return new Project();
        }
        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            int count = this.GetCount();
            return string.Format("Project ({0} item{1})", count, count == 1 ? "": "s");
        }
    
    }
}