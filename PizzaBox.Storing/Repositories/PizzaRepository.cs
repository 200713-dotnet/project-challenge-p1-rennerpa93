using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository
  {
    private PizzaBoxDbContext _db;

    public PizzaRepository(PizzaBoxDbContext db)
    {
      _db = db;
    }

    public void Add(Pizza p)
    {
      _db.Pizza.Add(p);
      _db.SaveChanges();
    }

    public Pizza Get(int id)
    {
      return _db.Pizza.Find(id);
    }

  }
}
