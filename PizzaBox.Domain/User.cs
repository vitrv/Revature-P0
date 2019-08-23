using System.Collections.Generic;

namespace PizzaBox.Domain
{
  public class User 
  {

    public string Username {get; set;}
    //List<Order> order;

    public User(string _name)
    {
      Username = _name;
    }

  }
}