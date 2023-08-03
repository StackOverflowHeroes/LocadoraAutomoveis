

namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel
{
    public interface IRepositorioGrupoAutomovel : IRepositorio<GrupoAutomovel>
    {
        GrupoAutomovel SelecionarPorNome(string nome);
    }
}
