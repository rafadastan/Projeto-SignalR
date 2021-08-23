using Microsoft.EntityFrameworkCore.Storage;
using Projeto02.Data.SqlServer.Contexts;
using Projeto02.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Data.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlServerContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public IContaRepository ContaRepository => new ContaRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
