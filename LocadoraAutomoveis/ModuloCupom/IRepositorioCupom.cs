

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public interface IRepositorioCupom : IRepositorio<Cupom>
    {
        Cupom SelecionarPorNome(string nome);
    }
}
