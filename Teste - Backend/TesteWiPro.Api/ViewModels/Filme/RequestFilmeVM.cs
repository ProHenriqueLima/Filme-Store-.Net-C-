using System.ComponentModel.DataAnnotations;

namespace TesteWiPro.Api.ViewModels.Filme
{
    public class RequestFilmeVM
    {
        [Required(ErrorMessage ="O Campo {0} precisa ser preenchido")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} precisa ser preenchido")]
        public string? AnoDeLançamento { get; set; }
    }
}
