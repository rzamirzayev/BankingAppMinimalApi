using MediatR;
using Services.Impl.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CashbackToBalance
{
    public class CashbackToBalanceCommandHandler : IRequestHandler<CashbackToBalanceCommandRequest, CashbackToBalanceCommandResponse>
    {
        public readonly ICardService _cardService;
        public CashbackToBalanceCommandHandler(ICardService cardService)
        {
            _cardService = cardService;
        }
        public async Task<CashbackToBalanceCommandResponse> Handle(CashbackToBalanceCommandRequest request, CancellationToken cancellationToken)
        {
            await _cardService.CashbackToBalance(request.cardNumber,request.cashbackAmount,cancellationToken);
            return new CashbackToBalanceCommandResponse
            {
                IsSuccess = true,
                Message = "Cashback successfully transferred to balance",
                CashbackBalance= request.cashbackAmount,
            };

        }
    }
}
