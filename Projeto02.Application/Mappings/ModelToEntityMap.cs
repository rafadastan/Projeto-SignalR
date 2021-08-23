using AutoMapper;
using Projeto02.Application.Models.Contas;
using Projeto02.Domain.Entities;
using Projeto02.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Mappings
{

    /// <summary>
    /// Mapeamento dos fluxos de entrada da aplicação
    /// </summary>
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<AddContasModel, Conta>()
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.IdConta = Guid.NewGuid();
                        dest.DataHora = DateTime.Now;
                        dest.Categoria = (Categoria)src.Categoria;
                    }
                );
        }
    }
}
