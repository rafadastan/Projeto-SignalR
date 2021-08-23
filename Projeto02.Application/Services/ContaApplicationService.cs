using AutoMapper;
using Projeto02.Application.Interfaces;
using Projeto02.Application.Models.Contas;
using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Services
{
    public class ContaApplicationService : IContaApplicationService
    {
        private readonly IContaDomainService _contaDomainService;
        private readonly IMapper _mapper;

        public ContaApplicationService(IContaDomainService contaDomainService, IMapper mapper)
        {
            _contaDomainService = contaDomainService;
            _mapper = mapper;
        }

        public void Add(AddContasModel model)
        {
            var conta = _mapper.Map<Conta>(model);
            _contaDomainService.Add(conta);
        }

        public List<GetContasModel> GetAll()
        {
            var contas = _contaDomainService.GetAll();
            return _mapper.Map<List<GetContasModel>>(contas);
        }

        public void Dispose()
        {
            _contaDomainService.Dispose();
        }
    }
}
