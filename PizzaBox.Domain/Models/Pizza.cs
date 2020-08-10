using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Pizza : AModel
  {
    public double Price { get; set; }
    public string Name { get; set; }
    public List<PizzaTopping> PizzaToppings { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }

    public Pizza()
    {
      Price = 0;
      Name = "";
      PizzaToppings = new List<PizzaTopping>();
      Crust = new Crust();
      Size = new Size();
    }

    public double GetPrice()
    {
      double price = 0;
      foreach (PizzaTopping pt in PizzaToppings)
      {
        price += pt.Topping.Price;
      }
      price += Size.Price;
      price += Crust.Price;
      return price;
    }

    public override string ToString()
    {
      int count = 0;
      var sb = new StringBuilder();
      foreach (PizzaTopping pt in PizzaToppings)
      {
        if (count == 0)
        {
          sb.Append(pt.Topping);
        }
        else
        {
          sb.Append($" + {pt.Topping}");
        }
        count += 1;
      }

      return $"{Size} {Crust} crust {Name} with {sb}";
    }
  }
}
