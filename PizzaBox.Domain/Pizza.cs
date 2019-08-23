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

      
      public Pizza()
      {
        _toppings = new List<Topping>();
      }
      public override string ToString()
      {
        string output = "Crust: " + Crust.ToString() + "\n" +
              "Size: " + Size.ToString() + "\n" +
              "Cheese: " + Cheese.ToString() + "\n" +
              "Toppings: ";
        foreach (var t in _toppings)
        {
          output = output + t.ToString() + "\n";
        }
        return output;
      }
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
