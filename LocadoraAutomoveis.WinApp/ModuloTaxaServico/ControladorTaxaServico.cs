using LocadoraAutomoveis.Aplicacao.ModuloTaxaServico;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaServico
{
     public class ControladorTaxaServico : ControladorBase
     {
          private IRepositorioTaxaServico repositorioTaxaServico;
          private ServicoTaxaServico servicoTaxaServico;
          private TabelaTaxaServicoControl tabelaTaxaServico;

          public override void Inserir()
          {
               throw new NotImplementedException();
          }
          public override void Editar()
          {
               throw new NotImplementedException();
          }
          public override void Excluir()
          {
               throw new NotImplementedException();
          }
          public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
          {
               return new ConfiguracaoToolboxTaxaServico();
          }
          public override UserControl ObtemListagem()
          {
               throw new NotImplementedException();
          }
     }
}
