using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private PizzaBoxDbContext _db;
    public OrderRepository(PizzaBoxDbContext db)
    {
      _db = db;
    }

    public Order Get(string id)
    {
      int orderId;
      int.TryParse(id, out orderId);
      return _db.Order.FirstOrDefault(o => o.Id == orderId);
    }
    public void Add(Order o)
    {
      _db.Order.Add(o);
      _db.SaveChanges();
    }

    public List<Order> GetUserOrders(User user)
    {
      return _db.Order.Where(o => o.User == user).Include(o => o.Pizzas).ThenInclude(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).ToList();
    }

    public List<Order> GetStoreOrders(Store store)
    {
      return _db.Order.Where(o => o.Store == store).Include(o => o.Pizzas).ThenInclude(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).ToList();
      //return _db.Order.Where(o => o.Store == store).ToList();
    }
  }
}
