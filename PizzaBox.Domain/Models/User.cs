using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class User : AModel
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
    public DateTime LastOrdered { get; set; }

    public User()
    {
      Name = "";
      Orders = new List<Order>();
    }
  }
}
