using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl.Transaction
{
    public class CashWithDrawTransactionDto
    {
        public int ReceiverCardId { get; set; }
        public double Amount { get; set; }
    }
}
