using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.IncreaseCardBalance
{
    public class IncreaseCardBalanceCommandValidator:AbstractValidator<IncreaseCardBalanceCommandRequest>
    {
        public IncreaseCardBalanceCommandValidator()
        {
            RuleFor(x => x.cardNumber).NotEmpty().WithMessage("Card number is required")
               .Length(16).WithMessage("Card number must be 16 digits")
               .Matches(@"^\d{16}$").WithMessage("Card number must be numeric");

            RuleFor(x=>x.amount).GreaterThan(0).WithMessage("Amount must be greater than 0");

        }
    }
}
