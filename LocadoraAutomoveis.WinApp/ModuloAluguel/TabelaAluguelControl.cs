using LocadoraAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {
        public TabelaAluguelControl()
        {
            InitializeComponent();
            
            gridAluguel.ConfigurarGridZebrado();
            gridAluguel.ConfigurarGridSomenteLeitura();
            gridAluguel.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight = 15F, Visible = false },
                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight = 35F },
                new DataGridViewTextBoxColumn { Name = "Veiculo", HeaderText = "Veículo", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "Plano", HeaderText = "Plano Selecionado", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "DataSaida", HeaderText = "Data de Saída", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "DataPrevista", HeaderText = "Data Prevista", FillWeight = 20F },
                new DataGridViewTextBoxColumn { Name = "DataDevolucao", HeaderText = "Data Devolução", FillWeight = 20F }
            };
            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return gridAluguel.SelecionarId();
        }
        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            gridAluguel.Rows.Clear();
            foreach (Aluguel aluguel in alugueis)
            {
                gridAluguel.Rows.Add(aluguel.Id,
                                    //aluguel.Condutor.Nome,
                                    //aluguel.Automovel.Placa,
                                    aluguel.PlanoCobranca,
                                    aluguel.DataLocacao,
                                    aluguel.DataPrevisaoRetorno,
                                    aluguel.DataDevolucao,
                                    aluguel.ValorTotal);
            }
        }
    }
}
