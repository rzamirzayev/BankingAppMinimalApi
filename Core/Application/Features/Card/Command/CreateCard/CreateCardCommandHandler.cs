using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommandRequest, CreateCardCommandResponse>
    {

        public Task<CreateCardCommandResponse> Handle(CreateCardCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
