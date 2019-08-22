using System;
using PizzaBox.Domain;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine("Hello World!");

          Location l = new Location("aaa", "bbb");
          Cheese c = new Cheese("good", (decimal)5.99);
          l.Inventory.SetInventory(c, 3);

            //Session s = new Session();
            /* s.SessionStart();
            while(true)
            {
              
              string input = System.Console.ReadLine();

              if(input == "exit" )
              {
                Environment.Exit(0);
              }
              System.Console.WriteLine(s.SessionNext(input));
            }*/


            
        }
    }
}
