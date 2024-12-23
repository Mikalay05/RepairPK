using FluentValidation;
using RepairPK.Dto;

namespace RepairPK.Validators
{
    public class FeedbackForCreationValidator : AbstractValidator<FeedbackForCreationDto>
    {
        public FeedbackForCreationValidator()
        {
        }
    }
}
