using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Card.Queries.GetAllCard
{
    public class GetCardByUserIdQueryResponse
    {
        public string cardNumber { get; set; }
        public string cardTypeName { get; set; }
        public string currency { get; set; }
        public double balance { get; set; }
        public double cashbackBalance { get; set; }
        public double monthltSpent { get; set; }
    }
}
