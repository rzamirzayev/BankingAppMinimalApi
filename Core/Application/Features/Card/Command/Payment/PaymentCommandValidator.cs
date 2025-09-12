using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.Payment
{
    public class PaymentCommandValidator:AbstractValidator<PaymentCommandRequest>
    {
        public PaymentCommandValidator()
        {
            RuleFor(x => x.senderCardNumber).NotEmpty().WithMessage("Sender card number is required.")
                .Matches(@"^\d{16}$").WithMessage("Sender card number must be 16 digits.");

            RuleFor(x => x.amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }
}
