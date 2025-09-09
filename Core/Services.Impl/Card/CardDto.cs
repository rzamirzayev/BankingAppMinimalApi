using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl.Card
{
    public class CardDto
    {
        public string CardNumber { get; set; }
        public string CardTypeName { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public double CashbackBalance { get; set; }
        public double MonthltSpent { get; set; }
        public int Cvv { get; set; }
        public string ExpiryDate { get; set; }
        public Guid UserId { get; set; }
    }
}
