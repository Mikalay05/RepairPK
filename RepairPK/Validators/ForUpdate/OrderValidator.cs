using FluentValidation;
using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;

namespace RepairPK.Validators
{
    public class OrderForUpdateValidator : AbstractValidator<OrderForUpdateDto>
    {
        public OrderForUpdateValidator()
        {

        }
    }
}
