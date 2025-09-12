using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CashbackToBalance
{
    public class CashbackToBalanceCommandValidator:AbstractValidator<CashbackToBalanceCommandRequest>
    {
        public CashbackToBalanceCommandValidator()
        {
            RuleFor(x => x.cardNumber).NotEmpty().WithMessage("Card number is required")
               .Length(16).WithMessage("Card number must be 16 digits")
               .Matches(@"^\d{16}$").WithMessage("Card number must be numeric");

            RuleFor(x=>x.cashbackAmount).GreaterThan(0).WithMessage("Cashback amount must be greater than 0");

        }
    }
}
