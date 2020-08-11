using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    private readonly PizzaBoxDbContext _db;
    public StoreRepository(PizzaBoxDbContext db)
    {
      _db = db;
    }
    public List<Store> GetStores()
    {
      return _db.Store.ToList();
    }

    public Store GetStoreByLocation(string loc)
    {
      return _db.Store.FirstOrDefault(s => s.Location == loc);
    }

    public Store GetStoreById(string id)
    {
      int storeId;
      int.TryParse(id, out storeId);
      return _db.Store.FirstOrDefault(s => s.Id == storeId);
    }
  }
}