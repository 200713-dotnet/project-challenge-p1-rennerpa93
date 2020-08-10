using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Topping : AModel
  {
    public double Price { get; set; }
    public string Name { get; set; }
    public List<PizzaTopping> PizzaToppings { get; set; }
    
    public Topping()
    {
      Price = 0;
      Name = "";
      PizzaToppings = new List<PizzaTopping>();
    }
  }
}
