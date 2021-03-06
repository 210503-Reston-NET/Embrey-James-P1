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
    public class CustomerVM
    {
        public CustomerVM(Customer customer)
        {
            Id = customer.CustomerId;
            name = customer.Name;
            locale = customer.Locale;
        }
        public CustomerVM()
        {

        }

        public int Id { get; set; }


        [Required]
        [DisplayName("Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string name { get; set; }

        [Required]

        public string locale { get; set; }
        
    }
}