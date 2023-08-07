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
               Guid id = tabelaTaxaServico.ObtemIdSelecionada();

               TaxaServico taxaServicoSelecionado = repositorioTaxaServico.SelecionarPorId(id);

               if (taxaServicoSelecionado == null)
               {
                    MessageBox.Show("Selecione uma taxa ou serviço primeiro.",
                    "Edição de Taxas/Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
               }

               TelaTaxaServicoForm telaTaxaServico = new TelaTaxaServicoForm();
               telaTaxaServico.Text = "Edição de Taxa/Serviço";
               telaTaxaServico.onGravarRegistro += servicoTaxaServico.Editar;

               telaTaxaServico.ConfigurarTelaTaxaServico(taxaServicoSelecionado);

               DialogResult resultado = telaTaxaServico.ShowDialog();

               if (resultado == DialogResult.OK)
               {
                    CarregarRegistros();
               }
          }

          public override void Excluir()
          {
               Guid id = tabelaTaxaServico.ObtemIdSelecionada();

               TaxaServico taxaServicoSelecionado = repositorioTaxaServico.SelecionarPorId(id);

               if (taxaServicoSelecionado == null)
               {
                    MessageBox.Show("Selecione uma taxa ou serviço primeiro.",
                    "Exclusão de Taxas/Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
               }

               DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a taxa/serviço?",
                  "Exclusão de Taxas/Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

               if (opcaoEscolhida == DialogResult.OK)
               {
                    Result resultado = servicoTaxaServico.Excluir(taxaServicoSelecionado);

                    if (resultado.IsFailed)
                    {
                         MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Taxas/Serviços",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                         return;
                    }

                    CarregarRegistros();
               }
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
