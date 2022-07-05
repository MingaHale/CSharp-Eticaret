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
    internal class OrdersMap : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x => x.Id);
            // builder.Property(x => x.Id).ValueGeneratedOnAdd(); Id Sepete ürün eklerken oluşturulduğu için otomatik artan öz. iptal ettik
            builder.Property(x=> x.OrdersStatus).HasMaxLength(20).IsRequired();
            builder.Property(x => x.PaymentDate).HasColumnType("datetime");
            builder.Property(x => x.TotalDiscount).HasColumnType("money");
            builder.Property(x => x.TotalPrice).HasColumnType("money");
            builder.Property(x=> x.PaymentType).HasMaxLength(25).IsRequired();

            builder.HasMany(x=> x.OrderDetails).WithOne(x => x.Orders).HasForeignKey(x=>x.OrdersId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=> x.OrderAddresses).WithOne(x=> x.Orders).HasForeignKey(x=>x.OrdersId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Orders");
        }
    }
}
