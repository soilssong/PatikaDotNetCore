using BandAPI_V2_Common.ResponseObjects;
using BandAPI_V2_DTOS.BandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_Business.Interfaces
{
    public  interface IBandService
    {

        Task<IResponse<List<BandListDto>>> GetAll();

        Task<IResponse<BandCreateDto>> Create(BandCreateDto dto);
        Task<IResponse<BandDto>> GetById(int id);

        Task <IResponse> Remove(int id);

        Task<IResponse<BandUpdateDto>> UpdateBand(BandUpdateDto dto); 

    }
}
