using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Hierarchy : Item
    {
        public Hierarchy()
        {
            Enterprise = null;
        }

        public override List<IItem> GetItems()
        {
            List<IItem> items = new List<IItem>();
            if (Enterprise != null)
            {
                items.Add(Enterprise);
            }
            return items;
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

            Enterprise enterprise = item as Enterprise;
            if (enterprise == null)
            {
                string message = string.Format("Unable to add {0} to Hierarchy.", item);
                throw new ArgumentException(message);
            }
            if (Enterprise != null)
            {
                throw new InvalidOperationException("Only one Enterprise allowed.");
            }
            Enterprise = enterprise;
        }

        /// <summary>
        ///     Creates new Hierarchy that is empty.
        /// </summary>
        /// <returns></returns>
        public static Hierarchy Empty()
        {
            return new Hierarchy {Enterprise = null};
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
            return string.Format("Hierarchy ({0} item{1})", count, count == 1 ? "": "s");
        }
    }


}