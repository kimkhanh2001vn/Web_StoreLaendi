using LaendiStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Data.DBContext
{
    public class eLaendiStoreDBContext : DbContext
    {
        public eLaendiStoreDBContext()
                    : base("name=eLaendiStoreDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.category)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
               .HasMany(e => e.OrderDetails)
               .WithRequired(e => e.Order)
               .HasForeignKey(e => e.OrderID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
               .HasMany(e => e.OrderDetails)
               .WithRequired(e => e.Product)
               .HasForeignKey(e => e.ProductID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
               .HasMany(e => e.Shippers)
               .WithRequired(e => e.Store)
               .HasForeignKey(e => e.StoreID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
               .HasMany(e => e.Orders)
               .WithRequired(e => e.Customer)
               .HasForeignKey(e => e.CustomerId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipper>()
               .HasMany(e => e.Orders)
               .WithRequired(e => e.Shipper)
               .HasForeignKey(e => e.ShipperID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
               .HasMany(e => e.Stores)
               .WithRequired(e => e.User)
               .HasForeignKey(e => e.UserID)
               .WillCascadeOnDelete(false);

        }
    }
}
