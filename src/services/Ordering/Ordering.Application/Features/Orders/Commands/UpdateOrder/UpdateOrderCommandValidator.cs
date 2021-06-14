using FluentValidation;

namespace Ordering.Application.Features.Commands.UpdateOrder
{
    /// <summary>
    /// Validation rules for 
    /// </summary>
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public UpdateOrderCommandValidator()
        {
            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("{Username} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Username} must not exceed 50 characters.");

            RuleFor(p => p.EmailAddress)
               .NotEmpty().WithMessage("{EmailAddress} is required.");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}
