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

    public void Update(Order order)
    {
      _db.Update(order);
      _db.SaveChanges();
    }
    public Order Get(string id)
    {
      int orderId;
      int.TryParse(id, out orderId);

      Order o = _db.Order.FirstOrDefault(ot => ot.Id == orderId);
      o.Pizzas = new List<Pizza>();

      var PizzaList = _db.Pizza.Include(t => t.Crust).Include(t => t.Size).Where(t => t.Order == o).ToList();

      foreach (Pizza p in PizzaList)
      {
        o.Pizzas.Add(p);
      }

      return o;
    }

    public Order Get2(string id)
    {
      int orderId;
      int.TryParse(id, out orderId);

      Order o = _db.Order.FirstOrDefault(ot => ot.Id == orderId);
      o.Pizzas = new List<Pizza>();

      var PizzaList = _db.Pizza.Include(t => t.Crust).Include(t => t.Size).Where(t => t.Order == o).ToList();
      var pizzaToppings = new List<PizzaTopping>();
      foreach (Pizza p in PizzaList)
      {
        pizzaToppings = _db.PizzaToppings.Where(t => t.Pizza == p).Include(t => t.Topping).ToList();
        foreach (PizzaTopping pt in pizzaToppings)
        {
          p.PizzaToppings.Add(pt);
        }
        o.Pizzas.Add(p);
      }

      return o;
    }
    public void Add(Order o)
    {
      _db.Order.Add(o);
      _db.SaveChanges();
    }

    public List<Order> GetUserOrders(User user)
    {
      var OrdersList = _db.Order.Where(o => o.User == user).ToList();

      foreach (Order o in OrdersList)
      {
        var PizzaList = _db.Pizza.Include(t => t.Crust).Include(t => t.Size).Where(t => t.Order == o).ToList();

        foreach (Pizza p in PizzaList)
        {
          var pizzaToppings = _db.PizzaToppings.Where(t => t.Pizza == p).Include(t => t.Topping).ToList();
          foreach (PizzaTopping pt in pizzaToppings)
          {
            p.PizzaToppings.Add(pt);
          }
          o.Pizzas.Add(p);
        }
      }

      return OrdersList;
    }

    public List<Order> GetStoreOrders(Store store)
    {
      var OrdersList = _db.Order.Where(o => o.Store == store).ToList();

      foreach (Order o in OrdersList)
      {
        var PizzaList = _db.Pizza.Include(t => t.Crust).Include(t => t.Size).Where(t => t.Order == o).ToList();

        foreach (Pizza p in PizzaList)
        {
          var pizzaToppings = _db.PizzaToppings.Where(t => t.Pizza == p).Include(t => t.Topping).ToList();
          foreach (PizzaTopping pt in pizzaToppings)
          {
            p.PizzaToppings.Add(pt);
          }
          o.Pizzas.Add(p);
        }
      }

      return OrdersList;
    }
  }
}
