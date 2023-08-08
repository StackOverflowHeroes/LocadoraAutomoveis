using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloCondutor
{
     public class ValidadorCondutor : AbstractValidator<Condutor>, IValidadorCondutor
     {
          public ValidadorCondutor()
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


               RuleFor(x => x.CPF)
                       .NotEmpty().WithMessage("'CPF' não pode ser vazio.")
                       .IsValidCPF();

               RuleFor(x => x.CNH)
                       .NotEmpty().WithMessage("'CNH' não pode ser vazia.")
                       .Must(ValidarFormatoCNH).WithMessage("'Data de validade' teve prazo expirado.");

               RuleFor(x => x.DataValidade)
                       .NotNull().WithMessage("'Data de validade' deve ser informado.")
                       .NotEmpty().WithMessage("'Data de validade' não pode ser vazio.")
                       .Must(DataVencimento).WithMessage("'Data de validade' teve prazo expirado.");

               RuleFor(x => x.Cliente)
                       .NotNull().WithMessage("'Cliente' deve ser informado.")
                       .NotEmpty().WithMessage("'Cliente' não pode ser vazio.");
          }

          private bool DataVencimento(DateTime date)
          {
               return date <= DateTime.Now;
          }

          private bool ValidarFormatoCNH(string telefone)
          {
               return Regex.IsMatch(telefone, @"(?=.*\d)[A-Za-z0-9]{1,11}");
          }

          private bool ValidarTelefone(string cnh)
          {
               return Regex.IsMatch(cnh, @"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}");
          }

          private bool ValidarFormatoEmail(string email)
          {
               string padraoEmail = @"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

               Regex regexEmail = new Regex(padraoEmail);

               return regexEmail.IsMatch(email);
          }
     }
}
