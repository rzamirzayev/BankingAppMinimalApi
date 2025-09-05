using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CreateCard
{
    public class CreateCardCommandRequest:IRequest<CreateCardCommandResponse>
    {
        public int CardTypeId { get; set; }

        public string Currency { get; set; }

        public double Balance { get; set; }

        public Guid UserId { get; set; }
    }
}
