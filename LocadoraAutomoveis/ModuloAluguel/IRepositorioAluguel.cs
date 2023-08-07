
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorio<Aluguel>
    {
        bool CumpomExiste(Aluguel aluguelParaValidar, List<Cupom> cupomLista);
    }
}
