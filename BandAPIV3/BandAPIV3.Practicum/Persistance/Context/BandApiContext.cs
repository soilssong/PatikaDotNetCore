using BandAPIV3.Practicum.Core.Domain;
using BandAPIV3.Practicum.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BandAPIV3.Practicum.Persistance.Context
{
    public class BandApiContext : DbContext
    {
        public BandApiContext(DbContextOptions<BandApiContext> options): base(options)
        {
        }


        public DbSet<Band> Bands { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Musician> Musicians { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelbuilder);
        }
    }
}
