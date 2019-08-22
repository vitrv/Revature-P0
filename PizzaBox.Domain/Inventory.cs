using System.Collections.Generic;
namespace PizzaBox.Domain
{
  public class InventoryItem
  {
    public PizzaComponent item;
    public int quantity;

    public InventoryItem(PizzaComponent i, int q)
    {
      item = i;
      quantity = q;
    }
  }
  public class Inventory
  {
    private List<Size> _sizes;
    private List<InventoryItem> _inventory;

    public void AddSize(Size s)
    {
      if(GetSize(s.Name) is null)
      {
        _sizes.Add(s);
      }
    }

    public void RemoveSize(string name)
    {
      Size s = GetSize(name);
      if(!(s is null))
      {
        _sizes.Remove(s);
      }
    }

    public Size GetSize(string name)
    {
      foreach (Size s in _sizes)
      {
        if(s.Name == name)
        {
          return s;
        }
      }
      return null;
    }
  
    public void SetInventory(PizzaComponent p, int amt)
    {
      InventoryItem i = GetInventoryItem(p.Name);
      if(!(i is null))
      {
        i.quantity += amt;
        i.item.Cost = p.Cost;
      }
      else
      {
        InventoryItem item = new InventoryItem(p, amt);
        _inventory.Add(i);
      }
    }


    public InventoryItem GetInventoryItem(string name)
    {
      foreach (InventoryItem i in _inventory)
      {
        if(i.item.Name == name)
        {
          return i;
        }
      }
      return null;
    }
    public void RemoveItem(string name)
    {
      InventoryItem i = GetInventoryItem(name);
      if (!(i is null))
      {
        _inventory.Remove(i);
      }
    }

  }
}