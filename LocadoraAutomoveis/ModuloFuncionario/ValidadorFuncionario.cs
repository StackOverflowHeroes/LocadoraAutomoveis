using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>, IValidadorFuncionario
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("'Nome' deve ser informado.")
                .NotEmpty().WithMessage("'Nome' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Nome' deve possuir no mínimo 3 caracteres.")
                .NaoPodeCaracteresEspeciais()
                .Matches(@"^[a-zA-Z0-9]{3}").WithMessage("'Nome' não pode conter espaços em branco antes do mínimo.");
        }
    }
}
