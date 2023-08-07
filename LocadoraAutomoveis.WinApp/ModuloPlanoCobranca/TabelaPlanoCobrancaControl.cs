
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.WinApp.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobrancaControl : UserControl
    {
        public TabelaPlanoCobrancaControl()
        {
            InitializeComponent();
            gridPlanoCobranca.ConfigurarGridZebrado();
            gridPlanoCobranca.ConfigurarGridSomenteLeitura();
            gridPlanoCobranca.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F, Visible=false},

                new DataGridViewTextBoxColumn { Name = "Diaria", HeaderText = "Valor Diária", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Preco_KM", HeaderText = "Preço por KM", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "KM_disponivel", HeaderText = "KM Disponíveis", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Plano", HeaderText = "Plano Selecionado", FillWeight=85F },

            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridPlanoCobranca.SelecionarId();
        }

        public void AtualizarRegistros(List<PlanoCobranca> planosCobrancas)
        {
            gridPlanoCobranca.Rows.Clear();

            foreach (var planos in planosCobrancas)
            {
                gridPlanoCobranca.Rows.Add(planos.Id, planos.Nome, $"R$ {planos.Diaria}", $"R$ {planos.Preco_KM}", planos.KM_disponivel, planos.Plano);
            }
        }

    }
}
