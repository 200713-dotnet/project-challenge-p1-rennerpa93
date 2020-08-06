using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Topping : AModel
  {
    public double Price { get; set; }
    public string Name { get; set; }
  }
}
