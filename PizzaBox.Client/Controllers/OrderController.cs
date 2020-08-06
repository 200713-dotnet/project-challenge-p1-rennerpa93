using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  //[Route("/[controller]/[action]")]
  //[EnableCors()]
  public class OrderController : Controller
  {
    private readonly PizzaBoxDbContext _db;

    public OrderController(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public IActionResult Order()
    {
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel)
    {
      if (ModelState.IsValid)
      {
        return Redirect("user/index");
      }

      return View("Order", pizzaViewModel);
    }
  }
}
