using AutoMapper;
using BandAPIV2.Business.Interfaces;
using BandAPIV2.Business.Mapping;
using BandAPIV2.Business.Services;
using BandAPIV2.Business.ValidationRules;
using BandAPIV2.DataAccess.Contexts;
using BandAPIV2.DataAccess.UnityofWork;
using BandAPIV2.Dto.BandDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.Business.DependencyResolvers
{
    public static class DependencyExtension
    {

        public static void AddDependencies(this IServiceCollection services)
        {


            services.AddDbContext<BandContext>(opt =>
            {
                opt.UseSqlServer("server = LAPTOP-AR6JTJQR; database = Patika; integrated security = true; Encrypt=False ");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new BandProfile());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IBandService, BandService>();

            services.AddTransient<IValidator<BandCreateDto>, BandCreateDtoValidator>();

            services.AddTransient<IValidator<BandUpdateDto>, BandUpdateDtoValidator>();
        }
    }
}
