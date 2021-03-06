using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PPModels
{
    public class Customer
    {
        // private string _locale;

        public Customer(int id, string name, string locale)
        {
            this.CustomerId = id;
            this.Name = name;
            this.Locale = locale;
        }

        public Customer()
        {

        }

        public string Name { get; set; }
        // { 
        //     get { return name; }
        //     set
        //     {
        //         if (!Regex.IsMatch(value, @"^(A-Za-z .]+$")) throw new Exception("We'd prefer names not to have numbers!");
        //         Name = value;
        //     } 
        // }

        public string Locale { get; set; }
        // { 
        //     get { return locale; }
        //     set
        //     {
        //         if (!Regex.IsMatch(value, @"^(A-Za-z .]+$")) throw new Exception("Location cannot have numbers!");
        //     _locale = value;
        //     }
        // }

        public int Quantity { get; set; }

        [Key]
        public int CustomerId { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name} \n{this.Locale} \n{this.Quantity} ";
        }

        // public List<Customers> _customers { get; set; }

        // public override string ToString()
        // {
        //     return $" Name: {Name} \n Locale: {Locale} \n Quantity: {Quantity}";
        // }
        // public bool Equals(Customers customers)
        // {
        //     return this.Name.Equals(customers.Name) && this.Locale.Equals(customers.Locale) && this.Quantity.Equals(customers.Quantity);
        // }
        // static void Main(string[] args)
        // {

        // }
    }
}