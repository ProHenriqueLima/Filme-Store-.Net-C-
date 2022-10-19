using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWiPro.Business.Models
{
    public class Filme
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? AnoDeLançamento { get; set; }
        public bool Alugado { get; set; }
        public bool Ativo { get; set; }
    }
}
