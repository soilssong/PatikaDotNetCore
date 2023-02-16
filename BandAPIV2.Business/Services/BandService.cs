using AutoMapper;
using BandAPIV2.Business.Interfaces;
using BandAPIV2.Business.ValidationRules;
using BandAPIV2.Common.ResponseObjects;
using BandAPIV2.DataAccess.UnityofWork;
using BandAPIV2.Dto.BandDtos;
using BandAPIV2.Dto.Interfaces;
using BandAPIV2.Entities.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.Business.Services
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

        public async Task<IResponse<BandCreateDto>> Create(BandCreateDto dto)
        {

            var validationResult = _createDtoValidator.Validate(dto);

           

            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Band>().Create(_mapper.Map<Band>(dto));

                await _uow.SaveChanges();
                return new Response<BandCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });

                }

                return new Response<BandCreateDto>(ResponseType.ValidationError, dto, errors);
            }
          
        }

        public async Task<IResponse<List<BandListDto>>> GetAll()
        {

            var data = _mapper.Map<List<BandListDto>>(await _uow.GetRepository<Band>().GetAll());
            return new Response<List<BandListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<BandListDto>> GetById(int id)
        {
           var data = _mapper.Map<BandListDto>(await _uow.GetRepository<Band>().GetByFilter(x => x.Id==id));
            if (data == null)
            {
                return new Response<BandListDto>(ResponseType.NotFound,$"{id}'ye ait data bulunamadı");
            }

            return new Response<BandListDto>(ResponseType.Success, data);

          
        }

        public async Task<IResponse> Remove(int id)
        {

            var removedEntity = await _uow.GetRepository<Band>().GetByFilter(x => x.Id == id);

            if (removedEntity != null)
            {
                _uow.GetRepository<Band>().Remove(removedEntity);
                await _uow.SaveChanges();

                return new Response(ResponseType.Success, $"{id} silindi");
            }
            return new Response(ResponseType.NotFound, $"{id}'ye ait data bulunamadı");
           
        }

        public async Task<IResponse<BandUpdateDto>> Update(BandUpdateDto dto)
        {
            var validationResult = _updateDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Band>().Find(dto.Id);

                if (updatedEntity != null)
                {
                    _uow.GetRepository<Band>().Update(_mapper.Map<Band>(dto),updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<BandUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<BandUpdateDto>(ResponseType.NotFound, $"{dto.Id}'ye ait data bulunamadı");


            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });

                }

                return new Response<BandUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
           
          
        }
    }
}
