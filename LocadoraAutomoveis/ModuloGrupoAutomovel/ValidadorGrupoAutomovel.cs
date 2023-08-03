
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
                    .NaoPodeCaracteresEspeciais()
                    .Matches(@"\A\S{3,15}\z").WithMessage("'Nome' não pode conter espaços em branco.");
        }
    }
}
