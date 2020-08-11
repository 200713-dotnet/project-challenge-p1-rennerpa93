using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTest
  {
    [Fact]
    public void Test_Pizza()
    {
      Pizza p = new Pizza();
      p.Name = "Cheese Pizza";
      p.Size = new Size(){ Name = "Small", Price = 5.00 };
      p.Crust = new Crust(){ Name = "Normal", Price = 0 };
      p.PizzaToppings = new List<PizzaTopping>() { new PizzaTopping() { Topping = new Topping() { Name = "Cheese", Price = 0.25 } } };
      Assert.IsType<Pizza>(p);
    }

    [Fact]
    public void Test_PizzaCalculate()
    {
      double act = 5.25;
      Pizza p = new Pizza();
      p.Name = "Cheese Pizza";
      p.Size = new Size() { Name = "Small", Price = 5.00 };
      p.Crust = new Crust() { Name = "Normal", Price = 0 };
      p.PizzaToppings = new List<PizzaTopping>() { new PizzaTopping() { Topping = new Topping() { Name = "Cheese", Price = 0.25 } } }; 
      double res = p.GetPrice();
      Assert.Equal(act, res);
    }
  }
}