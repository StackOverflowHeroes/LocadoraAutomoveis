namespace LocadoraAutomoveis.Dominio.ModuloTaxaServico
{
     public class ValidadorTaxaServico : AbstractValidator<TaxaServico>, IValidadorTaxaServico
     {
          public ValidadorTaxaServico()
          {
               RuleFor(x => x.Nome)
                       .NotNull().WithMessage("'Nome' deve ser informado.")
                       .NotEmpty().WithMessage("'Nome' não pode ser vazio.")
                       .MinimumLength(3).WithMessage("'Nome' deve possuir no mínimo 3 caracteres.")
                       .NaoPodeCaracteresEspeciais()
                       .Matches(@"\A\S{3,15}\z").WithMessage("'Nome' não pode conter espaços em branco.");

               RuleFor(x => x.Preco)
                       .NotNull().WithMessage("'Preço' não pode ser nulo.")
                       .GreaterThan(0).WithMessage("'Preço' não pode ser 0.");

               RuleFor(x => x.PlanoDiario)
                       .NotNull().WithMessage("'Plano' deve ser informado.")
                       .NotEmpty().WithMessage("'Plano' não pode ser vazio.");                       
          }
     }
}
