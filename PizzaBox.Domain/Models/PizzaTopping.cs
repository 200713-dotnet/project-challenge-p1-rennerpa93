using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class PizzaTopping : AModel
  {
    public Pizza Pizza { get; set; }
    public Topping Topping { get; set; }

    public PizzaTopping()
    {
      Pizza = new Pizza();
      Topping = new Topping();
    }

  }
}
