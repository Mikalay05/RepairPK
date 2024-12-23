using FluentValidation;
using RepairPK.Dto;

namespace RepairPK.Validators
{
    public class CustomerForCreateValidator : AbstractValidator<CustomerForCreationDto>
    {
        public CustomerForCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be null or empty")
                .Length(1, 200)
                .WithMessage("{PropertyName} length must be between 1 and 200 characters.");

            // Валидация номера телефона
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be null or empty")
                .Matches(@"^\+?[1-9]\d{1,14}$")  // Правильный формат для международных номеров
                .WithMessage("Invalid phone number format.");
        }
    }
}
