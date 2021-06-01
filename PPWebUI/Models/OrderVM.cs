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
    public class OrderVM
    {
        public OrderVM(Order orders)
        {
            Id = orders.OrderId;
            quantity = orders.OrderQuantity;
            number = orders.OrderNumber;
            total = orders.OrderTotal;
            location = orders.OrderLocation;
            date = orders.OrderDate;
        }
        public OrderVM()
        {

        }

        public int Id { get; set; }
        [Required]
        public int quantity { get; set; }
        public int number { get; set; }
        public double total { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
    }
}
