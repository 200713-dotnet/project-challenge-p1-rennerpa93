using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using static PizzaBox.Client.Models.PizzaViewModel;

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
      PizzaViewModel pModel = new PizzaViewModel();
      StoreRepository sRepo = new StoreRepository(_db);
      UserRepository uRepo = new UserRepository(_db);
      OrderRepository oRepo = new OrderRepository(_db);
      pModel.Username = uModel.Name;
      pModel.Location = uModel.Location;
      pModel.Order = new Order();
      pModel.Order.Store = sRepo.GetStoreByLocation(uModel.Location);
      pModel.Order.User = uRepo.GetUserByName(uModel.Name);
      oRepo.Add(pModel.Order);
      return View("Order", pModel);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult FinishPizza(PizzaViewModel pModel)
    {
      //if (ModelState.IsValid)
      //{
      //  return Redirect("user/home");
      //}

      PizzaViewModel npModel = new PizzaViewModel();
      OrderRepository oRepo = new OrderRepository(_db);
      PizzaRepository pRepo = new PizzaRepository(_db);
      CrustRepository cRepo = new CrustRepository(_db);
      SizeRepository sRepo = new SizeRepository(_db);
      ToppingRepository tRepo = new ToppingRepository(_db);
      PizzaFactory pf = new PizzaFactory();
      Crust c = cRepo.GetCrustByName(pModel.Crust);
      Size s = sRepo.GetSizeByName(pModel.Size);
      List<Topping> t = new List<Topping>();
      foreach(SelectedTopping st in pModel.SelectedToppings)
      {
        if (st.IsSelected)
        {
          t.Add(tRepo.GetToppingByName(st.Text));
        }
      }
      
      npModel.Username = pModel.Username;
      npModel.Location = pModel.Location;
      npModel.Order = oRepo.Get(pModel.OrderId);
      return View("Order", npModel);
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
      ViewBag.Location = uModel.Location;
      return View("ViewOrders", uModel);
    }

    [HttpPost]
    public IActionResult AddPizza(PizzaViewModel pModel)
    {
      CrustRepository cRepo = new CrustRepository(_db);
      SizeRepository sRepo = new SizeRepository(_db);
      ToppingRepository tRepo = new ToppingRepository(_db);
      OrderRepository oRepo = new OrderRepository(_db);
      UserRepository uRepo = new UserRepository(_db);
      pModel.User = uRepo.GetUserByName(pModel.Username);
      pModel.Order = oRepo.Get(pModel.OrderId);
      pModel.Crusts = cRepo.GetCrusts();
      pModel.Sizes = sRepo.GetSizes();
      pModel.Toppings = tRepo.GetToppings();
      foreach (Topping t in pModel.Toppings)
      {
        pModel.SelectedToppings.Add(new PizzaViewModel.SelectedTopping() { Text = t.Name, IsSelected = false });
      }
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
