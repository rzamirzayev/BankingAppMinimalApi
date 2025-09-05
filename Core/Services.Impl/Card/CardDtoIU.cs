using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Card
{
    public class CardDtoIU
    {
        public int CardTypeId { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public Guid userId { get; set; }
    }
}
