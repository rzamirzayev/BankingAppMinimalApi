using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Repositories;
using Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    class CardTypeRepository : AsyncRepository<CardType>, ICardTypeRepository
    {
        public CardTypeRepository(DataContext db) : base(db)
        {
        }
    }
}
