using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class InventoryItem
    {
        public int InvId { get; set; }
        public int LocId { get; set; }
        public int Cid { get; set; }
        public int Quantity { get; set; }

        public virtual Component C { get; set; }
        public virtual Location Loc { get; set; }
    }
}
