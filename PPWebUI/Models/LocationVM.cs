using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PPModels;
using System.Text.RegularExpressions;

namespace PPWebUI.Models
{
    public class LocationVM
    {
        public LocationVM(Location location)
        {
            Id = location.LocationId;
            Name = location.Name;
            City = location.City;
            State = location.State;
        }

        public LocationVM()
        {

        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }

        
    }
}
