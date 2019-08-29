using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Component
    {
        public Component()
        {
            InventoryItem = new HashSet<InventoryItem>();
            PizzaComponent = new HashSet<PizzaComponent>();
        }

        public int Cid { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Kind { get; set; }

        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
        public virtual ICollection<PizzaComponent> PizzaComponent { get; set; }
    }
}
