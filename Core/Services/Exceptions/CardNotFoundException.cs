using Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class CardNotFoundException:BaseException
    {
        public CardNotFoundException() : base("Card tapilmadi veya size aid deyil")
        {
        }
    }
}
