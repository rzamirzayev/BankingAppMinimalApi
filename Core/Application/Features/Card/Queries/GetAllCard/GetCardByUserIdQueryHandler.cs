using Mapper.Mapper;
using MediatR;
using Services.Impl.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Queries.GetAllCard
{
    public class GetCardByUserIdQueryHandler : IRequestHandler<GetCardByUserIdQueryRequest, List<GetCardByUserIdQueryResponse>>
    {
        private readonly IMapperr mapper;
        private readonly ICardService cardService;

        public GetCardByUserIdQueryHandler(IMapperr mapper,ICardService cardService)
        {
            this.mapper = mapper;
            this.cardService = cardService;
        }
        public async Task<List<GetCardByUserIdQueryResponse>> Handle(GetCardByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<CardDto> result = await cardService.GetCardByUserId();
            List<GetCardByUserIdQueryResponse> responses = new List<GetCardByUserIdQueryResponse>();
            foreach (var item in result)
            {
                GetCardByUserIdQueryResponse response = mapper.Map<GetCardByUserIdQueryResponse, CardDto>(item);
                responses.Add(response);

            }

            return responses;
        }
    }
}
