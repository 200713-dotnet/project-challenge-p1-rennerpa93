using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Factories
{
  public class CrustFactory : IFactory<Crust>
  {
    public Crust Create()
    {
      return new Crust();
    }
  }
}
