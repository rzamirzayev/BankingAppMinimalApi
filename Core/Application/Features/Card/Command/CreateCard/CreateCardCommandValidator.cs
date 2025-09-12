using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CreateCard
{
    public class CreateCardCommandValidator:AbstractValidator<CreateCardCommandRequest>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("Userid is required");
            RuleFor(x=>x.Currency).NotEmpty().WithMessage("Currency is required");
            RuleFor(x => x.CardTypeId)
                .NotEmpty().WithMessage("CardTypeId is required")
                .GreaterThan(0).WithMessage("CardTypeId must be greater than 0");
            RuleFor(x=>x.Balance).GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to 0");
            RuleFor(x => x.Currency)
                    .Must(c => c == "AZN" || c == "USD")
                    .WithMessage("Currency yalnız 'AZN' və ya 'USD' ola bilər.");

        }
    }
}
