﻿using System.Reflection;
using Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infraestructure.Context
{
    public interface ICustomersDbContext : IDbContext { }

    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : BaseDbContext(options), ICustomersDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetAssembly(typeof(CustomerDbContext));

            if (assembly is not null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            }

            modelBuilder.Entity<Contact>()
                .HasAlternateKey(c => new { c.Email, c.DeletedToken });

            modelBuilder.Entity<Customer>()
                .HasAlternateKey(c => new { c.IdentificationNumber, c.DeletedToken });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
