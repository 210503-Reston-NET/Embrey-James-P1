using System;
using System.Collections.Generic;

#nullable disable

namespace PPDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
