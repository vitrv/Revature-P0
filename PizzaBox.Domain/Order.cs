using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public class Order
    {
      private List<Pizza> _pizzas;

      public decimal GetCost()
      {
        decimal cost = 0;
        foreach (Pizza p in _pizzas)
        {
          cost += p.GetCost();
        }
        return cost;
      }
      public Pizza AddPizza()
      {
        Pizza p = new Pizza();
        _pizzas.Add(p);
        return p;
      }


      
    }
}
