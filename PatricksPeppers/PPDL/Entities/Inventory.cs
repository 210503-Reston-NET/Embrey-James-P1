using System;
using System.Collections.Generic;

#nullable disable

namespace PPDL.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int InventoryNumber { get; set; }
        public int InventoryQuantity { get; set; }
        public int InventoryCode { get; set; }

        public virtual Location InventoryCodeNavigation { get; set; }
        public virtual Product InventoryNumberNavigation { get; set; }
    }
}
