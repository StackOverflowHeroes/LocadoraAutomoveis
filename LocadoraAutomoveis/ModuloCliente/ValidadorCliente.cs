using System.Text.RegularExpressions;


namespace LocadoraAutomoveis.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("'Nome' deve ser informado.")
                .NotEmpty().WithMessage("'Nome' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Nome' deve possuir no mínimo 3 caracteres.")
                .NaoPodeCaracteresEspeciais()
                .Matches(@"^[a-zA-Z0-9]{3}").WithMessage("'Nome' não pode conter espaços em branco antes do mínimo.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("'Email' deve ser informado.")
                .NotEmpty().WithMessage("'Email' não pode ser vazio.")
                .Must(ValidarFormatoEmail).WithMessage("'Email' deve possuir um formato válido.");

            RuleFor(x => x.Telefone)
                .Must(ValidarTelefone).WithMessage("'Telefone' inválido.")
                .NotEmpty().WithMessage("'Telefone' não pode ser vazio.");


            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("'CPF' não pode ser vazio.")
                .IsValidCPF()
                .When(x => x.TipoPessoa == Tipo.Fisica);
            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("'CNPJ' não pode ser vazio.")
                .IsValidCNPJ()
                .When(x => x.TipoPessoa == Tipo.Juridica);

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("'Estado' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Estado' deve ser maior ou igual a 3 caracteres.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("'Cidade' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Cidade' deve ser maior ou igual a 3 caracteres.");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("'Bairro' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Bairro' deve ser maior ou igual a 3 caracteres.");

            RuleFor(x => x.Rua)
                .NotEmpty().WithMessage("'Rua' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Rua' deve ser maior ou igual a 3 caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("'Numero' não pode ser vazio.");
        }



        private bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}");
        }

        private bool ValidarFormatoEmail(string email)
        {
            string padraoEmail = @"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

            Regex regexEmail = new Regex(padraoEmail);

            return regexEmail.IsMatch(email);
        }
    }

}

