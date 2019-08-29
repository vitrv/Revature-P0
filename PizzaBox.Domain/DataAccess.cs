using PizzaBox.Data.Entities;

namespace PizzaBox.Domain
{
  public class DataAccess
  {
    public void SaveUser(Domain.User u)
    {
      
    }
    public Domain.User GetUser(string name)
    {
      return new Domain.User(name);
    }
  }
}