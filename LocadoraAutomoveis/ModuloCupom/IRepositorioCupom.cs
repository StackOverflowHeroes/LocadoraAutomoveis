

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public interface IRepositorioCupom : IRepositorio<Cupom>
    {
        Cupom SelecionarPorNome(string nome);

        public List<Cupom> SelecionarTodos(bool incluirParceiro = false);
    }
}
