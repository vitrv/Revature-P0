using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public class Session
    {

      private User user;

      private Location location;

      private Order order;

      private DataAccess data;

      public Session()
      {
        order = new Order();
        data = new DataAccess();
      }

      public string SessionStart()
      {
        return  "----------------------------\n" +
                "| Welcome To PizzaBox CLI! |\n" +
                "----------------------------\n" +
                "Enter \"help\" for a list of commands,\n" +
                "or \"exit\" to exit.";
      }

      public string SessionNext(string[] input)
      {
        string c = input[0];

        if(c == "exit")
        {
          Environment.Exit(0);
        }
        if(c == "help")
        {
          return Help();
        }
        if(c == "logout")
        {
          return Logout();
        }
        if(c == "login")
        {
          return Login(input[1]);
        }
        if(c == "register")
        {
          return RegisterUser(input[1]);
        }
        if(c == "location")
        {
          if(input[1] == "list")
          {
            return ListLocations();
          }
          if(input[1] == "menu")
          {
            return ViewInventory();
          }
          if(input[1] == "select")
          {
            return SelectLocation(input[2]);
          }
          if(input[1] == "history")
          {
            return ViewLocationHistory();
          }
          return "Invalid behavior for: location" + input[1];
        }
        if(c == "pizza")
        { if(input[1] == "list")
          {
            return ListPresetPizzas();
          }
          if(input[1] == "new")
          {
            if(input[2] == "custom")
            {
              return NewCustomPizza();
            }
            //add specialty pizzas here
            if(input[2] == "hawaiian")
            {
              return NewHawaiianPizza();
            }
          }
          if(input[2] == "add")
          {
            return AddToPizza(input[1], input[3], input[4]);
          }
          if(input[2] == "remove" || input[2] == "rm")
          {
            return RemoveFromPizza(input[1], input[3], input[4]);
          }
          return "Invalid behavior for: pizza" + input[1];
        }
        if(c == "order")
        {
          if(input[1] == "view")
          {
            return ViewOrder();
          }
          if(input[1] == "confirm")
          {
            return ConfirmOrder();
          }
          if(input[1] == "history")
          {
            return ViewHistory();
          }
          return "Invalid behavior for: order " + input[1];
        }

        return "No command found for: " + c;
      }

    private string NewHawaiianPizza()
    {
      PizzaFactory pf = new PizzaFactory(location);
      Pizza p = pf.MakeHawaiian();
      if (!(p is null))
      {
        order.AddPizza(p);
        return "Added new hawaiian pizza";
      }

      return "Error: Could not make specialty pizza with ingredients at location";
    }

    private string ListPresetPizzas()
    {
      PizzaFactory pf = new PizzaFactory(location);
      return pf.ListPresets();
    }

    private string RemoveFromPizza(string id, string kind, string name)
    {
        int index = int.Parse(id) - 1;
        if (index >= order._pizzas.Count)
        {
          return "Pizza " + id + "does not exist.";
        }
        Pizza p = order._pizzas[index];
        if(kind == "size")
        {
          p.Size = null;
          return $"Removed {kind} {name} from Pizza {id}";
        }
        if(kind == "cheese")
        {
          p.Cheese = null;
          return $"Removed {kind} {name} from Pizza {id}";

        }
        if(kind == "crust")
        {
          p.Crust = null;
          return $"Removed {kind} {name} from Pizza {id}";
        }
        if(kind == "topping")
        {
          return p.RemoveTopping(name);
        }

        return $"Ingredient type: {kind} does not exist. Must specify cheese, size, crust or topping.";
    }

    private string ViewLocationHistory()
      {
        string output = "Order History:\n";
        foreach(var o in location.orderlog)
        {
          output = output + o.ToString() + "\n";
        }
        return output;
      }

      private string AddToPizza(string id, string kind, string name)
      {
        int index = int.Parse(id) - 1;
        if (index >= order._pizzas.Count)
        {
          return $"Pizza {id} does not exist.";
        }
        Pizza p = order._pizzas[index];

        if(kind == "size")
        {
          Size s = location.Inventory.GetSize(name);
          if(!(s is null))
          {
            p.Size = s;
            return $"Added {kind} {name} to Pizza {id}";
          }
          else return $"{kind} {name} not found.";
        }
        if(kind == "cheese")
        {
          Cheese c = (Cheese) location.Inventory.GetInventoryItem(name).item;
          if(!(c is null))
          {
            p.Cheese = c;
            return $"Added {kind} {name} to Pizza {id}";
          }
          else return $"{kind} {name} not found.";
        }
        if(kind == "crust")
        {
          Crust c = (Crust) location.Inventory.GetInventoryItem(name).item;
          if(!(c is null))
          {
            p.Crust = c;
            return $"Added {kind} {name} to Pizza {id}";
          }
          else return $"{kind} {name} not found.";
        }
        if(kind == "topping")
        {
          Topping t = (Topping) location.Inventory.GetInventoryItem(name).item;
          if(!(t is null))
          {
            p.AddTopping(t);
            return $"Added {kind} {name} to Pizza {id}";
          }
          else return $"{kind} {name} not found.";

        }

        return $"Ingredient type: {kind} does not exist. Must specify cheese, size, crust or topping.";
      }

      private string NewCustomPizza()
      {
        order.AddPizza();
        return "Added custom pizza.";
      }

      private string ViewHistory()
      {
        string output = "Order History:\n";
        foreach(var o in user.orderlog)
        {
          output = output + o.ToString() + "\n";
        }
        return output;
      }

      private string ConfirmOrder()
      {
        if(!(user is null))
        {
          user.orderlog.Add(order);
          location.orderlog.Add(order);
          order = null;
          return "Order confirmed.";
        }

        return "Must log in to place order.";

      }

      private string ViewOrder()
      {
        return order.ToString();
      }

      private string Help()
      {
        return "Commands: \n" +
        "register <username>\n" +
        "login <username>\n" +
        "logout\n" +
        "location view\n" +
        "location select <location_name>\n" +
        "location menu\n" +
        "location history\n" +
        "pizza list\n" +
        "pizza new custom\n" +
        "pizza new <type>\n" +
        "pizza <id> add <crust|cheese|size|topping> <name>\n" +
        "pizza <id> remove <crust|cheese|size|topping> <name>\n" +
        "order view\n" +
        "order confirm\n" +
        "order history\n";
      }

      private string ViewInventory()
      {
        if(!(location is null))
        {
          Inventory i = data.GetInventory(location);
          return i.ToString();
        }
        return "No location selected to display inventory";
      }

      private string Logout()
      {
        user = null;
        return "Logging out...";
      }

      private string ListLocations()
      {
        string output = "Available Locations:\n";
        foreach (var l in data.GetAllLocations())
        {
          output = output + l.ToString() + "\n";
        }
        return output;
      }
      public string Login(string name)
      {
        User u = data.ReadUser(name);
        if(!(u is null))
        {
          user = u;
          return $"Logged in as {name}.";
        }
        return $"Account {name} not found.";
      }


      public string RegisterUser(string name)
      {
        if(data.ReadUser(name) is null)
        {
          User u = new User(name);
          data.SaveNewUser(u);
          return "Registered account: " + name;
        }
        else return $"Username {name} is taken.";
        
      }
      public string SelectLocation(string name)
      {
        foreach (var l in data.GetAllLocations())
        {
          if(name.ToLower() == l.Name.ToLower())
          {
            location = l;
            return "Selected location " + name;
          }
        }
        return "Location " + name + " not found.";
      }

        
    }
}
     
     
