using System.Collections;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Validation
{
    public class ValidationMessages : IValidationMessages
    {
        public ValidationMessages()
        {
            messages = new List<ValidationMessage>();
        }

        private readonly List<ValidationMessage> messages;

        public IEnumerator<ValidationMessage> GetEnumerator()
        {
            return messages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ValidationMessage item)
        {
            ArgumentCheck.IsNotNull(item);
            messages.Add(item);
        }

        public void Clear()
        {
            messages.Clear();
        }

        public bool Contains(ValidationMessage item)
        {
            return messages.Contains(item);
        }

        public void CopyTo(ValidationMessage[] array, int arrayIndex)
        {
            messages.CopyTo(array, arrayIndex);
        }

        public bool Remove(ValidationMessage item)
        {
            return messages.Remove(item);
        }

        public int Count
        {
            get { return messages.Count; }
        }


        bool ICollection<ValidationMessage>.IsReadOnly
        {
            get { return ((ICollection<ValidationMessage>)messages).IsReadOnly; }
        }

        /// <summary>
        ///     Indexer into the messages
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ValidationMessage this[int index]
        {
            get { return messages[index]; }
        }
    }
}