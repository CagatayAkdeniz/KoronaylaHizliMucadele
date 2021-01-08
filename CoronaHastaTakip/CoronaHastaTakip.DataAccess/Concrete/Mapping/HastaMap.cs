using CoronaHastaTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.DataAccess.Concrete.Mapping
{
    public class HastaMap : IEntityTypeConfiguration<Hasta>
    {
        public void Configure(EntityTypeBuilder<Hasta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasIndex(x => x.KimlikNo).IsUnique();
            builder.Property(x => x.AdSoyad).HasMaxLength(20);
            builder.Property(x => x.Aciklama).HasColumnType("ntext");

            builder.HasOne(x => x.Aciliyet).WithMany(x => x.Hastalar).HasForeignKey(x => x.AciliyetId);
            builder.HasMany(x => x.Raporlar).WithOne(x => x.Hasta).HasForeignKey(x => x.HastaId);
        }
    }
}
