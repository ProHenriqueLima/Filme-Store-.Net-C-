using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWiPro.Business.Models
{
    public class Aluguel
    {
        public long Id { get; set; }
        public DateTime? DataDoAluguel { get; set; }
        public DateTime? DataDaDevolucao { get; set; }
        public DateTime? DataDePrevisao { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public long FilmeId { get; set; }
        public Filme Filme { get; set; }
        public string? Situacao { get; set; }
        public bool Ativo { get; set; }

    }
}
