using BandAPI_V2_DataAccess.Configurations;
using BandAPI_V2_Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_DataAccess.Contexts
{
    public class BandContext : DbContext
    {

        public BandContext(DbContextOptions<BandContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BandConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Band> Bands { get; set; }
    }
}
