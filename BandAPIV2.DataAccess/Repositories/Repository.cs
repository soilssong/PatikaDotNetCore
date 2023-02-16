﻿using BandAPIV2.DataAccess.Contexts;
using BandAPIV2.DataAccess.Interfaces;
using BandAPIV2.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.DataAccess.Repositories
{
  
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly BandContext _context;

        public Repository(BandContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(System.Linq.Expressions.Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking? await _context.Set<T>().SingleOrDefaultAsync(filter): await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
     
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity , T unchanged)
        {
            //_context.Set<T>().Update(entity);
       
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
