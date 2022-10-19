using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWiPro.Business.Models.Validations
{
    public class AluguelValidator : AbstractValidator<Aluguel>
    {
        public AluguelValidator()
        {
            RuleFor(x => x.DataDoAluguel)
                .NotEmpty()
                    .WithMessage("A Data do Aluguel precisa ser informada");
            
            RuleFor(x => x.DataDePrevisao)
                .NotEmpty()
                    .WithMessage("A Data de Previsão precisa ser informada");

            RuleFor(x => x.Situacao)
                .NotEmpty()
                    .WithMessage("O Email do Cliente precisa ser informado");

        }
    }
}
