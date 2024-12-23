using FluentValidation;
using RepairPK.Dto;

namespace RepairPK.Validators
{
    public class CustomerValidator:AbstractValidator<CustomerForCreationDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be null or empty")
                .Length(1,200)
                .WithMessage("{PropertyName} cannot be length");
        }
    }
}
