using System;
using PizzaBox.Domain;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
          //TODO:
          //data
          //improvements to preset pizzas
          //add better tests

          Session s = new Session();
          
        /* 
          Cheese c = new Cheese("Swiss", (decimal)5.99);
          Crust cr = new Crust("Thin", (decimal)1.50);
          Size sz = new Size("Small", 4.99M);
          Topping t = new Topping("Pepperoni", 7.99M);
          Topping t2 = new Topping("Ham", 3.99M);
          Topping t3 = new Topping("Mushroom", 1.99M);

          l.Inventory.SetInventory(c, 3);
          l.Inventory.SetInventory(cr, 3);
          l.Inventory.AddSize(sz);
          l.Inventory.SetInventory(t, 20);
          l.Inventory.SetInventory(t2, 20);
          l.Inventory.SetInventory(t3, 20); */

          
          System.Console.WriteLine(s.SessionStart());
            while(true)
            {
              
              string input = System.Console.ReadLine();
              try
              {
                System.Console.WriteLine(s.SessionNext(input.Split(' ')));
              }
              catch (IndexOutOfRangeException)
              {
                System.Console.WriteLine("Entered too few arguments. Try again.");
              }
              catch (NullReferenceException)
              {
                System.Console.WriteLine("Ingredient not found. Have you selected a location?");
              }
              
            }


            
        }
    }
}
