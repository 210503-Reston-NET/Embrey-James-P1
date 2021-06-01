using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PPModels;

#nullable disable

namespace PPDL.Entities
{
    public partial class PPDBContext : DbContext
    {

        public PPDBContext(DbContextOptions<PPDBContext> options)
            : base(options)
        {

        }

        protected PPDBContext()
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        /*public virtual DbSet<LineItem> LineItems { get; set; }*/
        public DbSet<Location> Location { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Products> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Customer>()
            .Property(Custo => Custo.Name)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>()
            .Property(Custo => Custo.InventoryId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>()
            .Property(Custo => Custo.Name)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Manager>()
            .Property(Custo => Custo.mId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
            .Property(Custo => Custo.OrderId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Products>()
            .Property(Custo => Custo.ProductId)
            .ValueGeneratedOnAdd();
        }
    }
}
