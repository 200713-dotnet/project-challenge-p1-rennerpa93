using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
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
      ViewBag.pizzaList = _db.Pizza.ToList();

      return View("Home");
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      ViewBag.pizza = _db.Pizza.SingleOrDefault(p => p.Id == id);
      return View("Home");
    }

    [HttpGet("{userId}")]
    public IActionResult Get(int orderId, string idType = "Order")
    {
      ViewBag.pizzaList = _db.Pizza.ToList();

      return View("Home2", _db.Pizza.ToList());
    }
  }
}
