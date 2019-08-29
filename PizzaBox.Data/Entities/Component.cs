using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Component
    {
        public int Cid { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Kind { get; set; }
    }
}
