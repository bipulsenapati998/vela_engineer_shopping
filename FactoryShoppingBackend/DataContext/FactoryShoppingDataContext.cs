using DataAccessLayer.FactoryShoppingModel;
using FactoryShopping.Models.FactoryShoppingModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataContext
{
    public class FactoryShoppingDataContext: DbContext
    {
        public FactoryShoppingDataContext() { }
        public FactoryShoppingDataContext(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
           optionsBuilder.UseSqlServer(@"Server=XIPL9397\SQLEXPRESS;Database=Vela_Engineer;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> cart { get; set; }
       // public DbSet<OrderDetails> orderDetail { get; set; }
        //public DbSet<AddressType> addressType { get; set; }
        public DbSet<Feedback> feedback { get; set; }
        public DbSet<Wishlist> wishlist { get; set; }
        public DbSet<Address_Checkout> addresses { get; set; }
        public DbSet<OrderDetails> myOrders { get; set; }
    }
}
