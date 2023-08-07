
namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public class ValidadorCupom: AbstractValidator<Cupom>, IValidadorCupom
    {
        public ValidadorCupom()
        {
            RuleFor(x => x.Nome)
                    .NotNull().WithMessage("'Nome' deve ser informado.")
                    .NotEmpty().WithMessage("'Nome' não pode ser vazio.")
                    .MinimumLength(2).WithMessage("'Nome' deve possuir no mínimo 3 caracteres.");

            RuleFor(x => x.Valor)
                    .NotNull().WithMessage("'Valor' deve ser informado")
                    .NotEmpty().WithMessage("'Valor' não pode ser vazio.")
                    .GreaterThan(0);

            RuleFor(x => x.DataValidade)
                    .NotNull().WithMessage("'Data de validade' deve ser informado")
                    .NotEmpty().WithMessage("'Data de validade' não pode ser vazio.")
                    .Must(DataFuturo).WithMessage("Não é possível cadastrar uma data de validade no passado.");

            RuleFor(x => x.Parceiro)
                    .NotNull().WithMessage("'Parceiro' deve ser informado.")
                    .NotEmpty().WithMessage("'Parceiro' não pode ser vazio.");

        }

        private bool DataFuturo(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
