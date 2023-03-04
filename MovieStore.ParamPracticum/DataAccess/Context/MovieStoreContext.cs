using DataAccess.Configurations;
using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MovieStoreContext :DbContext
    {
        public MovieStoreContext(DbContextOptions<MovieStoreContext> options): base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }       
        public DbSet<Director> Directors { get; set; }

        public DbSet<AppCustomer> AppCustomers { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new ActorMovieConfiguration());
           
            modelBuilder.ApplyConfiguration(new CustomerGenreConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieOrderConfiguration());
        }
    }
}
