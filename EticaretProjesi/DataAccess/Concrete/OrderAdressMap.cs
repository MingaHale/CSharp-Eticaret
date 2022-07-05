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
    public class OrderAdressMap : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.City).HasMaxLength(30).IsRequired();
            builder.Property(x=> x.Distrinct).HasMaxLength(40).IsRequired();
            builder.Property(x=> x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x=> x.FullAddress).HasMaxLength(500).IsRequired();
            builder.Property(x=> x.OrdersId).IsRequired();
            builder.Property(x=> x.AddressType).IsRequired();


            builder.HasOne(x=> x.Orders).WithMany(x=> x.OrderAddresses).HasForeignKey(x=> x.OrdersId);


            builder.ToTable("OrdesAdress");
        }
    }
}
