using FluentValidation;
using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;

namespace RepairPK.Validators
{
    public class AppointmentForUpdateValidator : AbstractValidator<AppointmentForUpdateDto>
    {
        public AppointmentForUpdateValidator()
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
