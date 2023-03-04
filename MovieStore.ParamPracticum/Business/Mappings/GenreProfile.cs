using AutoMapper;
using Dtos.GenreDtos;
using Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GetGenreDto>().ForMember(x => x.Movies, y=> y.MapFrom(x => x.Movies.Select(x => x.Name))).ReverseMap();
            CreateMap<Genre, GenreCreateDto>().ReverseMap();
            CreateMap<Genre, GenreUpdateDto>().ReverseMap();
        }
    }
}
