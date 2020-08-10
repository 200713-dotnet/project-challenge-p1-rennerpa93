using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly PizzaBoxDbContext _db;

    public HomeController(ILogger<HomeController> logger, PizzaBoxDbContext db)
    {
      _logger = logger;
      _db = db;
    }

    public IActionResult Index()
    {
      StoreViewModel sModel = new StoreViewModel();
      StoreRepository sRepo = new StoreRepository(_db);
      sModel.Stores = sRepo.GetStores();
      return View("Index",sModel);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
