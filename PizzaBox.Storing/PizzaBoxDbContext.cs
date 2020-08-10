using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; } // create table
    public DbSet<Crust> Crust { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Topping> Topping { get; set; }
    public DbSet<PizzaTopping> PizzaToppings { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<User> User { get; set; }
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
