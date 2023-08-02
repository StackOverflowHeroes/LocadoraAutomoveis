using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Infra.Orm.ModuloParceiro
{
     public class RepositorioParceiroEmOrm : RepositorioBaseEmOrm<Parceiro>, IRepositorioParceiro
     {
          public RepositorioParceiroEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
          {
          }

          public Parceiro SelecionarPorNome(string nome)
          {
               return registros.FirstOrDefault(x => x.Nome == nome);
          }
     }
}
