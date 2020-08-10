using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private readonly PizzaBoxDbContext _db;

    public UserRepository(PizzaBoxDbContext db)
    {
      _db = db;
    }

    public void Add(User user)
    {
      _db.User.Add(user);
      _db.SaveChanges();
    }

    public User GetUserByName(string name)
    {
      return _db.User.FirstOrDefault(u => u.Name == name);
    }

    public void Update(User user)
    {
      _db.Update(user);
      _db.SaveChanges();
    }
  }
}
