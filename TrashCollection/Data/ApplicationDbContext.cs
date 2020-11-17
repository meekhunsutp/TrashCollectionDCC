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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                        {
                          Name = "Admin",
                          NormalizedName = "ADMIN"
                        }
                );
        }
        public DbSet<TrashCollection.Models.Customer> Customer { get; set; }
        public DbSet<TrashCollection.Models.Address> Address { get; set; }
        public DbSet<TrashCollection.Models.Employee> Employee { get; set; }
    }
}
