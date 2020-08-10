using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Factories
{
  public class StoreFactory : IFactory<Store>
  {
    public Store Create()
    {
      return new Store();
    }
  }
}
