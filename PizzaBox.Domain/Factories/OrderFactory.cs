using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Factories
{
  public class OrderFactory : IFactory<Order>
  {
    public Order Create()
    {
      return new Order();
    }
  }
}
