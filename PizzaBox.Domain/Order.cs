using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public class Order
    {
      public List<Pizza> _pizzas;

      public Order()
      {
        _pizzas = new List<Pizza>();
      }

      public override string ToString()
      {
        string output = "Order:\n";
        int c = 1;

        foreach (var p in _pizzas)
        {
            output = output + "Pizza " + c + "\n" +
              p.ToString() + "\n";
            c++;
        }
        output += "Total Cost: $" + GetCost() + "\n";
        return output;
      }

      public decimal GetCost()
      {
        decimal cost = 0;
        foreach (Pizza p in _pizzas)
        {
          cost += p.GetCost();
        }
        return cost;
      }
      public void AddPizza()
      {
        Pizza p = new Pizza();
        _pizzas.Add(p);
      }
      public void AddPizza(Pizza p)
      {
        _pizzas.Add(p);
      }


      
    }
}
