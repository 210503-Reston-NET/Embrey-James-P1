using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PPModels
{
    public class Location
    {
        private Location location;

        public Location(int locationId, string name, string city, string state)
        {
            this.LocationId = locationId;
            this.Name = name;
            this.City = city;
            this.State = state;
        }

        public Location()
        {

        }


        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        
        [Key]
        public int LocationId { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name} \nCity: {this.City} \nState: {this.State}";
        }

    }
}