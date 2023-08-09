using LocadoraAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraAutomoveis.WinApp.ModuloCondutor
{
     public partial class TabelaCondutorControl : UserControl
     {
          public TabelaCondutorControl()
          {
               InitializeComponent();
               gridCondutor.ConfigurarGridSomenteLeitura();
               gridCondutor.ConfigurarGridZebrado();
               gridCondutor.Columns.AddRange(ObterColunas());
          }

          private DataGridViewColumn[] ObterColunas()
          {
               var colunas = new DataGridViewColumn[]
          {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "NomeCliente", HeaderText = "Nome do Cliente", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "CPF", HeaderText = "CPF", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "CNH", HeaderText = "CNH", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "DataValidade", HeaderText = "Validade CNH", FillWeight=50F}

          };

               return colunas;
          }

          public Guid ObtemIdSelecionado()
          {
               return gridCondutor.SelecionarId();
          }

          public void AtualizarRegistros(List<Condutor> condutores)
          {
               gridCondutor.Rows.Clear();

               foreach (var condutor in condutores)
               {
                    gridCondutor.Rows.Add(condutor.Id, condutor.Nome, condutor.Cliente.Nome, condutor.CPF, condutor.CNH, condutor.DataValidade.ToShortDateString());
               }
          }
     }
}
