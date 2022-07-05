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
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.Id);//primary key
            builder.Property(x=> x.Email).HasMaxLength(50).IsRequired();//ncarchar50, doldurulması zorunlu
            builder.Property(X=> X.NameSurname).HasMaxLength(150).IsRequired();
            builder.Property(x=> x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x=> x.AdvertNotice).IsRequired();
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();//Otomatik artan
            builder.Property(x => x.Passwords).HasMaxLength(30).IsRequired();
            builder.ToTable("Customers");
        }
    }
}
