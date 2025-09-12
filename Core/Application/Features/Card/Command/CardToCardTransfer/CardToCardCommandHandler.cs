using Mapper.Mapper;
using MediatR;
using Services.Impl.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CardToCardTransfer
{
    public class CardToCardCommandHandler:IRequestHandler<CardToCardCommandRequest, CardToCardCommandResponse>
    {
        private readonly IMapperr mapper;
        private readonly ICardService cardService;
        public CardToCardCommandHandler(ICardService cardService,IMapperr mapper)
        {
            this.mapper = mapper;
            this.cardService = cardService;
        }
        public async Task<CardToCardCommandResponse> Handle(CardToCardCommandRequest request, CancellationToken cancellationToken)
        {
            CardOperationDto dto = mapper.Map<CardOperationDto,CardToCardCommandRequest>(request);
            await cardService.Transfer(dto, cancellationToken);
            return new CardToCardCommandResponse
            {
                IsSuccess = true,
                Message = $"Transfer of {request.amount} from card {request.myCardNumber} to card {request.toCardNumber} was successful",
            };
        }
    }
}
