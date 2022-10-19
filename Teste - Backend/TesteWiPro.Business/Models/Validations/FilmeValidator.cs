using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWiPro.Business.Models.Validations
{
    public class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                    .WithMessage("O Nome do Filme precisa ser informado");
            
            RuleFor(x => x.AnoDeLançamento)
                .NotEmpty()
                    .WithMessage("O Ano do Filme precisa ser informado");
        }
    }
}
