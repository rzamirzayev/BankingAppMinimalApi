using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CardType:EntityBase
    {
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; } =string.Empty;
        public double CashbackPercentage { get; set; }
        public double MonthlLimit { get; set; }
        public double CashWithDrawLimit { get; set; }

        public ICollection<Card> Cards { get; set; }= new List<Card>();
    }
}
