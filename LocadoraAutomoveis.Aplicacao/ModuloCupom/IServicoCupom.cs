
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Aplicacao.ModuloCupom
{
    public interface IServicoCupom : IServico<Cupom>
    {
        List<string> ValidarCupom(Cupom cupom);
        bool NomeDuplicado(Cupom cupom);
    }
}
