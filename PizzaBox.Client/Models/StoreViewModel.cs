using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
    public int StoreId { get; set; }
    public string Location { get; set; }
    public Store Store { get; set; }
    public List<Store> Stores { get; set; }
    public bool Admin { get; set; }

  }
}
