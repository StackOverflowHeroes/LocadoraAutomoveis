using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomovel
{
    public class RepositorioGrupoAutomovelEmOrm : RepositorioBaseEmOrm<GrupoAutomovel>, IRepositorioGrupoAutomovel
    {
        public RepositorioGrupoAutomovelEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomovel SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
