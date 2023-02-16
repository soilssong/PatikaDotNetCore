using AutoMapper;
using BandAPIV2.Dto.BandDtos;
using BandAPIV2.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.Business.Mapping
{
    public class BandProfile : Profile
    {
        public BandProfile()
        {
            CreateMap<Band, BandListDto>().ReverseMap();
            CreateMap<Band, BandCreateDto>().ReverseMap();
            CreateMap<Band, BandUpdateDto>().ReverseMap();
            CreateMap<BandListDto, BandUpdateDto>().ReverseMap();
        }
    }
}
