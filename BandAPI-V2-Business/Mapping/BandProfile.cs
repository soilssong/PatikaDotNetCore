using AutoMapper;
using BandAPI_V2_DTOS.BandDtos;
using BandAPI_V2_Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_Business.Mapping
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
