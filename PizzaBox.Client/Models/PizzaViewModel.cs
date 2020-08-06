﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    public List<Crust> Crusts { get; set; }
    public List<Size> Sizes { get; set; }
    public List<Topping> Toppings { get; set; }

    [Required(ErrorMessage = "Please select a crust")]
    public string Crust { get; set; }
    [Required(ErrorMessage = "Please select a Size")]
    public string Size { get; set; }
    [Required(ErrorMessage = "Please select 2-5 toppings")]
    [MinLength(2)]
    [MaxLength(5)]
    public List<SelectedTopping> SelectedToppings { get; set; }

    public class SelectedTopping : Topping
    {
      public bool IsSelected { get; set; }
    }

    public PizzaViewModel()
    {
      Crusts = new List<Crust>() { new Crust() { Name = "Stuffed" }, new Crust() { Name = "Normal" } };

      Sizes = new List<Size>() { new Size() { Name = "Small" }, new Size() { Name = "Medium" } };

      Toppings = new List<Topping>() { new Topping() { Name = "Cheese" }, new Topping() { Name = "Pepperoni" } };

      SelectedToppings = new List<SelectedTopping>();
      for (int i = 0; i < Toppings.Count; i++)
      {
        SelectedToppings.Add(new SelectedTopping());
      }
    }
  }
}
