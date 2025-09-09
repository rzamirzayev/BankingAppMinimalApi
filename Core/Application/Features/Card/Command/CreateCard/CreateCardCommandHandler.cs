using Mapper.Mapper;
using MediatR;
using Services.Impl.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommandRequest, CreateCardCommandResponse>
    {
        private readonly ICardService cardService;
        private readonly IMapperr mapper;

        public CreateCardCommandHandler(IMapperr mapper,ICardService cardService) 
        {
            this.cardService = cardService;
            this.mapper = mapper;
        }

        public async Task<CreateCardCommandResponse> Handle(CreateCardCommandRequest request, CancellationToken cancellationToken)
        {
            CardDtoIU cardDtoIU = mapper.Map<CardDtoIU,CreateCardCommandRequest>(request);
            var result = await cardService.CreateCard(cardDtoIU);
            CreateCardCommandResponse response = mapper.Map<CreateCardCommandResponse,CardDto>(result);
            return await Task.FromResult(response);
        }
    }
}
