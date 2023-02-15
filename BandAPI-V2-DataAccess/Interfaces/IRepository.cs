using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_DataAccess.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task Create(T entity);

        void Update(T entity);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        void Remove(T entity);

        IQueryable<T> GetQuery();
    }
}
