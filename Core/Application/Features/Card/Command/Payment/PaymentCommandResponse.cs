using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Command.Payment
{
    public class PaymentCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
