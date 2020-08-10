using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
  public class UserViewModel
  {
    public string Name { get; set; }
    public User User { get; set; }
    public string Location { get; set; }
    public Store Store { get; set; }

  }
}
