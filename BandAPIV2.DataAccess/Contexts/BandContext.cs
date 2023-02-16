using BandAPIV2.DataAccess.Configurations;
using BandAPIV2.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.DataAccess.Contexts
{
    public class BandContext : DbContext
    {
        public BandContext(DbContextOptions<BandContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BandConfiguration());
            
        }

        public DbSet<Band> Bands { get; set; }

    }
}
