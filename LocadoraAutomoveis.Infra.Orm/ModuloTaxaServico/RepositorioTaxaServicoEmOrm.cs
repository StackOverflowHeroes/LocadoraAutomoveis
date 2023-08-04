using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxaServico
{
     public class RepositorioTaxaServicoEmOrm : RepositorioBaseEmOrm<TaxaServico>, IRepositorioTaxaServico
     {
          public RepositorioTaxaServicoEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
          {
          }

          public TaxaServico SelecionarPorNome(string nome)
          {
               return registros.FirstOrDefault(x => x.Nome == nome);
          }
     }
}
