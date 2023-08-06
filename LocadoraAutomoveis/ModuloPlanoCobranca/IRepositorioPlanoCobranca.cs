
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        PlanoCobranca SelecionarPorNome(string nome);
    }
}
