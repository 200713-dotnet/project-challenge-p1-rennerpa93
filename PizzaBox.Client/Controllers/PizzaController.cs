using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {
    private readonly PizzaBoxDbContext _db;

    public PizzaController(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    [HttpGet()]
    public IActionResult Get()
    {
      ViewBag.pizzaList = _db.Pizzas.ToList();

      return View("Home");
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      ViewBag.pizza = _db.Pizzas.SingleOrDefault(p => p.Id == id);
      return View("Home");
    }

    [HttpGet("{userId}")]
    public IActionResult Get(int orderId, string idType = "Order")
    {
      ViewBag.pizzaList = _db.Pizzas.ToList();

      return View("Home2", _db.Pizzas.ToList());
    }
  }
}
