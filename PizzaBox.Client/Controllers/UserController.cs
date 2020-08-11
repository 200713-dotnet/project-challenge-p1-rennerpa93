using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    private readonly PizzaBoxDbContext _db;
    public UserController(PizzaBoxDbContext db)
    {
      _db = db;
    }
    public ActionResult Login(StoreViewModel sModel)
    {
      if (sModel.Admin)
      {
        return View("Store", sModel);
      }
      ViewBag.Location = sModel.Location;
      return View("Login");
    }

    public ActionResult Logout()
    {
      ViewData["User"] = null;
      return Redirect("../Home/Index");
    }

    public ActionResult Home(UserViewModel uModel)
    {
      if (uModel.Name == null)
      {
        return View("Login");
      }
      UserRepository uRepo = new UserRepository(_db);
      User u = uRepo.GetUserByName(uModel.Name);
      if (u == null)
      {
        u = new User() { Name = uModel.Name, Orders = new List<Order>() };
        uRepo.Add(u);
      }
      uModel.User = u;
      ViewBag.User = u;
      ViewBag.Location = uModel.Location;
      return View("Home", uModel);
    }

    [HttpPost]
    public IActionResult SubmitOrder(PizzaViewModel pModel)
    {
      StoreRepository sRepo = new StoreRepository(_db);
      OrderRepository oRepo = new OrderRepository(_db);
      UserRepository uRepo = new UserRepository(_db);
      User u = uRepo.GetUserByName(pModel.Username);
      Order o = oRepo.Get(pModel.OrderId);
      Store s = sRepo.GetStoreByLocation(pModel.Location);
      o.Store = s;
      o.User = u;
      o.Status = "Complete";
      oRepo.Update(o);
      UserViewModel uModel = new UserViewModel();
      uModel.User = u;
      uModel.Store = s;
      ViewBag.User = u;
      ViewBag.Location = pModel.Location;

      return View("Home", uModel);
    }
  }
}
