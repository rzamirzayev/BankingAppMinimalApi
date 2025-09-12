using Mapper.Mapper;
using MediatR;
using Services.Impl.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.IncreaseCardBalance
{
    public class IncreaseCardBalanceCommandHandler : IRequestHandler<IncreaseCardBalanceCommandRequest, IncreaseCardBalanceCommandResponse>
    {
        private readonly ICardService cardService;

        public IncreaseCardBalanceCommandHandler(ICardService cardService)
        {
            this.cardService = cardService;
        }
        public async Task<IncreaseCardBalanceCommandResponse> Handle(IncreaseCardBalanceCommandRequest request, CancellationToken cancellationToken)
        {
            await cardService.IncreaseBalance(request.cardNumber, request.amount, cancellationToken);
            return new IncreaseCardBalanceCommandResponse
            {
                IsSuccess = true,
                Message = $"Card balance successfully increased by {request.amount}"
            };
        }
    }
}
