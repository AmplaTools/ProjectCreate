using System;
using AmplaTools.ProjectCreate.Editor.Messages;

namespace AmplaTools.ProjectCreate.Editor.Models
{
    public class MenuCommand
    {
        private MenuCommand(string label, string category, Func<IMessage> messageFunc)
        {
            Label = label;
            Category = category;
            Message = messageFunc;
        }

        public string Category { get; private set; }
        public string Label { get; private set; }
        public Func<IMessage> Message { get; private set; } 

        public static MenuCommand Menu<T>(string label, string category) where T : IMessage, new()
        {
            return new MenuCommand(label, category, () => new T());
        }

        public static MenuCommand Menu<T>(string label, string category, Func<T> func ) where T : IMessage
        {
            return new MenuCommand(label, category, () => func());
        }
    }
}