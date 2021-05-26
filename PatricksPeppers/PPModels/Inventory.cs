using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace PPModels
{
    public class Inventory
    {
        public Inventory (int inventoryId, int inventoryNumber, int inventoryQuantity, int inventoryCode)
        {
            this.InventoryId = inventoryId;
            this.InventoryNumber = inventoryNumber;
            this.InventoryQuantity = inventoryQuantity;
            this.InventoryCode = inventoryCode;
        }

        public int InventoryId { get; set; }
        public int InventoryNumber { get; set; }

        public int InventoryQuantity { get; set; } = 1;
        public double InventoryCode {get; set; }

        public override string ToString()
        {
            return $"{InventoryId}{InventoryNumber}{InventoryQuantity}{InventoryCode}";
        }
    }
}