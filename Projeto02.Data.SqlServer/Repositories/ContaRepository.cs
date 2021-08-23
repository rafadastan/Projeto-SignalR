using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto02.Data.SqlServer.Contexts;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Entities;
using Projeto02.Domain.Entities.Types;
using Projeto02.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Data.SqlServer.Repositories
{
    public class ContaRepository : BaseRepository<Conta, Guid>, IContaRepository
    {
        private readonly SqlServerContext _context;

        public ContaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public override List<Conta> GetAll()
        {
            var query = @"
                    SELECT * FROM CONTAS
                    ORDER BY NOME ASC
                ";

            return _context.Database
                    .GetDbConnection()
                    .Query<Conta>(query)
                    .ToList();
        }

        public override Conta GetById(Guid key)
        {
            var query = @"
                    SELECT * FROM CONTAS
                    WHERE IDCONTA = @KEY
                ";

            return _context.Database
                    .GetDbConnection()
                    .Query<Conta>(query, new { key })
                    .FirstOrDefault();
        }

        public List<ContaCategoriaDTO> GroupByCategoria()
        {
            var query = @"
                    SELECT
	                    CATEGORIA,
	                    SUM(VALOR) AS TOTAL
                    FROM CONTAS
                    GROUP BY CATEGORIA
                ";

            return _context.Database
                    .GetDbConnection()
                    .Query<ContaCategoriaDTO>(query)
                    .ToList();
        }

        public List<ContaCategoriaDTO> GroupByCategoria_LAMBDA()
        {
            return _context.Contas
                    .GroupBy(c => c.Categoria)
                    .Select(
                        g => new ContaCategoriaDTO
                        {
                            Categoria = (Categoria)g.Key,
                            Total = (decimal)g.Sum(s => s.Valor)
                        }
                    ).ToList();
        }

        public List<ContaCategoriaDTO> GroupByCategoria_LINQ()
        {
            var query = from c in _context.Contas
                        group c by c.Categoria into g
                        select new ContaCategoriaDTO
                        {
                            Categoria = (Categoria)g.Key,
                            Total = (decimal)g.Sum(s => s.Valor)
                        };

            return query.ToList();
        }
    }
}
