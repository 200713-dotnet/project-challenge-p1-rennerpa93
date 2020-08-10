using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class CrustRepository
  {
    private readonly PizzaBoxDbContext _db;
    public CrustRepository(PizzaBoxDbContext db)
    {
      _db = db;
    }
    public List<Crust> GetCrusts()
    {
      return _db.Crust.ToList();
    }

    public Crust GetCrustByName(string name)
    {
      return _db.Crust.FirstOrDefault(c => c.Name == name);
    }
  }
}
