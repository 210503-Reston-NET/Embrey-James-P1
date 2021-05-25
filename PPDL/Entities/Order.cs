using System;
using System.Collections.Generic;

#nullable disable

namespace PPDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderNumber { get; set; }
        public double OrderTotal { get; set; }
        public string OrderLocation { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer OrderNumberNavigation { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
