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
  


    public class CustomerGenreConfiguration : IEntityTypeConfiguration<CustomerGenre>
    {
        public void Configure(EntityTypeBuilder<CustomerGenre> builder)
        {
            builder.HasKey(dm => new { dm.GenreId, dm.CustomerId });
            builder.HasOne(dm => dm.Genre).WithMany(dm => dm.AppCustomers).HasForeignKey(dm => dm.GenreId);
            builder.HasOne(dm => dm.Customer).WithMany(dm => dm.FavouriteGenres).HasForeignKey(dm => dm.CustomerId);
        }
    }
}
