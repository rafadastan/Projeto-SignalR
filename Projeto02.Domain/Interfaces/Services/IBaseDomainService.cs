using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, TKey> : IDisposable
    {
        void Add(TEntity entity);
        void Modify(TEntity entity);
        void Remove(TEntity entity);

        List<TEntity> GetAll();
        TEntity GetById(TKey key);
    }
}
