using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderRepositoryTest
  {
    [Fact]
    public void AddOrderTest()
    {
      
      Store s = new Store();
      s.Location = "Michigan";
      User u = new User();
      u.Name = "Patrick";
      Order o = new Order();
      o.Date = DateTime.Now;
      o.Status = "Complete";
      o.Store = s;
      o.User = u;
      Pizza p = new Pizza();
      Topping t = new Topping();
      PizzaTopping pt = new PizzaTopping();
      p.Crust.Name = "Normal";
      p.Crust.Price = 0.25;
      p.Size.Name = "Small";
      p.Size.Price = 5.00;
      t.Name = "Cheese";
      t.Price = 0.25;
      t.PizzaToppings.Add(pt);
      p.PizzaToppings.Add(pt);

    }
  }
}
