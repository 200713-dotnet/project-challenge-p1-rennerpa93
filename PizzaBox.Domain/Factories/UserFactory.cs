using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Factories
{
  public class UserFactory : IFactory<User>
  {
    public User Create()
    {
      return new User();
    }
  }
}
