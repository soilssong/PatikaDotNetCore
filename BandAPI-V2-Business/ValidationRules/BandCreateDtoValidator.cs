using BandAPI_V2_DTOS.BandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_Business.ValidationRules
{
    public class BandCreateDtoValidator : AbstractValidator<BandCreateDto>
    {
        public BandCreateDtoValidator()
        {
           
            RuleFor(x => x.Name).NotEmpty().WithMessage("Band name is required");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Band genre is required");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Band country is required");

        }
    }
}
