﻿using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
