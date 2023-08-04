using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.Aplicacao.ModuloTaxaServico
{
     public interface IServicoTaxaServico : IServico<TaxaServico>
     {
          List<string> ValidarTaxaServico(TaxaServico taxaServico);
          bool NomeDuplicado(TaxaServico taxaServico);
     }
}
