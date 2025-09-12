using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction:EntityBase
    {
        public DateTime dateTime { get; set; }

        public double Amount { get; set; }

        public int? SenderCardId { get; set; }
        public Card? SenderCard { get; set; } 

        public int? ReceiverCardId { get; set; }
        public Card? ReceiverCard { get; set; } 

        public TransactionType transactionType { get; set; }
    }
}
