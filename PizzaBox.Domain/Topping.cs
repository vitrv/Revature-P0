using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
  public class Topping : PizzaComponent
  {
    public Topping(string _name, decimal _cost) : base (_name, _cost) {}

  }
}
