using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.UpdateExpiryDate
{
    public class UpdateExpiryDateCommandRequest:IRequest<UpdateExpiryDateCommandResponse>
    {
        public string cardNumber { get; set; }
    }
}
