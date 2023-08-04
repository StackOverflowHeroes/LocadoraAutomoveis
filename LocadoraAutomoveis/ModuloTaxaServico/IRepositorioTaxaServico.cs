namespace LocadoraAutomoveis.Dominio.ModuloTaxaServico
{
     public interface IRepositorioTaxaServico : IRepositorio<TaxaServico>
     {
          TaxaServico SelecionarPorNome(string nome);
     }
}
