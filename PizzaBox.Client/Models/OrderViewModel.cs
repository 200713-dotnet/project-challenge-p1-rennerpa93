using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    public Store Store { get; set; }
    public User User { get; set; }
    public Order Order { get; set; }
  }
}
