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
          //preset pizzas
          //exception handling
          //fix case sensitivity issues

          Session s = new Session();
          
          Location l = new Location("arlington", "100 Elm St");
          Location l2 = new Location("fort worth", "802 Pizza St");
          Location l3 = new Location("dallas", "900 Cheese Rd");
          Cheese c = new Cheese("swiss", (decimal)5.99);
          Crust cr = new Crust("thin_crust", (decimal)1.50);
          Size sz = new Size("small", 4.99M);
          Topping t = new Topping("pepperoni", 7.99M);
          Topping t2 = new Topping("ham", 3.99M);
          Topping t3 = new Topping("mushroom", 1.99M);

          l.Inventory.SetInventory(c, 3);
          l.Inventory.SetInventory(cr, 3);
          l.Inventory.AddSize(sz);
          l.Inventory.SetInventory(t, 20);
          l.Inventory.SetInventory(t2, 20);
          l.Inventory.SetInventory(t3, 20);

          
          System.Console.WriteLine(s.SessionStart());
            while(true)
            {
              
              string input = System.Console.ReadLine().ToLower();

              System.Console.WriteLine(s.SessionNext(input.Split(' ')));
            }


            
        }
    }
}
