namespace PizzaBox.Domain
{
  public class PizzaFactory
  {
    //this entire class is awful, come up with something better
    Location _location;

    public PizzaFactory(Location loc)
    {
      _location = loc;
    }
    public string ListPresets()
    {
      return "Specialty Pizzas:\n"
              + "hawaiian";
    }
    public Pizza MakeHawaiian()
    {
      InventoryItem hamItem =  _location.Inventory.GetInventoryItem("Ham");
      InventoryItem pineappleItem = _location.Inventory.GetInventoryItem("Pineapple");

      if(!(hamItem is null) && !(pineappleItem is null))
      {
        Topping ham = (Topping) hamItem.item;
        Topping pineapple = (Topping) pineappleItem.item;
        Pizza p = new Pizza();
        p.AddTopping(ham);
        p.AddTopping(pineapple);
        return p;
      }
      else return null;

    }
      
  }
}