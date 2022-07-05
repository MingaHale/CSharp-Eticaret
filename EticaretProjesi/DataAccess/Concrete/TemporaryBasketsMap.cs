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
    internal class TemporaryBasketsMap : IEntityTypeConfiguration<TemporaryBaskets>
    {
        public void Configure(EntityTypeBuilder<TemporaryBaskets> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x=> x.ProductsId).IsRequired();
            builder.Property(x=> x.Piece).IsRequired();
            builder.Property(x => x.Discount).IsRequired();
            builder.Property(x => x.Discount).HasColumnType("money");
            builder.Property(x=> x.BasketCookies).IsRequired();

            builder.ToTable("TemporaryBaskets");
        }
    }
}
