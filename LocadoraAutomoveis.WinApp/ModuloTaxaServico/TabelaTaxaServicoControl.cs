using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaServico
{
     public partial class TabelaTaxaServicoControl : UserControl
     {
          public TabelaTaxaServicoControl()
          {
               InitializeComponent();
               gridTaxaServico.ConfigurarGridZebrado();
               gridTaxaServico.ConfigurarGridSomenteLeitura();
               gridTaxaServico.Columns.AddRange(ObterColunas());
          }

          private DataGridViewColumn[] ObterColunas()
          {
               var colunas = new DataGridViewColumn[]
{
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preço da Taxa/Serviço (R$)", FillWeight=50F }
};

               return colunas;
          }

          public Guid ObtemIdSelecionada()
          {
               return gridTaxaServico.SelecionarId();
          }

          public void AtualizarRegistros(List<TaxaServico> taxaServicos)
          {
               gridTaxaServico.Rows.Clear();

               foreach (TaxaServico taxaServico in taxaServicos)
               {
                    gridTaxaServico.Rows.Add(taxaServico.Id, taxaServico.Nome, $"R$ {taxaServico.Preco}");
               }
          }
     }
}
