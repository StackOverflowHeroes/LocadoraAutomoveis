namespace LocadoraAutomoveis.Aplicacao.ModuloParceiro
{
     public interface IServicoParceiro : IServico<Parceiro>
     {
          List<string> ValidarParceiro(Parceiro parceiro);
          bool NomeDuplicado(Parceiro parceiro);
     }
}
