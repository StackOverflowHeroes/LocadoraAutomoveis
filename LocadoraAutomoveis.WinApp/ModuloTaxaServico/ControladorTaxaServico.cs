using LocadoraAutomoveis.Aplicacao.ModuloTaxaServico;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;


namespace LocadoraAutomoveis.WinApp.ModuloTaxaServico
{
     public class ControladorTaxaServico : ControladorBase
     {
          private IRepositorioTaxaServico repositorioTaxaServico;
          private ServicoTaxaServico servicoTaxaServico;
          private TabelaTaxaServicoControl tabelaTaxaServico;

          public ControladorTaxaServico(IRepositorioTaxaServico repositorioTaxaServico, ServicoTaxaServico servicoTaxaServico)
          {
               this.repositorioTaxaServico = repositorioTaxaServico;
               this.servicoTaxaServico = servicoTaxaServico;
          }

          public override void CarregarRegistros()
          {
               List<TaxaServico> taxaServicos = repositorioTaxaServico.SelecionarTodos();

               tabelaTaxaServico.AtualizarRegistros(taxaServicos);

               mensagemRodape = string.Format("Visualizando {0} Taxa{1} ou Servico{1}", taxaServicos.Count, taxaServicos.Count == 1 ? "" : "s");

               TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
          }

          public override void Inserir()
          {
               TelaTaxaServicoForm telaTaxaServico = new TelaTaxaServicoForm();

               telaTaxaServico.onGravarRegistro += servicoTaxaServico.Inserir;

               telaTaxaServico.ConfigurarTelaTaxaServico(new TaxaServico());

               DialogResult resultado = telaTaxaServico.ShowDialog();

               if (resultado == DialogResult.OK)
               {
                    CarregarRegistros();
               }
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
               if (tabelaTaxaServico == null)
                    tabelaTaxaServico = new TabelaTaxaServicoControl();

               CarregarRegistros();

               return tabelaTaxaServico;
          }
     }
}
