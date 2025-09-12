using MediatR;
using Services.Impl.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.Payment
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCommandRequest, PaymentCommandResponse>
    {
        private readonly ICardService cardService;
        public PaymentCommandHandler(ICardService cardService)
        {
            this.cardService = cardService;
        }
        public async Task<PaymentCommandResponse> Handle(PaymentCommandRequest request, CancellationToken cancellationToken)
        {
            await cardService.Payment(request.senderCardNumber, request.amount, cancellationToken);
            return new PaymentCommandResponse
            {
                IsSuccess = true,
                Message = $"Payment of {request.amount} was successful from card {request.senderCardNumber}",
            };

        }
    }
}
