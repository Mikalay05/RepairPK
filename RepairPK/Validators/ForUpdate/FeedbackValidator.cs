using FluentValidation;
using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;

namespace RepairPK.Validators
{
    public class FeedbackForUpdateValidator : AbstractValidator<FeedbackForUpdateDto>
    {
        public FeedbackForUpdateValidator()
        {
        }
    }
}
