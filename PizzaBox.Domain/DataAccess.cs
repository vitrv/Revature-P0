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
    public Domain.User ReadUser(string name)
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
    public Data.Entities.Location GetLocationEntity(string name)
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
    public void SaveOrder(Domain.Order order, Domain.Location loc, Domain.User u)
    {
      //get user and location entities
      //create new order object
      //populate with user, location and contained pizzas
      //save

    }
    public List<Domain.Order> GetUserOrders(string username)
    {
      return new List<Order>();
    }
    public List<Domain.Order> GetLocationOrders(string username)
    {
      return new List<Order>();
    }

    public Domain.Inventory GetInventory(Domain.Location loc)
    {
      return new Domain.Inventory();
    }
    public void ModifyInventory(Domain.Location loc, Domain.PizzaComponent pc, int quantity)
    {
      Data.Entities.Location locEntity = GetLocationEntity(loc.Name);
      Data.Entities.Component compEntity = GetComponentEntity(pc);

      if (compEntity is null)
      {
        compEntity = RegisterComponent(pc);
      }
      Data.Entities.InventoryItem invEntity = locEntity.InventoryItem.ToList()
          .Find(i => i.Cid.Equals(compEntity.Cid));
      if (!(invEntity is null))
      {
        invEntity.Quantity = quantity;
        db.SaveChanges();
        return;
      }
      invEntity = new Data.Entities.InventoryItem();
      invEntity.Loc = locEntity;
      invEntity.C = compEntity;
      invEntity.Quantity = quantity;
      
      locEntity.InventoryItem.Add(invEntity);
      db.SaveChanges();


    }
    public Data.Entities.Component RegisterComponent(Domain.PizzaComponent pc)
    {
        Data.Entities.Component _pc = new Data.Entities.Component();
        _pc.Name = pc.Name;
        _pc.Cost = pc.Cost;
        _pc.Kind = pc.GetKind();

        db.Add(_pc);
        db.SaveChanges(); 
        return _pc;

    }
    public Data.Entities.Component GetComponentEntity(Domain.PizzaComponent pc)
    {
      string kind = pc.GetKind();
      try
      {
        List<Data.Entities.Component> component = db.Component
        .Where(p => p.Name.ToLower().Equals(pc.Name.ToLower())
        && p.Kind.ToLower().Equals(kind.ToLower()))
        .ToList();
        Data.Entities.Component comp = component.First();
        return comp;
      }
      catch(System.InvalidOperationException)
      {
        return null;
      }
    }



  }
}