using System;

namespace Infrastructure.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public string ItemName { get; set; }

        public int Identifier { get; set; }

        public ItemNotFoundException(string itemName) : base($"Item {itemName} was not found")
        {
            ItemName = itemName;
        }

        public ItemNotFoundException(string itemName, int identifier) : base($"Item {itemName} with identifier {identifier} was not found")
        {
            ItemName = itemName;
            Identifier = identifier;
        }
    }
}