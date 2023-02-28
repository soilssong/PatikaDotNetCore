using BandAPIV3.Practicum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BandAPIV3.Practicum.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUsers).HasForeignKey(x => x.AppRoleId);
        }


        public class BandConfiguration : IEntityTypeConfiguration<Band>
        {
            public void Configure(EntityTypeBuilder<Band> builder)
            {
                builder.HasOne(x => x.Genre).WithMany(x => x.Bands).HasForeignKey(x => x.GenreId);

                builder.HasOne(x => x.Musician).WithMany(x => x.Bands).HasForeignKey(x => x.MusicianId);
            }
        }
    }
}
