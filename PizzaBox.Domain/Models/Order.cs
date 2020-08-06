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

  }
}
