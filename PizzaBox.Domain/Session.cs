using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public class Session
    {
      public static List<User> users;
      public static List<Location> locations;
      private User user;

      private Location location;

      private Order order;

      public Session()
      {
        locations = new List<Location>();
        users = new List<User>();
        order = new Order();
      }

      public string SessionStart()
      {
        //set up data, print commands

        return  "------------------------\n" +
                "| Welcome To PizzaCLI! |\n" +
                "------------------------\n" +
                "Enter \"help\" for a list of commands,\n" +
                "or \"exit\" to exit.";
      }

      public string SessionNext(string[] input)
      {
        //listen for commands
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
        }
        if(c == "pizza")
        {
          if(input[1] == "new")
          {
            if(input[2] == "custom")
            {
              return NewCustomPizza();
            }
            
          }
          if(input[2] == "add")
          {
            return AddToPizza(input[1], input[3], input[4]);
          }
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

        }

        return "No command found for: " + c;
      }

      private string AddToPizza(string id, string kind, string name)
      {
        throw new NotImplementedException();
      }

      private string NewCustomPizza()
      {
        order.AddPizza();
        return "Added custom pizza.";
      }

      private string ViewHistory()
      {
        throw new NotImplementedException();
      }

      private string ConfirmOrder()
      {
        location.orderlog.Add(order);
        order = null;
      }

      private string ViewOrder()
      {
        return order.ToString();
      }

      private string Help()
      {
        throw new NotImplementedException();
      }

      private string ViewInventory()
      {
        if(!(location is null))
        {
          return location.Inventory.ToString();
        }
        return "No location selected to display inventory";
      }

      private string Logout()
      {
        user = null;
        return "Logged out.";
      }

      private string ListLocations()
      {
        string output = "Available Locations:\n";
        foreach (var l in locations)
        {
          output = output + l.ToString() + "\n";
        }
        return output;
      }
      public string Login(string name)
      {
        foreach (User u in users)
        {
          if (u.Username == name)
          {
            user = u;
            return "Logged in as: " + name; 
          }
        }
        return "No account found for: " + name;
      }


      public string RegisterUser(string name)
      {
        users.Add(new User(name));
        return "Registered account: " + name;
      }
      public string SelectLocation(string name)
      {
        foreach (var l in locations)
        {
          if(name == l.Name)
          {
            location = l;
            return "Selected location " + name;
          }
        }
        return "Location " + name + " not found.";
      }

        
    }
}
     
     
