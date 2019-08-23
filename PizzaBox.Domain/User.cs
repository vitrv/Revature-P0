using System.Collections.Generic;

namespace PizzaBox.Domain
{
  public class User 
  {

    public string Username {get; set;}
    public List<Order> orderlog;

    public User(string _name)
    {
      Username = _name;
      orderlog = new List<Order>();
    }

  }
}