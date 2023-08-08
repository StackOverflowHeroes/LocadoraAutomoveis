using LocadoraAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
     public class RepositorioCondutorEmOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
     {
          public RepositorioCondutorEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
          {
          }

          public Condutor SelecionarPorNome(string nome)
          {
               return registros.FirstOrDefault(x => x.Nome == nome);
          }

          public List<Condutor> SelecionarTodos(bool incluirCliente = false)
          {
               if (incluirCliente)
                    return registros.Include(x => x.Cliente).ToList();

               return registros.ToList();
          }
     }
}
