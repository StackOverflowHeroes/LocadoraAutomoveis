namespace LocadoraAutomoveis.Dominio.ModuloParceiro
{
     public interface IRepositorioParceiro : IRepositorio<Parceiro>
     {
          Parceiro SelecionarPorNome(string nome);          
     }
}
