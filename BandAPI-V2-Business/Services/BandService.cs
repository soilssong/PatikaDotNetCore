using AutoMapper;
using BandAPI_V2_Business.Interfaces;
using BandAPI_V2_Common.ResponseObjects;
using BandAPI_V2_DataAccess.UnitOfWork;
using BandAPI_V2_DTOS.BandDtos;
using BandAPI_V2_Entities.Concrete;
using FluentValidation;
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

        private readonly IValidator<BandCreateDto> _createDtoValidator;
        private readonly IValidator<BandUpdateDto> _updateDtoValidator;
      
        public BandService(IUow uow, IMapper mapper, IValidator<BandCreateDto> createDtoValidator, IValidator<BandUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
           
        }

        public async Task <IResponse<BandCreateDto>> Create(BandCreateDto dto)
        {

            var validatonResult = _createDtoValidator.Validate(dto);

            if (validatonResult.IsValid)
            {
                await _uow.GetRepository<Band>().Create(_mapper.Map<Band>(dto));
                await _uow.SaveChanges();
                return new Response<BandCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validatonResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                   
                }
                return new Response<BandCreateDto>(ResponseType.ValidationError, dto);
            }
            
        }



        public async Task<IResponse<List<BandListDto>>> GetAll()
        {
         
          var data = _mapper.Map<List<BandListDto>>(await _uow.GetRepository<Band>().GetAll());
            return new Response<List<BandListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<BandDto>> GetById(int id)
        {
          
            //});
            var data = _mapper.Map<BandDto>(await _uow.GetRepository<Band>().Find(id));
            if (data == null)
            {
                return new Response<BandDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<BandDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {

            var deletedBand = await _uow.GetRepository<Band>().GetByFilter(x => x.id == id);

            if (deletedBand !=null)
            {
                _uow.GetRepository<Band>().Remove(deletedBand);

                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

       
        public async Task <IResponse<BandUpdateDto>>UpdateBand(BandUpdateDto dto)
        {
  
            var result = _updateDtoValidator.Validate(dto);

            if (result.IsValid)
            {

                var updatedEntity = await _uow.GetRepository<Band>().Find(dto.id);

                if (updatedEntity != null)
                {
                    _uow.GetRepository<Band>().Update(_mapper.Map<Band>(dto),updatedEntity);

                    await _uow.SaveChanges();
                    return new Response<BandUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<BandUpdateDto>(ResponseType.NotFound, $"{dto.id} ye ait data bulunamadı");

            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in result.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });

                }
                return new Response<BandUpdateDto>(ResponseType.ValidationError, dto,errors);
            }
            
        }

        
    }
}
