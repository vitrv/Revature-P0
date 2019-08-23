using System;
using PizzaBox.Domain;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
          //TODO:
          //tests
          //cli
          //data
          //login/register commands
          //view/set location commands
          //edit pizza commands
          //preset pizzas
          //confirm/view order
          //order history
          //signout
          //exception handling
          Session s = new Session();
          
          Location l = new Location("aaa", "bbb");
          Location l2 = new Location("bbb", "sdfg");
          Location l3 = new Location("ccc", "jhgfdfgh");
          Cheese c = new Cheese("good", (decimal)5.99);
          l.Inventory.SetInventory(c, 3);

          
          System.Console.WriteLine(s.SessionStart());
            while(true)
            {
              
              string input = System.Console.ReadLine();

              if(input == "exit" )
              {
                Environment.Exit(0);
              }
              System.Console.WriteLine(s.SessionNext(input.Split(' ')));
            }


            
        }
    }
}
