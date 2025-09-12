using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.CardToCardTransfer
{
    public class CardToCardCommandRequest:IRequest<CardToCardCommandResponse>
    {
        public string myCardNumber { get; set; }
        public string toCardNumber { get; set; }
        public double amount { get; set; }
    }
}
