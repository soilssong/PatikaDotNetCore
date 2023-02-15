using BandAPI_V2_DataAccess.Contexts;
using BandAPI_V2_DataAccess.Interfaces;
using BandAPI_V2_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly BandContext _context;

        public Uow(BandContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
