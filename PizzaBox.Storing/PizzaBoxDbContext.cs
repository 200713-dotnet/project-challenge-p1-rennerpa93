using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizzas { get; set; } // create table
    public PizzaBoxDbContext(DbContextOptions options) : base(options) { } // dependency injection

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Pizza>().HasKey(e => e.Id); // primary constraint
      builder.Entity<Crust>().HasKey(e => e.Id);
      builder.Entity<Size>().HasKey(e => e.Id);
      builder.Entity<Topping>().HasKey(e => e.Id);
      builder.Entity<PizzaTopping>().HasKey(e => e.Id);
      builder.Entity<Store>().HasKey(e => e.Id);
      builder.Entity<Order>().HasKey(e => e.Id);
      builder.Entity<User>().HasKey(e => e.Id);
    }
  }
}
