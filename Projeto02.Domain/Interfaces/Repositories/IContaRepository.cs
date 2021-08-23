using Projeto02.Domain.DTOs;
using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Domain.Interfaces.Repositories
{
    public interface IContaRepository : IBaseRepository<Conta, Guid>
    {
        List<ContaCategoriaDTO> GroupByCategoria();
    }
}
