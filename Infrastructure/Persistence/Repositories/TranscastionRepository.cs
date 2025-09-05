using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Common;


namespace Persistence.Repositories
{
    class TranscastionRepository : AsyncRepository<Transaction>, ITranstactionRepository
    {
        public TranscastionRepository(DbContext db) : base(db)
        {
        }
    }
}
