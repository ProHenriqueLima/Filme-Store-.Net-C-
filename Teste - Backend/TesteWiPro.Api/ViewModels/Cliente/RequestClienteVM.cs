using System.ComponentModel.DataAnnotations;

namespace TesteWiPro.Api.ViewModels.Cliente
{
    public class RequestClienteVM
    {
        [Required(ErrorMessage ="O Campo {0} precisa ser preenchido")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} precisa ser preenchido")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "O Campo {0} precisa ser preenchido")]
        public string? Endereco { get; set; }
    }
}
