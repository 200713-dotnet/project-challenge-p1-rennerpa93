using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Size : AModel
  {
    public double Price { get; set; }
    public string Name { get; set; }

    public Size()
    {
      Price = 0;
      Name = "";
    }
    public override string ToString()
    {
      return Name;
    }
  }
}
