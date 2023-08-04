using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaServico
{
     public partial class TelaTaxaServicoForm : Form
     {
          TaxaServico taxaServico;
          public event GravarRegistroDelegate<TaxaServico> onGravarRegistro;

          public TelaTaxaServicoForm()
          {
               InitializeComponent();
               this.ConfigurarDialog();
          }

          public TaxaServico ObterTaxaServico()
          {
               taxaServico.Nome = txtNome.Text;
               taxaServico.Preco = campoPreco.Value;

               if (precoDiario.Checked)
                    taxaServico.PlanoDiario = true;
               else
                    taxaServico.PlanoDiario = false;

               return taxaServico;
          }

          public void ConfigurarTelaTaxaServico(TaxaServico taxaServico)
          {
               this.taxaServico = taxaServico;
               txtNome.Text = taxaServico.Nome;
               campoPreco.Value = taxaServico.Preco;

               if (taxaServico != null)
               {
                    if (taxaServico.PlanoDiario)
                         precoDiario.Checked = true;
                    else
                         precoFixo.Checked = false;
               }
          }

          private void btnGravar_Click(object sender, EventArgs e)
          {
               this.taxaServico = ObterTaxaServico();

               Result resultado = onGravarRegistro(taxaServico);

               if (resultado.IsFailed)
               {
                    string erro = resultado.Errors[0].Message;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                    DialogResult = DialogResult.None;
               }
          }
     }
}
