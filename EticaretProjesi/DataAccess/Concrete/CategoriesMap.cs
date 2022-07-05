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
    public class CategoriesMap : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.Name).HasMaxLength(50).IsRequired();

            //bir kategorinin birden fazla ürünü vardır. Tek'e çok ilişki
            builder.HasMany<Products>(x => x.Products).WithOne(x => x.Categories).HasForeignKey(x => x.CategoriesId);

            builder.ToTable("Categories");//veri tabanında bu isimle oluş
        }
    }
}
