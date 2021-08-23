using Microsoft.EntityFrameworkCore;
using Projeto02.Data.SqlServer.Contexts;
using Projeto02.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Data.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly SqlServerContext _context;

        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Modify(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
