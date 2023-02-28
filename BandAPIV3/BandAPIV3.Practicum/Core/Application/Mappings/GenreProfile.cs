using AutoMapper;
using BandAPIV3.Practicum.Core.Application.Dtos;
using BandAPIV3.Practicum.Core.Domain;

namespace BandAPIV3.Practicum.Core.Application.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreListDto>().ReverseMap();
        }
    }
}
