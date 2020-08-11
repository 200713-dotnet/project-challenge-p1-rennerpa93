using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Factories
{
  public class PizzaFactory : IFactory<Pizza>
  {
    public Pizza Create()
    {
      return new Pizza();
    }

    public Pizza CreateCustom()
    {
      return new Pizza() { Name = "Custom Pizza" };
    }

  }
}