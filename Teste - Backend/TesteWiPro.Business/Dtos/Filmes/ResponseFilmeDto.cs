using System.ComponentModel.DataAnnotations;

namespace TesteWiPro.Business.Dto
{
    public class ResponseFilmeDto
    {
        public string? Nome { get; set; }

        public string? AnoDeLançamento { get; set; }

        public string? Alugado { get; set; }

    }
}
