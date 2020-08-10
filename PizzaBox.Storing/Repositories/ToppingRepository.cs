using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
  public class ToppingRepository
  {
    private readonly PizzaBoxDbContext _db;

    public ToppingRepository(PizzaBoxDbContext db)
    {
      _db = db;
    }
    public List<Topping> GetToppings()
    {
      return _db.Topping.ToList();
    }
  }
}
