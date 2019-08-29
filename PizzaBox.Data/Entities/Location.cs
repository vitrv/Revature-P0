using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Location
    {
        public Location()
        {
            InventoryItem = new HashSet<InventoryItem>();
            Order = new HashSet<Order>();
        }

        public int LocId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
