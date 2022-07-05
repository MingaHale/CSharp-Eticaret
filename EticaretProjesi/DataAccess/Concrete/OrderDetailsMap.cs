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
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x=> x.Piece).IsRequired();
            builder.Property(x=> x.Price).HasColumnType("money").IsRequired();
            builder.Property(x=> x.ProductsId).IsRequired();
            builder.Property(x=> x.OrdersId).IsRequired();


            builder.HasOne(x=> x.Orders).WithMany(x=> x.OrderDetails).HasForeignKey(x=>x.OrdersId);//Teke çok ilişki



            builder.ToTable("OrderDetails");

        }
    }
}
