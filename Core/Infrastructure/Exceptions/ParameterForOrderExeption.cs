using System;

namespace Infrastructure.Exceptions
{
    public class ParameterForOrderExeption : Exception
    {
        public string ItemName { get; set; }

        public ParameterForOrderExeption(string itemName) : base($"{itemName} for ordering was not found")
        {
            ItemName = itemName;
        }
    }
}