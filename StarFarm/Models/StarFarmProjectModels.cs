using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace StarFarm.Models
{
    public partial class StarFarmProjectModels : DbContext
    {
        public StarFarmProjectModels()
            : base("name=StarFarmProjectModels")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Category_Id)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Category>()
                .Property(e => e.Category_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Id)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Product_Id)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Category_Id)
                .HasPrecision(5, 0);
        }
    }
}
