using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Framework
{
    public class ItemCollection<T> : ObservableCollection<T> where T : Item
    {
        public ItemCollection(Item parent)
        {
            ArgumentCheck.IsNotNull(parent);
            Parent = parent;
        }

        /// <summary>
        ///     Change the default behaviour to remove all items one by one.
        /// </summary>
        protected override void ClearItems()
        {
            // don't call base here.
            List<T> itemsToRemove = new List<T>(this);
            foreach (T item in itemsToRemove)
            {
                Remove(item);
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            if (e.OldItems != null)
            {
                ResetParentForOldItems(e.OldItems);
            }
            if (e.NewItems != null)
            {
                SetParentForNewItems(e.NewItems);
            }
        }

        private void SetParentForNewItems(IEnumerable newItems)
        {
            foreach (IItem item in newItems)
            {
                IItem previousParent = item.GetParent();
                if (previousParent != null)
                {
                    string message = string.Format("New item {0} is already a member of collection: {1}", item.Name,
                                                   previousParent.FullName);
                    throw new InvalidOperationException(message);
                }
                item.SetParent(Parent);
            }
        }

        private void ResetParentForOldItems(IEnumerable oldItems)
        {
            foreach (IItem item in oldItems)
            {
                item.SetParent(null);
            }
        }

        protected Item Parent { get; private set; }
    }
}