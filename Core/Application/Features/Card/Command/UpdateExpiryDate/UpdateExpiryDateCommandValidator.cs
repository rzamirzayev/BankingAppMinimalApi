using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.UpdateExpiryDate
{
    public class UpdateExpiryDateCommandValidator:AbstractValidator<UpdateExpiryDateCommandRequest>
    {
        public UpdateExpiryDateCommandValidator()
        {
            RuleFor(x => x.cardNumber).NotEmpty().WithMessage("Card number is required")
               .Length(16).WithMessage("Card number must be 16 digits")
               .Matches(@"^\d{16}$").WithMessage("Card number must be numeric");
        }
    }
}
