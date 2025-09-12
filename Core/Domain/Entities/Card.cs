using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Card : EntityBase
    {
        public string CardNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = "AZN";
        public double Balance { get; set; }
        public double CashbackBalance { get; set; }
        public double MonthltSpent { get; set; }
        public int Cvv { get; set; }
        public required string ExpiryDate { get; set; }
        public int Code { get; set; }

        public int CardTypeId { get; set; }
        public CardType? CardType { get; set; }

        public ICollection<Transaction> SentTransactions { get; set; }=new List<Transaction>();
        public ICollection<Transaction> ReceivedTransactions { get; set; } = new List<Transaction>();

        public Guid UserId { get; set; }
        public required User User { get; set; }


    }
}
