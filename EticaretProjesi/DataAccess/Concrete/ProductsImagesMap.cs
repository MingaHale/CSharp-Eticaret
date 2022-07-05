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
    public class ProductsImagesMap : IEntityTypeConfiguration<ProductsImages>
    {
        public void Configure(EntityTypeBuilder<ProductsImages> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductsId);

            builder.HasOne(x => x.Products).WithMany(x=> x.ProductsImages).HasForeignKey(x=> x.ProductsId);

            builder.ToTable("ProductsImages");
        }
    }
}
