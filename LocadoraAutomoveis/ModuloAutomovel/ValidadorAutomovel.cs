
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel>, IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.ImagemAutomovel)
                    .NotNull().WithMessage("Deve enviar uma foto do automóvel")
                    .Must(ImagemAutomovel => ImagemAutomovel?.Length <= 2 * 1024 * 1024).WithMessage("A foto deve ter no máximo 2MB.");

            RuleFor(x => x.GrupoAutomovel)
                    .NotNull().WithMessage("'GrupoAutomovel' deve ser informado.")
                    .NotEmpty().WithMessage("'GrupoAutomovel' não pode ser vazio.");

            RuleFor(x => x.Modelo)
                    .NotNull().WithMessage("'Modelo' deve ser informado.")
                    .NotEmpty().WithMessage("'Modelo' não pode ser vazio.")
                    .MinimumLength(3).WithMessage("'Modelo' deve possuir no mínimo 3 caracteres.");

            RuleFor(x => x.Marca)
                    .NotNull().WithMessage("'Marca' deve ser informado.")
                    .NotEmpty().WithMessage("'Marca' não pode ser vazio.")
                    .MinimumLength(3).WithMessage("'Marca' deve possuir no mínimo 3 caracteres.")
                    .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Ano)
                    .NotNull().WithMessage("'Ano' deve ser informado")
                    .NotEmpty().WithMessage("'Ano' não pode ser vazio.")
                    .Must(ano => ano <= (DateTime.Now.Year + 1))
                    .WithMessage($"Um modelo de carro não pode ser maior que {DateTime.Now.Year + 1}")
                    .GreaterThan(0);

            RuleFor(x => x.Quilometragem)
                    .NotNull().WithMessage("'Quilometragem' deve ser informado")
                    .NotEmpty().WithMessage("'Quilometragem' não pode ser vazio.")
                    .GreaterThan(0);

            RuleFor(x => x.Cor)
                   .NotNull().WithMessage("'Cor' deve ser informado.")
                   .NotEmpty().WithMessage("'Cor' não pode ser vazio.")
                   .MinimumLength(3).WithMessage("'Cor' deve possuir no mínimo 3 caracteres.")
                   .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Placa)
                    .NotNull().WithMessage("'Placa' deve ser informado.")
                    .NotEmpty().WithMessage("'Placa' não pode ser vazio.")
                    .Must(ValidarPlaca)
                    .WithMessage("A placa informada não é válida.");

            RuleFor(x => x.Combustivel)
                    .NotNull()
                    .NotEmpty()
                    .Must(x => Enum.IsDefined(typeof(TipoCombustivelEnum), x))
                    .WithMessage("Escolha um 'Combustível' válido.");


            RuleFor(x => x.CapacidadeLitros)
                    .NotNull().WithMessage("'CapacidadeLitros' deve ser informado")
                    .NotEmpty().WithMessage("'CapacidadeLitros' não pode ser vazio.")
                    .GreaterThan(0);


        }

        private bool ValidarPlaca(string placa)
        {
            string pattern = @"^(?:[A-Z]{3}-?\d{4}|[A-Z]{3}\s?\d{4}|[A-Z]{3}-?\d[A-Z]\d{2}|[A-Z]{3}\s?\d[A-Z]\d{2})";

            return Regex.IsMatch(placa, pattern, RegexOptions.IgnoreCase);
        }
    }
}
