using DataAccess.Context;
using DataAccess.Interfaces;
using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MovieStoreContext _context;

        public Repository(MovieStoreContext context)
        {
            _context = context;
        }

        public DbSet<T> Entity => _context.Set<T>();

        public IQueryable<T> Query => Entity.AsQueryable();

        public async Task Create(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await Entity.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsyncWithInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = Query;
            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await Entity.SingleOrDefaultAsync(filter) : await Entity.AsNoTracking()
                .SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
            return await Entity.FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return Entity.AsQueryable();
        }

        public void Remove(int id)
        {
            var deletedEntity = Entity.Find(id);
            Entity.Remove(deletedEntity);
        }

        public Task SaveChanges()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public void Update(T entity)
        {
            var updatedEntity = Entity.Find(entity.Id);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
        }
    }
}
