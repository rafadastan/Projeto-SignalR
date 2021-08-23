using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable
        where TEntity : class
        where TKey : struct
    {
        void Add(TEntity entity);
        void Modify(TEntity entity);
        void Remove(TEntity entity);

        List<TEntity> GetAll();
        TEntity GetById(TKey key);
    }
}
