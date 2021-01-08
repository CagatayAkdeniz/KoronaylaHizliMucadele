using CoronaHastaTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.DataAccess.Concrete.Mapping
{
    public class BildirimMap : IEntityTypeConfiguration<Bildirim>
    {
        public void Configure(EntityTypeBuilder<Bildirim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Mesaj).HasColumnType("ntext").IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Bildirimler).HasForeignKey(x => x.AppUserId);
        }

    }
}
