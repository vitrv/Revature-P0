using System.Collections.Generic;
using System.Linq;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain
{
  public class DataAccess
  {
    PizzaDBContext db;

    public DataAccess()
    {
      db = new PizzaDBContext();
    }

    public void SaveNewUser(Domain.User u)
    {
      Data.Entities.User _user = new Data.Entities.User();
      _user.Username = u.Username;

      db.Add(_user);
      db.SaveChanges();

    }
    public Domain.User GetUser(string name)
    {
      try
      {
        List<Data.Entities.User> user = db.User
        .Where(u => u.Username.Equals(name.ToLower()))
        .ToList();

        if(!(user.First() is null))
        {
          Domain.User u = new User(user.First().Username);
          return u;
        }
        return null;
      }
      catch (System.InvalidOperationException)
      {
        return null;
      }
    }

    public void RegisterLocation(string name, string address)
    {
      Data.Entities.Location _loc = new Data.Entities.Location();
      _loc.Name = name;
      _loc.Address = address;

      db.Add(_loc);
      db.SaveChanges();

    }
    public List<Domain.Location> GetAllLocations()
    {
      return new List<Location>();
    }
    public Domain.Location GetLocation(string name)
    {
      try
      {
        
      }
      catch
      {

      }
      return new Domain.Location("","");
    }
    public void SaveOrder(Domain.Order order)
    {

    }
    public List<Domain.Order> GetOrders(string username)
    {
      return new List<Order>();
    }

  }
}