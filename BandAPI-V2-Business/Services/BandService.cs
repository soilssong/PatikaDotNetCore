using BandAPI_V2_Business.Interfaces;
using BandAPI_V2_DataAccess.UnitOfWork;
using BandAPI_V2_DTOS.BandDtos;
using BandAPI_V2_Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_Business.Services
{
    public class BandService : IBandService
    {
        private readonly IUow _uow;

        public BandService(IUow uow)
        {
            _uow = uow;
        }

        public async Task Create(BandCreateDto dto)
        {
            await _uow.GetRepository<Band>().Create(new()
            {
                Genre = dto.Genre,
                Name = dto.Name,
                Country = dto.Country,
            });
            await _uow.SaveChanges();
        }

        public async Task<List<BandListDto>> GetAll()
        {
          var list =  await _uow.GetRepository<Band>().GetAll();
            var bandList = new List<BandListDto>();
            if (list != null && list.Count>0)
            {
                foreach (var band in list)
                {
                    bandList.Add(new()
                    {
                        id = band.id,
                        Genre = band.Genre,
                        Country = band.Country,
                        Name = band.Name,
                    }) ;

                }

            }

            return bandList;
        }

        public async  Task<BandListDto> GetById(object id)
        {
            var band = await _uow.GetRepository<Band>().GetById(id);
            return (new()
            {

                Genre = band.Genre,
                Country = band.Country,
                Name = band.Name,
            });
        }

        public async Task Remove(object id)
        {
            var deletedBand = await _uow.GetRepository<Band>().GetById(id);

            _uow.GetRepository<Band>().Remove(deletedBand);

            await _uow.SaveChanges();
        }

        public async Task UpdateBand(BandUpdateDto dto)
        {
             _uow.GetRepository<Band>().Update(new()
            {
                Name = dto.Name,
                id  = dto.id,
                Genre = dto.Genre,
                Country = dto.Country,


            });
            await _uow.SaveChanges();
        }
    }
}
