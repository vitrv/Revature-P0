using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{

    public class Pizza
    {
      public Crust Crust {get; set;}
      public Size Size {get; set;}

      public Cheese Cheese {get;set;}

      public List<Topping> _toppings;

      
      public Pizza()
      {
        _toppings = new List<Topping>();
      }
      public override string ToString()
      {
        string output = "";

        if (!(Crust is null))
        {
          output += "Crust: " + Crust.ToString() + "\n";
        }
        if (!(Size is null))
        {
          output += "Size: " + Size.ToString() + "\n";
        }
        if (!(Cheese is null))
        {
          output += "Cheese: " + Cheese.ToString() + "\n";
        }
  
        output += "Toppings: \n";
        foreach (var t in _toppings)
        {
          output = output + t.ToString() + "\n";
        }
        output += "Cost: $" + GetCost();
        return output;
      }
      public decimal GetCost()
      {
        decimal cost = 0;
        if (!(Crust is null))
        {
          cost += Crust.Cost;
        }
        if (!(Cheese is null))
        {
          cost += Cheese.Cost;
        }
        if (!(Size is null))
        {
          cost += Size.Cost;
        }
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

    internal string RemoveTopping(string name)
    {
      foreach (var t in _toppings)
      {
        if(t.Name.ToLower() == name.ToLower())
        {
          _toppings.Remove(t);
          return "Removed " + name;
        } 
      }
      return $"{name} not found on pizza.";
      
    }
  }
}
