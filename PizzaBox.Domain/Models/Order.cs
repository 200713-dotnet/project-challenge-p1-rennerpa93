using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public User User { get; set; }
    public Store Store { get; set; }
    public List<Pizza> Pizzas { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }

    public Order()
    {
      User = new User();
      Store = new Store();
      Pizzas = new List<Pizza>();
      Date = DateTime.Now;
      Status = "Incomplete";
    }

    //public void CreatePizza(Store store)
    //{
    //  Pizza pizza = store.ChoosePizza();
    //  pizza.Size = store.ChooseSize();
    //  pizza.Crust = store.ChooseCrust();
    //  if ((this.CalculatePrice() + pizza.GetPrice()) > 250)
    //  {
    //    System.Console.WriteLine("Pizza cannot be added as the order will exceed the $250 limit!");
    //    System.Console.WriteLine();
    //    return;
    //  }
    //  Pizzas.Add(pizza);
    //}

    public double CalculatePrice()
    {
      double price = 0;
      foreach (Pizza p in Pizzas)
      {
        price += p.GetPrice();
      }
      return price;
    }

    public override string ToString()
    {
      int count = 1;
      var sb = new StringBuilder();
      if (Pizzas.Count < 1)
      {
        sb.Append("There are no pizzas!");
        return $"{sb}\n Status: {Status} \n Total Cost: ${CalculatePrice()}\n";
      }
      foreach (Pizza p in Pizzas)
      {
        if (count == 1)
        {
          sb.Append($"{count} : {p} - Price: ${p.GetPrice()}");
        }
        else
        {
          sb.Append($"\n{count} : {p} - Price: ${p.GetPrice()}");
        }
        count += 1;
      }

      return $"{sb}\nDate Ordered: {Date} -- Status: {Status} \n Total Cost: ${CalculatePrice()}\n";
    }
  }
}
