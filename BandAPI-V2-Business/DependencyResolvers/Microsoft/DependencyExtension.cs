using BandAPI_V2_Business.Interfaces;
using BandAPI_V2_Business.Services;
using BandAPI_V2_DataAccess.Contexts;
using BandAPI_V2_DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {

        public static void AddDependencies(this IServiceCollection services)
        {
            
            services.AddDbContext<BandContext>(opt =>
            {
                opt.UseSqlServer("server = LAPTOP-AR6JTJQR; database = MetalBlog; integrated security = true; Encrypt=False ");
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IBandService, BandService>();
        }
    }
}
