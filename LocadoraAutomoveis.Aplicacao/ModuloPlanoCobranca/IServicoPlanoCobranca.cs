
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca
{
    public interface IServicoPlanoCobranca : IServico<PlanoCobranca>
    {
        List<string> ValidarGrupoAutomovel(PlanoCobranca planoCobranca);
        bool NomeDuplicado(PlanoCobranca planoCobranca);
    }
}
