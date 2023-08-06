
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobrancaEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
        {
        }

        public PlanoCobranca SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);

        }
    }
}
