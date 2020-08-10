using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class SizeRepository
  {
    private readonly PizzaBoxDbContext _db;
    public SizeRepository(PizzaBoxDbContext db)
    {
      _db = db;
    }
    public List<Size> GetSizes()
    {
      return _db.Size.ToList();
    }
  }
}