using BandAPIV2.DataAccess.Contexts;
using BandAPIV2.DataAccess.Interfaces;
using BandAPIV2.DataAccess.Repositories;
using BandAPIV2.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.DataAccess.UnityofWork
{
    public class Uow : IUow
    {

        private readonly BandContext _context;

        public Uow(BandContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);        
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
