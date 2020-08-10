using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Factories
{
  public class SizeFactory : IFactory<Size>
  {
    public Size Create()
    {
      return new Size();
    }
  }
}
