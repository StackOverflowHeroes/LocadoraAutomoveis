
using LocadoraAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraAutomoveis.Aplicacao.ModuloAutomovel
{
    public interface IServicoAutomovel : IServico<Automovel>
    {
        List<string> ValidarAutomovel(Automovel automovel);
        bool NomeDuplicado(Automovel automovel);
    }
}
