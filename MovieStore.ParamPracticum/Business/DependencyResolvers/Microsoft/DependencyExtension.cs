using AutoMapper;
using Business.Interfaces;
using Business.Mappings;
using Business.Services;
using DataAccess.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {

        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>) , typeof(DataAccess.Repositories.Repository<>));
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenreService, GenreService>();

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new MovieProfile());
                opt.AddProfile(new GenreProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<MovieStoreContext>(opt => 
            {
                opt.UseSqlServer("server = LAPTOP-AR6JTJQR; database = MovieStore; integrated security = true; Encrypt=False ");
            });
        }
    }
}
