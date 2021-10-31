﻿using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("Username should not exceed 50 characters.");

            RuleFor(p=>p.EmailAddress)
                .NotEmpty().WithMessage("Email address is required.");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("Total price is required.")
                .GreaterThan(0).WithMessage("Total price should be greater then 0.");
        }
    }
}
