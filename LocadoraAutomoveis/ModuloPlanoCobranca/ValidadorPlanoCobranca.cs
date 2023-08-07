
using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.Diaria)
                    .NotNull().WithMessage("'Diária' deve ser informado")
                    .NotEmpty().WithMessage("'Diária' não pode ser vazio.")
                    .GreaterThan(0);

            RuleFor(x => x.KM_disponivel)
                  .GreaterThan(0);

            RuleFor(x => x.Preco_KM)
                    .GreaterThan(0);

            RuleFor(x => x.grupoAutomovel)
                    .NotNull().WithMessage("'Grupo de automóveis' deve ser informado")
                    .NotEmpty().WithMessage("'Grupo de automóveis' não pode ser vazio.");
        }

    }
}
