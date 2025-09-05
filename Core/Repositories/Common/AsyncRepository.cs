using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Common
{
    public class AsyncRepository<T>:IAsyncRepository<T> where T : class, IEntityBase
    {
        private readonly DbContext db;

        public AsyncRepository(DbContext db)
        {
            this.db = db;
        }
        private DbSet<T> Table { get => db.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);
            return await Table.CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                Table.Remove(entity);
            });
        }

        public async Task DeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() =>
            {
                Table.RemoveRange(entities);
            });
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if(!enableTracking) Table.AsNoTracking();
            return Table.Where(predicate);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> query = Table;
            if(!enableTracking) query = query.AsNoTracking();
            if(include is not null) query = include(query);
            if(predicate is not null) query = query.Where(predicate);
            if (orderBy is not null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<IList<T>> GetAllPagingAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null) return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }
            if (include is not null) queryable = include(queryable);
            //queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                Table.Update(entity);
            });
            return entity;
        }
    }
}
