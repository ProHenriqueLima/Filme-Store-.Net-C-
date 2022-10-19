using System.ComponentModel.DataAnnotations;

namespace TesteWiPro.Api.ViewModels.Cliente
{
    public class RequestAluguelVM
    {
        [Required(ErrorMessage ="O Campo {0} precisa ser preenchido")]
        public DateTime? DataDoAluguel { get; set; }
        [Required(ErrorMessage ="O Campo {0} precisa ser preenchido")]
        public DateTime? DataDePrevisao { get; set; }
        [Required(ErrorMessage = "O Campo {0} precisa ser preenchido")]
        public long ClienteId { get; set; }
        [Required(ErrorMessage = "O Campo {0} precisa ser preenchido")]
        public long FilmeId { get; set; }

        
    }
}
