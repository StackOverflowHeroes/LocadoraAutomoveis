
namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel
{
    public class ValidadorGrupoAutomovel : AbstractValidator<GrupoAutomovel>, IValidadorGrupoAutomovel
    {
        public ValidadorGrupoAutomovel()
        {
            RuleFor(x => x.Nome)
                    .NotNull().WithMessage("'Nome' deve ser informado.")
                    .NotEmpty().WithMessage("'Nome' não pode ser vazio.")
                    .MinimumLength(2).WithMessage("'Nome' deve possuir no mínimo 2 caracteres.")
                    .NaoPodeCaracteresEspeciais();
        }
    }
}
