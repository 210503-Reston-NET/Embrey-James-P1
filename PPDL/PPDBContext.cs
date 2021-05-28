using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PPDL.Entities
{
    public partial class PPDBContext : DbContext
    {
        public PPDBContext()
        {
        }

        public PPDBContext(DbContextOptions<PPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.CustomerLocale)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customerLocale");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customerName");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.InventoryId).HasColumnName("inventoryID");

                entity.Property(e => e.InventoryCode).HasColumnName("inventoryCode");

                entity.Property(e => e.InventoryNumber).HasColumnName("inventoryNumber");

                entity.Property(e => e.InventoryQuantity).HasColumnName("inventoryQuantity");

                entity.HasOne(d => d.InventoryCodeNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.InventoryCode)
                    .HasConstraintName("FK__Inventory__inven__55209ACA");

                entity.HasOne(d => d.InventoryNumberNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.InventoryNumber)
                    .HasConstraintName("FK__Inventory__inven__542C7691");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.Property(e => e.LineItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("lineItemID");

                entity.Property(e => e.LineOrderId).HasColumnName("lineOrderID");

                entity.Property(e => e.LineProductId).HasColumnName("lineProductID");

                entity.Property(e => e.LineQuantityId).HasColumnName("lineQuantityID");

                entity.HasOne(d => d.LineOrder)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.LineOrderId)
                    .HasConstraintName("FK__LineItems__lineO__515009E6");

                entity.HasOne(d => d.LineProduct)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.LineProductId)
                    .HasConstraintName("FK__LineItems__lineP__505BE5AD");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.LocationCity)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("locationCity");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("locationName");

                entity.Property(e => e.LocationState)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("locationState");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.ManagerId).HasColumnName("managerID");

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("managerName");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("orderID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderLocation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("orderLocation");

                entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");

                entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");

                entity.Property(e => e.OrderTotal).HasColumnName("orderTotal");

                entity.HasOne(d => d.OrderNumberNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderNumber)
                    .HasConstraintName("FK__Orders__orderNum__4D7F7902");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
