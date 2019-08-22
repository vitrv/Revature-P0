using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{

    public class Pizza
    {
      public Crust Crust {get; set;}
      public Size Size {get; set;}

      public Cheese Cheese {get;set;}

      private List<Topping> _toppings;

      public decimal GetCost()
      {
        decimal cost = 0;
        foreach (Topping t in _toppings)
        {
          cost += t.Cost;
        }
        return cost;
      }
      public void AddTopping(Topping t)
      {
        _toppings.Add(t);
      }

    }
}
