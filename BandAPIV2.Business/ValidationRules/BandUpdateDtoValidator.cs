using BandAPIV2.Dto.BandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.Business.ValidationRules
{
    public class BandUpdateDtoValidator : AbstractValidator<BandUpdateDto>
    {
        public BandUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Genre).NotEmpty();

        }
    }
}
