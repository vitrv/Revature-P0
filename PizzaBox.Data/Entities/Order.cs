using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Order
    {
        public Order()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public int LocId { get; set; }
        public int UserId { get; set; }

        public virtual Location Loc { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
