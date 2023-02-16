using BandAPIV2.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.DataAccess.Configurations
{
    public class BandConfiguration : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(300);
            builder.Property(x => x.Name).IsRequired(true);

            builder.Property(x => x.Country).HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired(true);


            builder.Property(x => x.Genre).HasMaxLength(300);
            builder.Property(x => x.Genre).IsRequired(true);
        }
    }
}
