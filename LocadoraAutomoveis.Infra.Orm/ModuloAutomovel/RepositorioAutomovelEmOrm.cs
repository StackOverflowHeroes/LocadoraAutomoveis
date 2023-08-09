
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomovel
{
    public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
        {
        }

        public List<Automovel> SelecionarPorGrupoAutomovel(GrupoAutomovel grupoSelecionado)
        {
            return registros.Where(x => x.GrupoAutomovel.Nome.ToLower() == grupoSelecionado.Nome.ToLower()).Include(x => x.GrupoAutomovel).ToList();
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
