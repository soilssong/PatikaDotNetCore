using BandAPIV2.DataAccess.Interfaces;
using BandAPIV2.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.DataAccess.UnityofWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task SaveChanges();
    }
}
