namespace PizzaBox.Domain
{
  public abstract class PizzaComponent
  {

    public string Name {get;}
    public decimal Cost {get; set;}
    

    public PizzaComponent(string _name, decimal _cost)
    {
      Name = _name;
      Cost = _cost;
    }

    public override string ToString()
    {
      return Name + " " + Cost;
    }

  }
      
    
}