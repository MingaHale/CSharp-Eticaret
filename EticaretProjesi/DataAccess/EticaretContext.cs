using DataAccess.Concrete;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EticaretContext : DbContext
    {
        //Hangi tablolar nasıl yönetilecek
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderAddress> OrderAddress { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsImages> ProductsImages { get; set; }
        public DbSet<TemporaryBaskets> TemporaryBaskets { get; set; }

        //Hangi veri tabanı kullanılacak nasıl bağlantı sağlanacak?
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7HVKD3N\SQLEXPRESS02;Database=EticaretDatabase;Trusted_Connection=True;");
        }


        //Bu tabloların içerisinde ki sütunları kim yönetecek?
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Products>(new ProductsMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderAdressMap());
            modelBuilder.ApplyConfiguration(new OrderDetailsMap());
            modelBuilder.ApplyConfiguration(new OrdersMap());
            modelBuilder.ApplyConfiguration(new ProductsImagesMap());
            modelBuilder.ApplyConfiguration(new TemporaryBasketsMap());

        }
    }
}
