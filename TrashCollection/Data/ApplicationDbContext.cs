using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollection.Models;

namespace TrashCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE"},
                new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER"});
        }
    }
}
