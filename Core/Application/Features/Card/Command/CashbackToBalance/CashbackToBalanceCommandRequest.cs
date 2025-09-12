using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CashbackToBalance
{
    public class CashbackToBalanceCommandRequest:IRequest<CashbackToBalanceCommandResponse>
    {
        public string cardNumber { get; set; }
        public double cashbackAmount { get; set; }
    }
}
