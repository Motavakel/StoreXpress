﻿using Domain.Entities.Identity;
using Domain.Entities.ProductEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities.Order;

namespace Infrastructure.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
    UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    //for product
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductType> ProductType => Set<ProductType>();
    public DbSet<ProductBrand> ProductBrand => Set<ProductBrand>();

    //for identity
    public DbSet<User> User => Set<User>();
    public DbSet<Role> Role => Set<Role>();
    public DbSet<UserRole> UserRole => Set<UserRole>();

    public DbSet<Address> Address => Set<Address>();



    //order
    public DbSet<Order> Order => Set<Order>();
    public DbSet<OrderItem> OrderItem => Set<OrderItem>();
    public DbSet<DeliveryMethod> DeliveryMethod => Set<DeliveryMethod>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<ProductBrand>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<ProductType>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<Address>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<Order>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<DeliveryMethod>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<OrderItem>().HasQueryFilter(x => x.IsDelete == false);
    }
}