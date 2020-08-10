using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Crust : AModel
  {
    public double Price { get; set; }
    public string Name { get; set; }
    public Crust()
    {
      Price = 0;
      Name = "";
    }
  }
}
