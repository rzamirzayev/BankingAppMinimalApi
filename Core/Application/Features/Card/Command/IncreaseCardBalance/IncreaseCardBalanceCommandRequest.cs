using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.IncreaseCardBalance
{
    public class IncreaseCardBalanceCommandRequest:IRequest<IncreaseCardBalanceCommandResponse>
    {
        public string cardNumber { get; set; }
        public double amount { get; set; }
    }
}
