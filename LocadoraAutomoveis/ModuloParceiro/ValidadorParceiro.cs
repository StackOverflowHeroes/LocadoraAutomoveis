namespace LocadoraAutomoveis.Dominio.ModuloParceiro
{
     public class ValidadorParceiro : AbstractValidator<Parceiro>, IValidadorParceiro
     {
        public ValidadorParceiro()
        {
               RuleFor(x => x.Nome)
                       .NotNull()
                       .NotEmpty()
                       .MinimumLength(2)
                       .NaoPodeCaracteresEspeciais();               
        }
    }
}
