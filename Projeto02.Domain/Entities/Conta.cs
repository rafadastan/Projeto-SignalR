using Projeto02.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Domain.Entities
{
    public class Conta
    {
        public Guid IdConta { get; set; }
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataHora { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
