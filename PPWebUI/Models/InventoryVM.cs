using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPModels;
using System.Text.RegularExpressions;

namespace PPWebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM()
        {
            
        }

        public InventoryVM(Inventory inventory)
        {
            this.Id = inventory.InventoryId;
            this.Number = inventory.InventoryNumber;
            this.Quantity = inventory.InventoryQuantity;
            this.Code = inventory.InventoryCode;
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public int Quantity { get; set; }
        

        public int Code { get; set; }
        public List<SelectListItem> ProductOptions { get; set; }
    }
}
