using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Models.Contas
{
    public class AddContasModel
    {
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Categoria { get; set; }
    }
}
