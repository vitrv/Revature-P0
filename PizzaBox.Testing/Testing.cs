using System;
using Xunit;
using PizzaBox.Domain;

namespace Pizza.Testing
{
    public class Testing
    {
      [Fact]
      public void TestInventorySize()
      {
        Inventory i = new Inventory();
        Size s = new Size("Test", 0M);
        i.AddSize(s);

        string result = i.GetSize("test").Name;
        
        Assert.True(result == "Test");

      }
      [Fact]
      public void TestInventoryTopping()
      {
        Inventory i = new Inventory();
        Topping t = new Topping("Test", 0M);
        i.SetInventory(t, 1);

        string result = i.GetInventoryItem("test").item.Name;
        
        Assert.True(result == "Test");

      }
    }
}
