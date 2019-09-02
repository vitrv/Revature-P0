﻿using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class PizzaComponent
    {
        public int Pcid { get; set; }
        public int PizzaId { get; set; }
        public int Cid { get; set; }

        public Component C { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
