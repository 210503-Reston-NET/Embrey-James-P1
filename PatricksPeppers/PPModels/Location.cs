using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PPModels
{
    public class Location
    {
        public Location (string name, string city, string state)
        {
            this.Name = name;
            this.City = city;
            this.State = state;
        }

        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name} \nCity: {this.City} \nState: {this.State}" ;
        }
        
    }
}