using CoronaHastaTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.DataAccess.Concrete.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x => x.Surname).HasMaxLength(30);

            builder.HasMany(x => x.Hastalar).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
