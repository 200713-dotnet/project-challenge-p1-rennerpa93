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
      var p = new Pizza();

      p.Crust = new Crust();
      p.Size = new Size();
      p.Toppings = new List<Topping> { new Topping() };

      return p;
    }
  }
}