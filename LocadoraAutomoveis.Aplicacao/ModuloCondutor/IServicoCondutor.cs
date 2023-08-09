using LocadoraAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraAutomoveis.Aplicacao.ModuloCondutor
{
     public interface IServicoCondutor : IServico<Condutor>
     {
          List<string> ValidarCondutor(Condutor condutor);
          bool NomeDuplicado(Condutor condutor);
     }
}
