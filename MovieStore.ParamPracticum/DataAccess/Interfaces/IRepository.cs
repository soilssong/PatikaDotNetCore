using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        IQueryable<T> Query { get; }
        DbSet<T> Entity { get; }
        Task<List<T>> GetAll();

        Task<List<T>> GetAllAsyncWithInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<T> GetById(object id);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);


        Task Create(T entity);

        void Update(T entity);

        void Remove( int id);

        IQueryable<T> GetQuery();

        Task SaveChanges();

    }
}
