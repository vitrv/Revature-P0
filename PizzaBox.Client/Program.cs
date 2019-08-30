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
