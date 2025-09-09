using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl.Card
{
    public class CardOperationDto
    {
        public string? MyCardNumber { get; set; }
        public string? toCardNumber { get; set; }
        public double amount { get; set; }
    }
}
