using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Repositories;
using Repositories.Common;


namespace Persistence.Repositories
{
    class TranscastionRepository : AsyncRepository<Transaction>, ITranstactionRepository
    {
        public TranscastionRepository(DataContext db) : base(db)
        {
        }
    }
}
