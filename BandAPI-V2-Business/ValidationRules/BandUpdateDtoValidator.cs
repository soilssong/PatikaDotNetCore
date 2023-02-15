using BandAPI_V2_DTOS.BandDtos;
using FluentValidation;

namespace BandAPI_V2_Business.ValidationRules
{
    public class BandUpdateDtoValidator : AbstractValidator<BandUpdateDto>
    {
        public BandUpdateDtoValidator()
        {
        
            RuleFor(x => x.Name).NotEmpty().WithMessage("Band name is required");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Band genre is required");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Band country is required"); 
        }
    }
}
