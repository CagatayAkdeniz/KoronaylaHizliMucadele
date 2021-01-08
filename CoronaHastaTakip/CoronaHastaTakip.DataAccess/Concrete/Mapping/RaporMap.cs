using CoronaHastaTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.DataAccess.Concrete.Mapping
{
    public class RaporMap : IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Tanim).HasMaxLength(70);
            builder.Property(x => x.Detay).HasColumnType("ntext");
        }
    }
}
