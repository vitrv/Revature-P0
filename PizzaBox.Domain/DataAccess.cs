using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        var invEntity = db.InventoryItem
            .Include(c => c.C) 
            .Where(ie => ie.LocId == loc.LocId)
            .ToList();



        var o = new Location(loc.Name, loc.Address);
        o.Inventory = GetInventory(invEntity);
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
      try
      {
        List<Data.Entities.Location> location = db.Location
            .Where(l => l.Name.ToLower().Equals(loc.Name.ToLower()))
            .ToList();
        Data.Entities.Location locEntity = location.First();

        List<Data.Entities.User> user = db.User
            .Where(us => us.Username.ToLower().Equals(u.Username.ToLower()))
            .ToList();
        Data.Entities.User userEntity = user.First();

        Data.Entities.Order result = new Data.Entities.Order();
        result.User = userEntity;
        result.Loc = locEntity;

        foreach (var p in order._pizzas)
        {
          Data.Entities.Pizza pizzaEntity = new Data.Entities.Pizza();

          Data.Entities.PizzaComponent cheeseEntity = new Data.Entities.PizzaComponent();
          cheeseEntity.C = GetComponentEntity(p.Cheese);

          Data.Entities.PizzaComponent crustEntity = new Data.Entities.PizzaComponent();
          crustEntity.C = GetComponentEntity(p.Crust);

          Data.Entities.PizzaComponent sizeEntity = new Data.Entities.PizzaComponent();
          sizeEntity.C = GetComponentEntity(p.Size);

          pizzaEntity.PizzaComponent.Add(cheeseEntity);
          pizzaEntity.PizzaComponent.Add(crustEntity);
          pizzaEntity.PizzaComponent.Add(sizeEntity);

          foreach (var t in p._toppings)
          {
            Data.Entities.PizzaComponent toppingEntity = new Data.Entities.PizzaComponent();
            toppingEntity.C = GetComponentEntity(t);
            
            pizzaEntity.PizzaComponent.Add(toppingEntity);
          }

          result.Pizza.Add(pizzaEntity);
        }

        db.Add(result);
        db.SaveChanges();
      }
      catch(System.InvalidOperationException)
      {

      }

    }
    public List<Domain.Order> GetUserOrders(string username)
    {
      return new List<Order>();
    }
    public List<Domain.Order> GetLocationOrders(string username)
    {
      return new List<Order>();
    }

    public Domain.Inventory GetInventory(ICollection<Data.Entities.InventoryItem> invEntity)
    {
      Inventory res = new Domain.Inventory();
      foreach (var i in invEntity)
      {
        PizzaComponent pc = GenerateComponent(i.C.Name, i.C.Cost, i.C.Kind);
        res.SetInventory(pc, i.Quantity);
        if (i.C.Kind.ToLower() == "size")
        {
          res.AddSize((Size) pc);
        }
        else
        {
          res.SetInventory(pc, i.Quantity);
        }
      }
      return res;
    }

    private PizzaComponent GenerateComponent(string name, decimal cost, string kind)
    {
      if(kind.ToLower() == "cheese")
      {
        return new Cheese(name, cost);
      }
      if(kind.ToLower() == "size")
      {
        return new Size(name, cost);
      }
      if(kind.ToLower() == "topping")
      {
        return new Topping(name, cost);
      }
      if(kind.ToLower() == "crust")
      {
        return new Crust(name, cost);
      }
      //should never get here, log an error
      return null;
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