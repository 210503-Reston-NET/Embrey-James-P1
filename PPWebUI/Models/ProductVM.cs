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
    public class ProductVM
    {
        public ProductVM(Products products)
        {
            Id = products.ProductId;
            name = products.ProductName;
            quantity = products.ProductQuantity;
            price = products.ProductPrice;
        }
        public ProductVM()
        {

        }

        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int quantity { get; set; }      
        public double price { get; set; }
        
    }
}
