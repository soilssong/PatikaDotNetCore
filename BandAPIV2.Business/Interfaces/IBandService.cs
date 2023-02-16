using BandAPIV2.Common.ResponseObjects;
using BandAPIV2.Dto.BandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.Business.Interfaces
{
    public interface IBandService
    {

        Task<IResponse<List<BandListDto>>> GetAll();

        Task<IResponse<BandCreateDto>>Create(BandCreateDto dto);

        Task<IResponse<BandListDto>> GetById(int id);

         Task <IResponse>Remove(int id);

        Task <IResponse<BandUpdateDto>> Update(BandUpdateDto dto);
    }
}
