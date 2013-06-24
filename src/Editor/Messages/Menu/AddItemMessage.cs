using System;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Editor.Messages.Menu
{
    public class AddItemMessage : IMessage
    {
        public AddItemMessage(Type itemType)
        {
            ArgumentCheck.IsTypeOf<Item>(itemType);
            ItemType = itemType;
        }

        public Type ItemType { get; private set; }

        public Item Create()
        {
            return (Item) Activator.CreateInstance(ItemType);
        }
    }
}