using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductsMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x=> x.Price).HasColumnType("money").IsRequired();
            builder.Property(x => x.Discount).HasColumnType("money").IsRequired();
            builder.Property(x=> x.Stock).IsRequired();

            //bir ürünü çağırdığımzda ona bağlı olan kaç resim var ise gelsin
            builder.HasMany(x=> x.ProductsImages).WithOne(x=> x.Products).HasForeignKey(x=> x.ProductsId);

            //bir ürünü çağırdığımızda ona bağlı olan kategorisi de gelsin
            builder.HasOne(X=> X.Categories).WithMany(x=> x.Products).HasForeignKey(x=> x.CategoriesId);

            builder.ToTable("Products");
        }
    }
}
