﻿using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
