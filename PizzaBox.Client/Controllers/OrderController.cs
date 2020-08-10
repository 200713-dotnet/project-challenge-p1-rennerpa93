using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

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

    public IActionResult Order(UserViewModel uModel)
    {
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel)
    {
      if (ModelState.IsValid)
      {
        return Redirect("user/home");
      }

      return View("Order", pizzaViewModel);
    }

    [HttpPost]
    public IActionResult ViewOrders(UserViewModel uModel)
    {
      if (uModel.Name == null)
      {
        return Redirect("../Home/Index");
      }
      OrderRepository oRepo = new OrderRepository(_db);
      UserRepository uRepo = new UserRepository(_db);
      uModel.User = uRepo.GetUserByName(uModel.Name);
      uModel.User.Orders = oRepo.GetUserOrders(uModel.User);
      return View("ViewOrders", uModel);
    }

    [HttpPost]
    public IActionResult AddPizza(OrderViewModel oModel)
    {
      PizzaViewModel pModel = new PizzaViewModel();
      CrustRepository cRepo = new CrustRepository(_db);
      SizeRepository sRepo = new SizeRepository(_db);
      ToppingRepository tRepo = new ToppingRepository(_db);
      pModel.Order = oModel.Order;
      pModel.Crusts = cRepo.GetCrusts();
      pModel.Sizes = sRepo.GetSizes();
      pModel.Toppings = tRepo.GetToppings();

      return View("AddPizza", pModel);
    }

    [HttpPost]
    public IActionResult ViewStoreOrders(StoreViewModel sModel)
    {
      if (sModel.Location == null)
      {
        return Redirect("../Home/Index");
      }
      OrderRepository oRepo = new OrderRepository(_db);
      StoreRepository sRepo = new StoreRepository(_db);
      sModel.Store = sRepo.GetStoreByLocation(sModel.Location);
      sModel.Store.Orders = oRepo.GetStoreOrders(sModel.Store);
      return View("ViewStoreOrders", sModel);
    }
  }
}
