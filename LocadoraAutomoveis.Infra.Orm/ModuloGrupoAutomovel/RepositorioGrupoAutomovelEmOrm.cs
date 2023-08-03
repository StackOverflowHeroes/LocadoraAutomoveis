using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Infra.Orm.ModuloParceiro
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
