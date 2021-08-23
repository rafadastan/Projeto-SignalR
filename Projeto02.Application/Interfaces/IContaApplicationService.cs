using Projeto02.Application.Models.Contas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Interfaces
{
    /// <summary>
    /// Interface de aplicação para os fluxos da entidade Conta
    /// </summary>
    public interface IContaApplicationService : IDisposable
    {
        /// <summary>
        /// Cadastro de contas
        /// </summary>
        /// <param name="model">Modelo de dados do cadastro</param>
        void Add(AddContasModel model);

        /// <summary>
        /// Consulta de contas
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        List<GetContasModel> GetAll();
    }
}
