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
        .Where(u => u.Username.ToLower().Equals(name.ToLower()))
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
      if(ReadLocation(name) is null)
      {
        Data.Entities.Location _loc = new Data.Entities.Location();
        _loc.Name = name;
        _loc.Address = address;

        db.Add(_loc);
        db.SaveChanges();
      }
 

    }
    public List<Domain.Location> GetAllLocations()
    {
      try
      {
        List<Data.Entities.Location> locations = db.Location.ToList();
        List<Domain.Location> output = new List<Location>();
        foreach (var l in locations)
        {
          var i = new Location(l.Name, l.Address);
          output.Add(i);
        }
        return output;
      }
      catch(System.InvalidOperationException)
      {
        return null;
      }
    }
    public Domain.Location ReadLocation(string name)
    {
      try
      {
        List<Data.Entities.Location> location = db.Location
            .Where(l => l.Name.ToLower().Equals(name.ToLower()))
            .ToList();
        Data.Entities.Location loc = location.First();
        var o = new Location(loc.Name, loc.Address);
        return o;
      }
      catch(System.InvalidOperationException)
      {
        return null;
      }
    }
    public Data.Entities.Location GetLocationDataObject(string name)
    {
      try
      {
        List<Data.Entities.Location> location = db.Location
            .Where(l => l.Name.ToLower().Equals(name.ToLower()))
            .ToList();
        Data.Entities.Location loc = location.First();
        return loc;
      }
      catch(System.InvalidOperationException)
      {
        return null;
      }
    }
    public void SaveOrder(Domain.Order order)
    {

    }
    public List<Domain.Order> GetOrders(string username)
    {
      return new List<Order>();
    }
    public Domain.Inventory GetInventory(Domain.Location loc)
    {
      return new Domain.Inventory();
    }
    public void ModifyInventory(Domain.Location loc, Domain.PizzaComponent pc, int quantity)
    {

    }

  }
}