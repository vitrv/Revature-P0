using System.Collections.Generic;

namespace PizzaBox.Domain
{
  public class Location
  {
    private string name;
    private string address;

    private List<Order> orderlog;
    public Inventory Inventory {get; set;}

    public Location(string _name, string _address)
    {
      name = _name;
      address = _address;
    }
    
      
  }
    
}