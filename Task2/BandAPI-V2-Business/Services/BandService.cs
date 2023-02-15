using AutoMapper;
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
        private readonly IMapper _mapper;

        public BandService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(BandCreateDto dto)
        {
            await _uow.GetRepository<Band>().Create(_mapper.Map<Band>(dto));
            await _uow.SaveChanges();
        }

        public async Task<List<BandListDto>> GetAll()
        {
   
          return _mapper.Map<List<BandListDto>>(await _uow.GetRepository<Band>().GetAll());

            }

            
        

        public async  Task<BandDto> GetById(int id)
        {
            return _mapper.Map<BandDto>(await _uow.GetRepository<Band>().GetById(id));
           
        }

        public async Task Remove(int id)
        {
            var deletedBand = await _uow.GetRepository<Band>().GetById(id);
           

            _uow.GetRepository<Band>().Remove(deletedBand);

            await _uow.SaveChanges();
        }

        public async Task UpdateBand(BandUpdateDto dto)
        {
             _uow.GetRepository<Band>().Update(_mapper.Map<Band>(dto));
            await _uow.SaveChanges();
        }
    }
}
