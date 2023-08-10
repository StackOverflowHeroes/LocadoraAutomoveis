using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
     public partial class TelaDevolucaoAluguelForm : Form
     {
          private Aluguel Aluguel { get; set; }
          private decimal ValorTotal { get; set; }
          public event GravarRegistroDelegate<Aluguel> onGravarRegistro;

          public TelaDevolucaoAluguelForm()
          {
               InitializeComponent();
               this.ConfigurarDialog();
          }

          public Aluguel ObterAluguel()
          {
               Aluguel.CombustivelRestante = (NivelTanqueEnum)cboxNivelTanque.SelectedItem;
               Aluguel.DataDevolucao = dateDevolucao.Value;
               Aluguel.QuilometrosRodados = valorKmPercorrido.Value;
               return Aluguel;
          }

          public void PopularComboBox(Aluguel aluguel)
          {
               var tiposCombustiveis = Enum.GetValues(typeof(NivelTanqueEnum));

               foreach (var tipo in tiposCombustiveis)
               {
                    cboxNivelTanque.Items.Add(tipo);
               }
          }

          public void PopularListBox(List<TaxaServico> taxas)
          {
               foreach (TaxaServico taxa in taxas)
               {
                    if (taxa.PlanoDiario == false)
                         listTaxas.Items.Add(taxa);
               }
          }

          private void listTaxas_MouseUp(object sender, MouseEventArgs e)
          {
               TaxaServico sa = null;

               if (listTaxas.CheckedItems.Contains(listTaxas.SelectedItem))
               {
                    sa = listTaxas.SelectedItem as TaxaServico;
                    ValorTotal += sa.Preco;
               }
               else if (listTaxas.CheckedItems.Contains(listTaxas.SelectedItem) == false)
               {
                    sa = listTaxas.SelectedItem as TaxaServico;
                    ValorTotal -= sa.Preco;
               }

               if (sa != null)
                    lbValorTotal.Text = ValorTotal.ToString();
          }

          private void btnCalcularValorTotal_Click(object sender, EventArgs e)
          {
               //if (Aluguel.PlanoCobranca.Plano == FormasCobrancasEnum.Diario)
               //{
               //     int dias = Aluguel.DataPrevisaoRetorno.Value.CompareTo(Aluguel.DataLocacao.Date);


               //     Aluguel.PlanoCobranca.Diaria
               //}
          }

          private void btnGravar_Click(object sender, EventArgs e)
          {
               Aluguel aluguel = ObterAluguel();

               Result resultado = onGravarRegistro(aluguel);

               if (resultado.IsFailed)
               {
                    string erro = resultado.Errors[0].Message;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                    DialogResult = DialogResult.None;
               }
          }
     }
}
