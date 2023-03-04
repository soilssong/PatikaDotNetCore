using Entities.Domains.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ActorMovieConfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasKey(dm => new { dm.MovieId, dm.ActorId });

            builder.HasOne(dm => dm.Movie).WithMany(dm => dm.Actors).HasForeignKey(dm => dm.MovieId);
            builder.HasOne(dm => dm.Actor).WithMany(dm => dm.Movies).HasForeignKey(dm => dm.ActorId);
        }
    }
}
