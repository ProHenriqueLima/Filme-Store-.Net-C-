using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWiPro.Business.Models.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                    .WithMessage("O Nome do Cliente precisa ser informado");
            
            RuleFor(x => x.Endereco)
                .NotEmpty()
                    .WithMessage("O Endereço do Cliente precisa ser informado");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("O Email do Cliente precisa ser informado")
                .EmailAddress()
                    .WithMessage("Este endereço de email é inválido");
        }
    }
}
