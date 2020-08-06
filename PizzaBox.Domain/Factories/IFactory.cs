using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Factories
{
  public interface IFactory<T> where T : class, new()
  {
    T Create();
  }
}