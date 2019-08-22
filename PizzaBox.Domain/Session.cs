using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public class Session
    {
      static List<User> users;
      static List<Location> locations;
      private User user;

      private Location location;


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

      public string SessionStart()
      {
        //set up data, print commands

        return "error";
      }

      public string SessionNext(string input)
      {
        //listen for commands
        return "No command found for: " + input;
      }

    public string RegisterUser(string name)
      {
        users.Add(new User(name));
        return "Registered account: " + name;
      }
      public void AddNewLocation(Location location)
      {

      }
      public string GetLocations()
      {
        return "";
      }
      public string SelectLocation()
      {
        return "";
      }
      public void OpenOrder()
      {
        
      }
      public void Checkout()
      {
        
      }

        
    }
}
     
     
