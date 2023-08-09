

namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorio<Automovel>
    {
        Automovel SelecionarPorNome(string nome);
        public List<Automovel> SelecionarTodos(bool incluirGrupoAutomovel = false);
    }
}
