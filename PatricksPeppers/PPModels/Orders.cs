using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PPModels
{
    public class Orders
    {
        public Orders (int orderId, int orderQuantity, int orderNumber, double orderTotal, string orderLocation)
        {
            this.OrderId = orderId;
            this.OrderQuantity = orderQuantity;
            this.OrderNumber = orderNumber;
            this.OrderTotal = orderTotal;
            this.OrderLocation = orderLocation;
            
        }

        public int OrderId { get; set; }
        
        public int OrderQuantity { get; set; } = 1;

        public int OrderNumber { get; set; }

        public double OrderTotal {get; set; }

        public string OrderLocation {get; set; }

        // public DateTime OrderDate {get; set; }

        public override string ToString()
        {
            return $"Name: {this.OrderQuantity}";
        }
        // static void Main(string[] args)
        // {
                
        // }
    }
}