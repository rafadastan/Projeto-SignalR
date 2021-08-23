using AutoMapper;
using Projeto02.Application.Models.Contas;
using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Mappings
{
    /// <summary>
    /// Mapeamento dos fluxos de saída da aplicação
    /// </summary>
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Conta, GetContasModel>()
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.Categoria = src.Categoria.ToString();
                    }
                );
        }
    }
}
