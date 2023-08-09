
using LocadoraAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomovel
{
    public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
        {
        }

        public Automovel SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Modelo == nome);

        }

        public List<Automovel> SelecionarTodos(bool incluirGrupoAutomovel = false)
        {
            if (incluirGrupoAutomovel)
                return registros.Include(x => x.GrupoAutomovel).ToList();

            return registros.ToList();
        }
    }
}
