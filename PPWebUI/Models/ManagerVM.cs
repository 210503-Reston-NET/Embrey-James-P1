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
    public class ManagerVM
    {
        public ManagerVM(Manager manager)
        {
            Id = manager.mId;
            Name = manager.mName;
        }

        public ManagerVM()
        {

        }

        public int Id { get; set; }
        
        [Required]

        public string Name { get; set; }

    }
}
