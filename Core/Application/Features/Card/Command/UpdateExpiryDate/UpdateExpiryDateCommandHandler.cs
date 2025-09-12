using Mapper.Mapper;
using MediatR;
using Services.Impl.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.UpdateExpiryDate
{
    public class UpdateExpiryDateCommandHandler : IRequestHandler<UpdateExpiryDateCommandRequest, UpdateExpiryDateCommandResponse>
    {
        private readonly ICardService cardService;

        public UpdateExpiryDateCommandHandler(ICardService cardService)
        {
            this.cardService = cardService;
        }
        public async Task<UpdateExpiryDateCommandResponse> Handle(UpdateExpiryDateCommandRequest request, CancellationToken cancellationToken)
        {
            await cardService.UpdateCardExpiryDate(request.cardNumber, cancellationToken);
            return new UpdateExpiryDateCommandResponse
            {
                IsSuccess = true,
                Message = "Card expiry date successfully updated"
            };
        }
    }
}
