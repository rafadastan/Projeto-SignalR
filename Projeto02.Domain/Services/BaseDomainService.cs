using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly IBaseRepository<TEntity, TKey> _baseRepository;

        protected BaseDomainService(IBaseRepository<TEntity, TKey> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Add(TEntity entity)
        {
            _baseRepository.Add(entity);
        }

        public virtual void Modify(TEntity entity)
        {
            _baseRepository.Modify(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _baseRepository.Remove(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public virtual TEntity GetById(TKey key)
        {
            return _baseRepository.GetById(key);
        }

        public virtual void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
