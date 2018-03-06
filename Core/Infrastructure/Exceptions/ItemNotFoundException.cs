using System;

namespace Infrastructure.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public object Item { get; set; }

        public ItemNotFoundException(object item) : base($"Item {nameof(Item)} was not found")
        {
            Item = item;
        }
    }
}