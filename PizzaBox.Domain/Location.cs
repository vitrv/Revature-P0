using System.Collections.Generic;

namespace PizzaBox.Domain
{
  public class Location
  {
    public string Name {get; set;}
    public string Address{get; set;}

    public List<Order> orderlog;
    public Inventory Inventory {get; set;}

    public Location(string _name, string _address)
    {
      Name = _name;
      Address = _address;
      Inventory = new Inventory();
      orderlog = new List<Order>();
      Session.locations.Add(this);
    }

    public override string ToString()
    {
      return Name;
    }
    
      
  }
    
}