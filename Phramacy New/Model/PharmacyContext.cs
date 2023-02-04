using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Model
{
    public class PharmacyContext:DbContext
    {
       public PharmacyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines{ get; set; }
        public DbSet<Store> Stores{ get; set; }
        public DbSet<Beauty> Beauties{ get; set; }
        public DbSet<Feedback>Feedbacks { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();  

        }
    }
}
