using FluentValidation;
using RepairPK.Dto;

namespace RepairPK.Validators
{
    public class AppointmentForCreateValidator : AbstractValidator<AppointmentForCreationDto>
    {
        public AppointmentForCreateValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be null or empty")
                .Length(5, 500)
                .WithMessage("{PropertyName} length must be between 5 and 500 characters.");

            // Валидация даты назначения
            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("Appointment date must be in the future.");

        }
    }
}
