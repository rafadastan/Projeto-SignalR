using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Domain.Services
{
    public class ContaDomainService
        : BaseDomainService<Conta, Guid>, IContaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContaDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.ContaRepository)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
