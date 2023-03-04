using AutoMapper;
using Dtos.MovieDtos;
using Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, GetMovieDto>()
                .ForMember(x=>x.DirectorName , y=>y.MapFrom(z=>z.Director.Name))
                .ForMember(x=>x.GenreName , y=>y.MapFrom(z=>z.Genre.Name))
                .ForMember(x=>x.Actors , y=>y.MapFrom(z=>z.Actors.Select(x=>x.Actor.Name)))
                .ReverseMap();

            CreateMap<Movie, MovieCreateDto>().ReverseMap();
            CreateMap<Movie, MovieUpdateDto>().ReverseMap();
        }
    }
}
