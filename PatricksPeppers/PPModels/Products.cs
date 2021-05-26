using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PPModels
{

    public class Products
    {
        public Products (int productId, string productName, int productQuantity, double productPrice)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductQuantity = productQuantity;
            this.ProductPrice = productPrice;

        }

        public Products (string productName, double productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        public override string ToString()
        {
            return $"Name: {this.ProductName}" + " " + $"Name : {this.ProductPrice}";
            // string[] list = ProductName;

            // IEnumerable<string> query = from Products in List
            // orderby list.Length, list();
        }
        // static void Main(string[] args)
        // {
                
        // }
    }
}