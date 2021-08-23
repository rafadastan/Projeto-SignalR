using Projeto02.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Domain.DTOs
{
    /// <summary>
    /// DTO para consulta de total de contas por categoria
    /// </summary>
    public class ContaCategoriaDTO
    {
        /// <summary>
        /// Categoria da Conta
        /// </summary>
        public Categoria Categoria { get; set; }

        /// <summary>
        /// Somatorio do valor total da categoria
        /// </summary>
        public decimal Total { get; set; }
    }
}
