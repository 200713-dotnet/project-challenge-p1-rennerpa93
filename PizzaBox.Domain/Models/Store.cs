using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Store : AModel
  {
    public List<Order> Orders { get; set; }
    public string Location { get; set; }

  }
}
