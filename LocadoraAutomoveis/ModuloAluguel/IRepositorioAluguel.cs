
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorio<Aluguel>
    {
        bool CumpomNaoExistente(Aluguel aluguelParaValidar, List<Cupom> cupomLista);
    }
}
