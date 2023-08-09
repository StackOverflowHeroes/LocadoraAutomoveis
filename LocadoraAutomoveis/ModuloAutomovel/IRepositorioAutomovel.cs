

using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorio<Automovel>
    {
        List<Automovel> SelecionarPorGrupoAutomovel(GrupoAutomovel grupoSelecionado);
        Automovel SelecionarPorNome(string nome);
        public List<Automovel> SelecionarTodos(bool incluirGrupoAutomovel = false);
    }
}
