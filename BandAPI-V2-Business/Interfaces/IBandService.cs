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

        Task  <List<BandListDto>> GetAll();

        Task Create(BandCreateDto dto);
        Task<BandListDto> GetById(object id);

        Task Remove(object id);

        Task UpdateBand(BandUpdateDto dto); 

    }
}
