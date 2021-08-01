using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Mvc.Models
{
    public class ContaViewModel
    {
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public int? Tipo { get; set; }
        public DateTime DataHora { get; set; }
    }
}
