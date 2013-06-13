using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Framework
{
    /// <summary>
    ///     Item base class for Hierarchy items
    /// </summary>
    public abstract class Item : IItem
    {
        private Item parentItem;

        public abstract List<IItem> GetItems();

        public abstract string Name { get; }

        public abstract void AddItem(Item item);

        /// <summary>
        /// Gets the full name of the item
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName
        {
            get
            {
                if (parentItem == null)
                {
                    return Name;
                }
                return parentItem.FullName + "." + Name;
            }
        }

        /// <summary>
        ///     Gets the parent for the item
        /// </summary>
        /// <returns></returns>
        Item IItem.GetParent()
        {
            return parentItem;
        }

        /// <summary>
        ///     Sets the parent for the item
        /// </summary>
        /// <param name="parent">The parent.</param>
        void IItem.SetParent(Item parent)
        {
            parentItem = parent;
        }
        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} '{1}'", GetType().Name, Name);
        }
    }
}