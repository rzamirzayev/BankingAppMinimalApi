using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.Payment
{
    public class PaymentCommandRequest:IRequest<PaymentCommandResponse>
    {
        public string senderCardNumber { get; set; }
        public double amount { get; set; }
    }
}
